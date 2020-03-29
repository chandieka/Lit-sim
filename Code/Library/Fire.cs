using System.Drawing;

namespace Library
{
    public class Fire : FunctionalBlock
    {
        public static new readonly Color Color = Color.Red;

        public Fire() : base() { }

        public override void Function(Block[,] grid, int x, int y)
        {
            void putFire(int locX, int locY)
            {
                // Somebody needs to check this =P
                if (locX >= 0 && locY >= 0 && locX < grid.GetLength(0) && locY < grid.GetLength(1))
                {
                    // Only if the space is empty, a fire can be placed
                    if (grid[locX, locY] == GridController.Floor)
                        grid[locX, locY] = GridController.Fire;
                    // If the space is occupied by a person, they are dead now
                    else if (grid[locX, locY] is Person)
                        ((Person)grid[locX, locY]).Kill();
                }
            }

            /* Get all the blocks surrounding the block */
            // Top row
            putFire(x - 1, y - 1);
            putFire(x, y - 1);
            putFire(x + 1, y + 1);

            // Middle row
            putFire(x - 1, y);
            putFire(x + 1, y);

            // Bottom row
            putFire(x - 1, y + 1);
            putFire(x, y + 1);
            putFire(x + 1, y + 1);
        }
    }
}
