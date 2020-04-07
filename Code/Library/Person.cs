using System;
using System.Collections.Generic;
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

        public Person() : base() { }

        public void Kill()
        {
            this.IsDead = true;
        }

        private void CalculatePaths(Block[,] grid, CancellationToken ct, Pair pos, Pair[] feLocations)
        {
            ct.ThrowIfCancellationRequested();

            Pair[][] findPaths()
            {
                List<Pair[]> paths = new List<Pair[]>();

                foreach (var feLoc in feLocations)
                {
                    if (ct.IsCancellationRequested)
                        return paths.ToArray();
                    else
                    {
                        var val = new AStar(grid, pos, feLoc).aStarSearch();
                        paths.Add(val);
                    }
                }

                return paths.ToArray();
            }

            Pair[] findShortest(Pair[][] paths)
            {
                Pair[] shortest = null;

                foreach (Pair[] p in paths)
                    if (ct.IsCancellationRequested)
                        return null;
                    else if (shortest == null || p.Length < shortest.Length)
                        shortest = p;

                return shortest;
            }

            this.ShortestPath = findShortest(findPaths());
        }

        internal (CancellationTokenSource token, Task task) CalculatePaths(Block[,] grid, Pair pos, Pair[] feLocations)
        {
            var tokenSource = new CancellationTokenSource();
            CancellationToken ct = tokenSource.Token;

            var task = Task.Run(() =>
            {
                this.CalculatePaths(grid, ct, pos, feLocations);
            }, tokenSource.Token);

            return (tokenSource, task);
        }

        public override void Function(Block[,] grid, int x, int y)
        {
            if (this.ShortestPath == null)
                throw new Exception("'ShortestPath' is not defined. You need to execute the 'CalculatePaths' method before animating!");

            if (pathIndex < this.ShortestPath.Length - 1)
            {
                var pathEntry = this.ShortestPath[pathIndex];

                if (grid[pathEntry.X, pathEntry.Y] is Floor)
                {
                    grid[x, y] = GridController.Floor;
                    grid[pathEntry.X, pathEntry.Y] = this;
                    pathIndex++;
                }
            }
        }

        /* TODO: This is super buggy:
            - Two people sometimes move to the same location
            - The person stops when it is diagonally near (can be a feature)
            - Nothing happens when a person reaches an extinguisher
            - A person does not regard a fire (just walks right into it)
            - A person does not regard walls...
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
        */

        /* TODO: This could be optimized by calculating this once at start up
        private static (int x, int y) GetNearestFireExtinguisher(Block[,] grid, (int x, int y) location)
        {
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
        */
    }
}
