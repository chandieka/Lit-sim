﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Wall : Block
    {
        new public static readonly Color color = Color.Black;

        public Wall()
            : base()
        {

        }
    }
}