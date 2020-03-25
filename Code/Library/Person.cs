using System.Drawing;

namespace Library
{
    public class Person : FunctionalBlock
    {
        new public static readonly Color color = Color.Blue;

        //public override Func<Block[,], Block[,]> Function => _ => _; // TODO

        public Person(Tuple<int, int> coordinate)
            : base()
        {
            this.Coordinate = coordinate;
        }

        public override void Function(Block[,] grid, int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}
