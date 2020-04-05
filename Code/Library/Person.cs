using System;
using System.Collections.Generic;
using System.Drawing;

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
}
