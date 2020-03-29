using System;
using System.Drawing;

namespace Library
{
    public class Block
    {
        public static readonly Block Empty = new Block();
        public static readonly Color Color = Color.DarkGray;

        // block location
        public Tuple<int,int> Coordinate { get; set; }

        static Block()
        {

        }
    }
}
