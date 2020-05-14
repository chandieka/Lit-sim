using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public struct Cell
    {
        // Row and Column index of its parent 
        // Note that 0 <= i <= ROW-1 & 0 <= j <= COL-1 
        public int parent_i, parent_j;
        // f = g + h 
        public double f, g, h;
    }
}
