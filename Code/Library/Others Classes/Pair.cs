using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Pair
    {
        public readonly int X, Y;

        public Pair(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Pair((int x, int y) tuple)
        {
            this.X = tuple.x;
            this.Y = tuple.y;
        }

        public (int X, int Y) ToTuple()
        {
            return (this.X, this.Y);
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }
    }
}
