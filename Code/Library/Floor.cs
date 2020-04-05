using System;
using System.Drawing;

namespace Library
{
    [Serializable]
    public class Floor : Block
    {
        new public static readonly Color Color = Color.White;

        public Floor() : base() { }
    }
}
