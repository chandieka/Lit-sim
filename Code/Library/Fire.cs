using System.Drawing;

namespace Library
{
    public class Fire : FunctionalBlock
    {
        public static new readonly Color color = Color.Red;

        public Fire() : base()
        {

        }

        public override void Function(Block[,] grid, int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}
