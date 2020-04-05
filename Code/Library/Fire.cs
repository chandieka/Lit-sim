using System;
using System.Drawing;

namespace Library
{
    public class Fire : FunctionalBlock
    {
        private static readonly Random random = new Random();
        public static new readonly Color Color = Color.Red;

        public Fire() : base() { }

        public override void Function(Block[,] grid, int x, int y)
        {
            void putFire(int locX, int locY)
            {
                // check if the location is within the grid
                var xMin = 0;
                var xMax = grid.GetLength(0);
                var yMin = 0;
                var yMax = grid.GetLength(1);

                if (locX < xMin || locX >= xMax)
                    return;
                if (locY < yMin || locY >= yMax)
                    return;

                // check if the unit that would be replaced is a floor or a person
                if (grid[locX, locY] is Floor) grid[locX, locY] = new Fire();
                if (grid[locX, locY] is Person) ((Person)grid[locX, locY]).Kill();
            }

            // place a fire at random, the default probability of it being placed is 5%
            void maybePutFire(int locX, int locY, double probability = .05d)
            {
                if (random.NextDouble() < probability)
                    putFire(locX, locY);
            }

            // cycle through the neigboring blocks of the given spot
            for (int xOffset = -1; xOffset <= 1; xOffset++)
                maybePutFire(x + xOffset, y);
            for (int yOffset = -1; yOffset <= 1; yOffset++)
                maybePutFire(x, y + yOffset);
        }
    }
}
