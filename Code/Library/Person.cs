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

        public Person() : base() { }

        public void Kill()
        {
            this.IsDead = true;
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

            Pair[] findShortest(Pair[][] paths)
            {
                Pair[] shortest = null;

                foreach (Pair[] p in paths)
                    if (worker.w.CancellationPending)
                        return shortest;
                    else if (shortest == null || p.Length < shortest.Length)
                        shortest = p;

                return shortest;
            }

            this.ShortestPath = findShortest(findPaths());
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
    }
}
