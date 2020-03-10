﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class FunctionalBlock : Block
    {
        public abstract Func<Block[,], Block[,]> Function { get; }
    }
}