using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
                else
                    return Color.Blue;
            }
        }

        internal Pair[] ShortestPath { get; private set; }
        private int pathIndex = 1;

        private Pair[] nearestFirePath = null;

        public Boolean HasFireExtinguisher { get
            {
                return this.nearestFirePath != null;
            } 
        }

        public Person() : base() { }

        public void Kill()
        {
            this.IsDead = true;
        }

        // TODO: This does not work if a Person is in the way...
        private void move(Block[,] grid, Pair from, Pair[] pathArr)
        {
            var pathEntry = pathArr[pathIndex];

            if (grid[pathEntry.X, pathEntry.Y] is Floor)
            {
                grid[from.X, from.Y] = GridController.Floor;
                grid[pathEntry.X, pathEntry.Y] = this;
                pathIndex++;
            }
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

        /// <summary>
        /// Searches for a fire extinguisher within a square around the current position
        /// </summary>
        /// <returns></returns>
        private Pair findFireExtinguisherAround(Block[,] grid, Pair pos)
        {
            Block getAt(int x, int y)
            {
                if (x < 0 || x >= grid.GetLength(0) || y < 0 || y >= grid.GetLength(1))
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

            foreach (Pair p in positions)
            {
                var returnVal = getAt(p.X, p.Y);

                if (returnVal != null && returnVal is FireExtinguisher)
                    return p;
            }

            return null;
        }

        // TODO: Optimize this!
        private Pair[] findNearestFirePath(Block[,] grid, Pair pos)
        {
            Pair[] findFire()
            {
                List<Pair> positions = new List<Pair>();

                for (int x = 0; x < grid.GetLength(0); x++)
                    for (int y = 0; y < grid.GetLength(1); y++)
                        if (grid[x, y] is Fire)
                            positions.Add(new Pair(x, y));

                return positions.ToArray();
            }

            List<Pair[]> paths = new List<Pair[]>();

            foreach (Pair p in findFire())
            {
                var path = new AStar(grid, pos, p).aStarSearch();

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
                        } catch (Exception e)
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
            else
            {
                var myPosPair = new Pair(x, y);
                var pos = findFireExtinguisherAround(grid, myPosPair);

                if (pos != null)
                {
                    grid[pos.X, pos.Y] = GridController.Floor;

                    // TODO: Optimize this more!!
                    this.nearestFirePath = findNearestFirePath(grid, myPosPair);
                    pathIndex = 1;
                }
            }
        }
    }
}
