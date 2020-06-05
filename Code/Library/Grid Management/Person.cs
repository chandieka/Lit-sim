using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
	[Serializable]
	public class Person : FunctionalBlock
	{
		public bool IsDead { get; private set; }
		new public Color Color
		{
			get
			{
				if (this.IsDead)
					return Color.Orange;
				else if (this.HasFireExtinguisher)
					return Color.DeepPink;
				else if (this.fireExtinguisherGotTaken)
					return Color.BurlyWood;
				else if (this.firePathThread != null)
					return Color.MediumPurple;
				else
					return Color.Blue;
			}
		}

		[field: NonSerialized]
		internal Pair[] ShortestPath { get; private set; }
		[field: NonSerialized]
		private int pathIndex = 1;

		[field: NonSerialized]
		private bool fireExtinguisherGotTaken = false;
		[field: NonSerialized]
		private bool hasReachedFireBefore = false;
		[field: NonSerialized]
		private Pair[] nearestFirePath = null;
		[field: NonSerialized]
		private Thread firePathThread = null;
		[field: NonSerialized]
		private static Pair[] feLocations;
		private static int safeDistance = 5;

		public bool HasFireExtinguisher
			=> this.nearestFirePath != null;

		public void Kill()
		{
			this.IsDead = true;
			this.firePathThread?.Interrupt();
		}

		private bool move(Block[,] grid, Pair from, Pair[] pathArr)
		{
			var pathEntry = pathArr[pathIndex];

			if (pathEntry.X > grid.GetLength(0) || pathEntry.Y > grid.GetLength(1) || pathEntry.X < 0 || pathEntry.Y < 0)
				return false;

			var gridEntry = grid[pathEntry.X, pathEntry.Y];
			if (gridEntry is Person)
			{
				pathIndex++;
				return true;
			}
			else if (gridEntry is Floor)
			{
				grid[from.X, from.Y] = GridController.Floor;
				grid[pathEntry.X, pathEntry.Y] = this;
				pathIndex++;
				return true;
			}

			return false;
		}

		private Pair[] getSurrounding(Block[,] grid, Pair pos, Type typeToCheck = null, int radius = 1, Func<int, int, bool> additionalCheck = null)
		{
			Block checkPos(int x, int y)
			{
				if (
					x < 0 ||
					y < 0 ||
					x >= grid.GetLength(0) ||
					y >= grid.GetLength(1)
				)
					return null;
				else
					return grid[x, y];
			}

			List<Pair> pairs = new List<Pair>();

			for (int x = pos.X - radius; x <= pos.X + radius; x++)
			{
				for (int y = pos.Y - radius; y <= pos.Y + radius; y++)
				{
					if (!(pos.X == x && pos.Y == y))
					{
						var returnVal = checkPos(x, y);

						if (returnVal != null)
						{
							if (typeToCheck != null && returnVal.GetType() != typeToCheck)
								continue;

							if (additionalCheck != null && !additionalCheck(x, y))
								continue;

							pairs.Add(new Pair(x, y));
						}
					}
				}
			}

			return pairs.ToArray();
		}

		private Pair[] findShortestPath(Pair[][] paths, BackgroundWorker worker)
		{
			if (paths.Length < 1)
				return new Pair[0];

			Pair[] shortest = null;

			foreach (Pair[] p in paths)
				if (worker != null && worker.CancellationPending)
					return shortest;
				else if (shortest == null || p.Length < shortest.Length)
					shortest = p;

			return shortest;
		}

		private Pair[] findNearestFirePath(Block[,] grid, Pair pos)
		{
			Pair[] findFire(bool doCheck = true)
			{
				List<Pair> positions = new List<Pair>();
				Type floorType = typeof(Floor);

				for (int x = 0; x < grid.GetLength(0); x++)
					for (int y = 0; y < grid.GetLength(1); y++)
						if (!Thread.CurrentThread.IsAlive)
							return positions.ToArray();
						else if (grid[x, y] is Fire)
						{
							Pair p = new Pair(x, y);

							if (doCheck == true && getSurrounding(grid, p, floorType, 1).Length <= 0)
								continue;

							positions.Add(p);
						}

				return positions.ToArray();
			}

			List<Pair[]> paths = new List<Pair[]>();
			var fires = findFire();

			foreach (Pair p in fires)
			{
				if (!Thread.CurrentThread.IsAlive)
					return null;

				Pair[] path = null;

				try
				{
					path = new AStar(grid, pos, p).aStarSearch();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}

				if (path != null)
					paths.Add(path);
			}

			if (paths.Count > 0)
				return findShortestPath(paths.ToArray(), null);

			Console.WriteLine("For some reason there is no path to the fire???");
			return null;
		}

		private Pair getAveragePoint(Pair[] points)
		{
			int x = -1;
			int y = -1;

			for (int i = 0; i < points.Length; i++)
			{
				x += points[i].X;
				y += points[i].Y;
			}

			if (x < 0 || y < 0)
				return null;

			return new Pair(x / points.Length, y / points.Length);
		}

		private void calculateFirePathInDiffThread(Block[,] grid, Pair pos)
		{
			firePathThread = new Thread(() =>
			{
				var result = findNearestFirePath(grid, pos);

				if (result != null)
				{
					this.nearestFirePath = result;
					pathIndex = 1;
				}

				firePathThread = Thread.CurrentThread; // Set to something not null
			});
			firePathThread.Start();
		}

		private void reCalculateFEPath(Block[,] grid, Pair pos)
		{
			var bw = new BackgroundWorker();

			bw.WorkerSupportsCancellation = true;
			bw.WorkerReportsProgress = false;

			bw.DoWork += (o, e) =>
			{
				feLocations = feLocations.Where(p => grid[p.X, p.Y] is FireExtinguisher).ToArray();

				if (feLocations.Length > 0)
					CalculatePaths(grid, pos, feLocations, (bw, e));
				else
				{
					this.fireExtinguisherGotTaken = true;
					RunFromFire(grid, pos);
				}
			};

			bw.RunWorkerAsync();
		}

		private void CalculatePaths(Block[,] grid, Pair pos, Pair[] feLocations, (BackgroundWorker w, DoWorkEventArgs e) worker)
		{
			if (worker.w.CancellationPending)
				return;

			Pair[][] findPaths()
			{
				List<Pair[]> paths = new List<Pair[]>();

				foreach (var feLoc in feLocations)
				{
					if (worker.w.CancellationPending)
						return paths.ToArray();
					else
					{
						Pair[] val = null;

						try
						{
							val = new AStar(grid, pos, feLoc).aStarSearch();
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
						}

						if (val != null)
							paths.Add(val);
					}
				}

				return paths.ToArray();
			}

			this.pathIndex = 1;
			this.ShortestPath = findShortestPath(findPaths(), worker.w);
		}

		internal Task CalculatePaths(Block[,] grid, Pair pos, Pair[] feLocations, (BackgroundWorker w, DoWorkEventArgs e) worker, Action callback)
		{
			Person.feLocations = feLocations.ToArray();

			var task = Task.Run(() =>
			{
				this.CalculatePaths(grid, pos, feLocations, worker);
				callback();
			});

			return task;
		}

		public override void Function(Block[,] grid, int x, int y)
		{
			if (this.ShortestPath == null)
				throw new Exception("'ShortestPath' is not defined. You need to execute the 'CalculatePaths' method before animating!");

			if (this.IsDead)
			{
				foreach (Pair p in getSurrounding(grid, new Pair(x, y), typeof(Person)))
					((Person)grid[p.X, p.Y]).Kill();

				return;
			}

			if (this.fireExtinguisherGotTaken || this.ShortestPath.Length < 1)
				RunFromFire(grid, new Pair(x, y));
			else if (HasFireExtinguisher && pathIndex < this.nearestFirePath.Length)
				Move2Fire(grid, new Pair(x, y));
			else if (HasFireExtinguisher)
				ReachedFire(grid, new Pair(x, y));
			else if (pathIndex < this.ShortestPath.Length - 1)
				Move2FE(grid, new Pair(x, y));
			else if (firePathThread == null)
				CalculateFirePath(grid, new Pair(x, y));
		}

		#region Moving algorithms
		private void Move2Fire(Block[,] grid, Pair pos)
		{
			if (getSurrounding(grid, pos, typeof(Fire), safeDistance).Length <= 0)
			{
				move(grid, pos, this.nearestFirePath);

				if (hasReachedFireBefore)
					ReachedFire(grid, pos);
			}
			else
			{
				this.pathIndex = this.nearestFirePath.Length;
				hasReachedFireBefore = true;

				// Call self again, because otherwise this tick gets wasted
				this.Function(grid, pos.X, pos.Y);
			}
		}

		private void ReachedFire(Block[,] grid, Pair pos)
		{
			Pair[] tracePath(Pair start, Pair end)
			{
				List<Pair> paths = new List<Pair>();

				Pair findNext(Pair s)
				{
					int newX = s.X;
					int newY = s.Y;

					if (end.X > s.X)
						newX++;
					else if (end.X < s.X)
						newX--;
					if (end.Y > s.Y)
						newY++;
					if (end.Y < s.Y)
						newY--;

					return new Pair(newX, newY);
				}

				var next = findNext(start);
				var gridVal = grid[next.X, next.Y];
				while (
					next.X != end.X && next.Y != end.Y &&
					gridVal is Floor
				)
				{
					paths.Add(next);
					next = findNext(next);
				}

				return paths.ToArray();
			}

			var radiusSquared = Math.Pow(FireExtinguisher.SpreadRadius, 2);
			var fires = getSurrounding(grid, pos, typeof(Fire), FireExtinguisher.SpreadRadius, (int x, int y) =>
			{
				double dx = x - pos.X;
				double dy = y - pos.Y;
				double distanceSquared = dx * dx + dy * dy;

				return distanceSquared < radiusSquared;
			});

			foreach (Pair p in fires)
				grid[p.X, p.Y] = GridController.Floor;

			/* TODO: If there is no fire closeby, you can do a couple of things:
			 *	- Wait for the fire to spread within reach (Current strategy)
			 *	- Perform A* again
			 *	- Move around randomly (or maybe according to the previous position?)
			 *	- Check again in a bigger radius
			 */

			if (fires.Length < 10)
			{
				var avgPoint = getAveragePoint(fires);

				if (avgPoint == null)
					Console.WriteLine("No average point could be calculated");
				else
				{
					var path = tracePath(pos, avgPoint);

					if (path.Length <= 0)
					{
						if (firePathThread == Thread.CurrentThread)
						{
							Console.WriteLine("No path could be found using the custom algorithm. Recalculating...");
							calculateFirePathInDiffThread(grid, pos);
						}
					}
					else
					{
						this.nearestFirePath = path;
						this.pathIndex = 0;
					}
				}
			}
		}

		private void Move2FE(Block[,] grid, Pair pos)
		{
			var endPos = this.ShortestPath[this.ShortestPath.Length - 1];
			var checkForFire = getSurrounding(grid, pos, typeof(Fire), 2);

			if (checkForFire.Length > 0)
			{
				this.ShortestPath = new Pair[0];
				RunFromFire(grid, pos);
				return;
			}

			if (grid[endPos.X, endPos.Y] is FireExtinguisher)
				move(grid, pos, this.ShortestPath);
			else
				reCalculateFEPath(grid, pos);
		}

		private void CalculateFirePath(Block[,] grid, Pair myPosPair)
		{
			var index = this.ShortestPath.Length - 1;

			if (index < 0)
				return;

			var pos = this.ShortestPath[index];
			if (grid[pos.X, pos.Y] is FireExtinguisher)
			{
				grid[pos.X, pos.Y] = GridController.Floor;
				calculateFirePathInDiffThread(grid, myPosPair);
			}
		}

		// TODO: This algorithm can make the person stuck...
		private void RunFromFire(Block[,] grid, Pair pos)
		{
			var pointToRunAwayFrom = getAveragePoint(getSurrounding(grid, pos, typeof(Fire), 100)); // TODO: Make this smaller

			if (pointToRunAwayFrom != null)
			{
				var newXPos = pos.X;
				var newYPos = pos.Y;

				if (pointToRunAwayFrom.X > pos.X)
					newXPos--;
				else if (pointToRunAwayFrom.X < pos.X)
					newXPos++;

				if (pointToRunAwayFrom.Y > pos.Y)
					newYPos--;
				else if (pointToRunAwayFrom.Y < pos.Y)
					newYPos++;

				this.pathIndex = 0;
				if (grid[newXPos, newYPos] is Floor)
					move(grid, pos, new Pair[] { new Pair(newXPos, newYPos) });
				else if (grid[pos.X, newYPos] is Floor)
					move(grid, pos, new Pair[] { new Pair(pos.X, newYPos) });
				else if (grid[newXPos, pos.Y] is Floor)
					move(grid, pos, new Pair[] { new Pair(newXPos, pos.Y) });
			}
		}
		#endregion

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			hasReachedFireBefore = false;
			pathIndex = 1;
		}
	}
}
