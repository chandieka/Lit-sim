﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Block
    {
        public static readonly Block Empty = new Block();
        public static readonly Color color = Color.DarkGray;

        // block location
        public Tuple<int,int> Coordinate { get; set; }

        static Block()
        {

        }
    }
}
