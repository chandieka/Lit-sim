using System;

namespace Library
{
    public class Pair : IEquatable<Pair>
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
            => (this.X, this.Y);

        public bool Equals(Pair other)
            => this.X == other.X && this.Y == other.Y;

        public override string ToString()
            => $"({this.X}, {this.Y})";
    }
}
