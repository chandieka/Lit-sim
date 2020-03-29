using System.Drawing;
using System.Linq;

namespace Library
{
    public class Fire : FunctionalBlock
    {
        public static new readonly Color color = Color.Red;

        public Fire() : base()
        { }

        public override void Function(Block[,] grid, int x, int y)
        {
            void TrySpreadTo((int x, int y) location)
            {
                var blockType = grid[x, y].GetType();
                var unSpreadable = new[] { typeof(Wall), Block.Empty.GetType() };

                if (!unSpreadable.Contains(blockType))
                    grid[x, y] = new Fire();
            }

            if (x > 1)
            {
                TrySpreadTo((x - 1, y));
            }
            if (y > 1)
            {
                TrySpreadTo((x, y - 1));
            }
            if (x < grid.GetLength(0) - 1)
            {
                TrySpreadTo((x + 1, y));
            }
            if (y < grid.GetLength(1) - 1)
            {
                TrySpreadTo((x, y + 1));
            }
        }
    }
}
