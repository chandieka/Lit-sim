using System;
using System.Drawing;

namespace Library
{
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

        public override void Function(Block[,] grid, int x, int y)
        {
            if (!IsDead)
            {
                if (x - 1 > 0 && grid[x - 1, y] == GridController.Floor)
                {
                    grid[x, y] = GridController.Floor;
                    grid[x - 1, y] = this;
                }
            }
        }
    }
}
