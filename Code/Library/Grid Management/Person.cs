using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
		private bool hasReachedFireBefore = false;
		[field: NonSerialized]
		private Pair[] nearestFirePath = null;
		[field: NonSerialized]
		private Thread firePathThread = null;
		private const int safeDistance = 5;

		public bool HasFireExtinguisher
		{
			get
			{
				return this.nearestFirePath != null;
			}
		}

		public void Kill()
		{
			this.IsDead = true;
			this.firePathThread?.Interrupt();
		}

		private void move(Block[,] grid, Pair from, Pair[] pathArr)
		{
			var pathEntry = pathArr[pathIndex];

			if (grid[pathEntry.X, pathEntry.Y] is Floor)
			{
				grid[from.X, from.Y] = GridController.Floor;
				grid[pathEntry.X, pathEntry.Y] = this;
				pathIndex++;
			}
			else if (grid[pathEntry.X, pathEntry.Y] is Person)
				pathIndex++;
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

		private Pair[] FindFurthestFirePath(Block[,] grid, Pair pos)
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

			Pair[] findEmpty(bool doCheck = true)
			{
				List<Pair> positions = new List<Pair>();
				Type floorType = typeof(Floor);

				for (int x = 0; x < grid.GetLength(0); x++)
					for (int y = 0; y < grid.GetLength(1); y++)
						if (!Thread.CurrentThread.IsAlive)
							return positions.ToArray();
						else if (grid[x, y] is Floor)
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
			var floors = findEmpty();

			(Pair block, int distance)? destination = null;
			foreach (Pair p in floors)
			{
				int shortestDistance = 0;

				foreach (Pair pf in fires)
				{
					var distance = new AStar(grid, p, pf).aStarSearch().Length;
					if (distance < shortestDistance) shortestDistance = distance;
				}

				if (destination == null)
					destination = (p, shortestDistance);
				else
					if (shortestDistance > destination.Value.distance)
					destination = (p, shortestDistance);
			}

			var path = new AStar(grid, pos, destination.Value.block).aStarSearch();

			if (path.Length > 0)
				return findShortestPath(paths.ToArray(), null);

			Console.WriteLine("For some reason there is no path to the fire???");
			return null;
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

			this.ShortestPath = findShortestPath(findPaths(), worker.w);
		}

		internal Task CalculatePaths(Block[,] grid, Pair pos, Pair[] feLocations, (BackgroundWorker w, DoWorkEventArgs e) worker, Action callback)
		{
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
				Fire.SpreadToNeighbors(grid, x, y);
				return;
			}

			if (HasFireExtinguisher && pathIndex < this.nearestFirePath.Length)
				Move2Fire(grid, new Pair(x, y));
			else if (HasFireExtinguisher)
				ReachedFire(grid, new Pair(x, y));
			else if (pathIndex < this.ShortestPath.Length - 1)
				Move2FE(grid, new Pair(x, y));
			else if (firePathThread == null)
				CalculateFirePath(grid, new Pair(x, y));
		}

		// Move algos
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
			Pair averagePoint(Pair[] points)
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
			 *	- Wait for the fire to spread within reach (This is the current strategy)
			 *	- Perform A* again
			 *	- Move around randomly (or maybe according to the previous position?)
			 *	- Check again in a bigger radius
			 */

			if (fires.Length < 10)
			{
				var avgPoint = averagePoint(fires);

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

		private void Move2FE(Block[,] grid, Pair pos) => move(grid, pos, this.ShortestPath);

		private void CalculateFirePath(Block[,] grid, Pair myPosPair)
		{
			var pos = this.ShortestPath[this.ShortestPath.Length - 1];

			if (grid[pos.X, pos.Y] is FireExtinguisher)
			{
				grid[pos.X, pos.Y] = GridController.Floor;
				calculateFirePathInDiffThread(grid, myPosPair);
			}
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

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			hasReachedFireBefore = false;
			pathIndex = 1;
		}
	}
}
