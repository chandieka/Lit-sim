using System;
using System.Drawing;

namespace Library
{
    public class Person : FunctionalBlock
    {
        new public static readonly Color color = Color.Blue;

        public Person()
            : base()
        { }

        public override void Function(Block[,] grid, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
