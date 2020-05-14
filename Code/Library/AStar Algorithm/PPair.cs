using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public struct PPair
    {
        public readonly double First;
        public readonly Pair Second;

        public PPair(double one, Pair two)
        {
            this.Second = two;
            this.First = one;
        }
    }
}
