using System;
using System.Collections.Generic;
using System.Drawing;

namespace Library
{
    [Serializable]
    public class Wall : Block
    {
        new public static readonly Color Color = Color.Black;

        public Wall()
            : base()
        { }
    }
}
