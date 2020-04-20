using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
<<<<<<< HEAD
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
				else
					return Color.Blue;
			}
		}

		internal Pair[] ShortestPath { get; private set; }
		private int pathIndex = 1;

		private Pair[] nearestFirePath = null;
		private Thread firePathThread = null;

		public bool HasFireExtinguisher
		{
			get
			{
				return this.nearestFirePath != null;
			}
		}

		public Person() : base() { }

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

		private Pair[] getSurrounding(Block[,] grid, Pair pos, Type typeToCheck = null)
		{
			Block getAt(int x, int y)
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

			Pair[] positions = new Pair[] {
					new Pair(pos.X - 1, pos.Y - 1),
					new Pair(pos.X, pos.Y - 1),
					new Pair(pos.X + 1, pos.Y - 1),

					new Pair(pos.X - 1, pos.Y),
					new Pair(pos.X + 1, pos.Y),

					new Pair(pos.X - 1, pos.Y + 1),
					new Pair(pos.X, pos.Y + 1),
					new Pair(pos.X + 1, pos.Y + 1),
				};

			List<Pair> pairs = new List<Pair>();
			foreach (Pair p in positions)
			{
				var returnVal = getAt(p.X, p.Y);

				if (returnVal != null)
				{
					if (typeToCheck != null && returnVal.GetType() == typeToCheck)
						pairs.Add(p);
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
			bool hasAtLeastOneFloorSurrounding(Pair position)
			{
				return getSurrounding(grid, position, typeof(Floor)).Length > 0;

				Block getAt(int x, int y)
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

				Pair[] positions = new Pair[] {
					new Pair(position.X - 1, position.Y - 1),
					new Pair(position.X, position.Y - 1),
					new Pair(position.X + 1, position.Y - 1),

					new Pair(position.X - 1, position.Y),
					new Pair(position.X + 1, position.Y),

					new Pair(position.X - 1, position.Y + 1),
					new Pair(position.X, position.Y + 1),
					new Pair(position.X + 1, position.Y + 1),
				};

				foreach (Pair p in positions)
				{
					var returnVal = getAt(p.X, p.Y);

					if (returnVal != null && returnVal is Floor)
						return true;
				}

				return false;
			}

			Pair[] findFire(bool doCheck = true)
			{
				List<Pair> positions = new List<Pair>();

				for (int x = 0; x < grid.GetLength(0); x++)
					for (int y = 0; y < grid.GetLength(1); y++)
						if (!Thread.CurrentThread.IsAlive)
							return positions.ToArray();
						else if (grid[x, y] is Fire)
						{
							Pair p = new Pair(x, y);

							if (doCheck == false || hasAtLeastOneFloorSurrounding(p))
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
				} catch (Exception e) {
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

			if (HasFireExtinguisher && pathIndex < this.nearestFirePath.Length - 1)
				move(grid, new Pair(x, y), this.nearestFirePath);
			else if (pathIndex < this.ShortestPath.Length - 1)
				move(grid, new Pair(x, y), this.ShortestPath);
			else if (firePathThread == null)
			{
				var pos = this.ShortestPath[this.ShortestPath.Length - 1];

				if (grid[pos.X, pos.Y] is FireExtinguisher)
				{
					var myPosPair = new Pair(x, y);

					grid[pos.X, pos.Y] = GridController.Floor;
					firePathThread = new Thread(() =>
					{
						this.nearestFirePath = findNearestFirePath(grid, myPosPair);
						pathIndex = 1;

						firePathThread = Thread.CurrentThread;// Set to something not null
					});
					firePathThread.Start();
				}
			}
		}
	}
=======
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
                else
                    return Color.Blue;
            }
        }

        public Person()
            : base()
        { }

        public void Kill()
        {
            this.IsDead = true;
        }

        // This could be optimized by calculating this once at start up
        private static (int x, int y) GetNearestFireExtinguisher(Block[,] grid, (int x, int y) location)
        {
            // This should be optimized by calculating this only once every loop
            (int x, int y)[] getFireExtinguisers()
            {
                List<(int x, int y)> list = new List<(int x, int y)>();

                for (int x = 0; x < grid.GetLength(0); x++)
                    for (int y = 0; y < grid.GetLength(1); y++)
                        if (grid[x, y] is FireExtinguisher)
                            list.Add((x, y));

                return list.ToArray();
            }
            double calcDist((int x, int y) person, (int x, int y) fe)
            {
                return Math.Sqrt(Math.Pow(person.x - fe.x, 2) + Math.Pow(person.y - fe.y, 2));
            }

            var extinguishers = getFireExtinguisers();
            Tuple<(int x, int y), double> n = null;
            for (int i = 0; i < extinguishers.Length; i++)
            {
                var dist = calcDist(location, extinguishers[i]);

                if (n == null || n.Item2 > dist)
                    n = new Tuple<(int x, int y), double>(extinguishers[i], dist);
            }

            return n.Item1;
        }

        /* TODO: This is super buggy:
            - Two people sometimes move to the same location
            - The person stops when it is diagonally near (can be a feature)
            - Nothing happens when a person reaches an extinguisher
            - A person does not regard a fire (just walks right into it)
            - A person does not regard walls...
        */
        public override void Function(Block[,] grid, int x, int y)
        {
            if (!IsDead)
            {
                void tryMove((int x, int y) loc)
                {
                    if (loc.x >= 0 && loc.y >= 0 && grid[loc.x, loc.y] == GridController.Floor)
                    {
                        grid[x, y] = GridController.Floor;
                        grid[loc.x, loc.y] = this;
                    }
                }

                var pos = GetNearestFireExtinguisher(grid, (x, y));
                int newX = x;
                int newY = y;

                if (pos.x > x)
                    newX++;
                else if (pos.x < x)
                    newX--;
                if (pos.y > y)
                    newY++;
                if (pos.y < y)
                    newY--;

                tryMove((newX, newY));
            }
        }
    }
>>>>>>> origin/feature-designer
}
