using System;
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

        public List<Tuple<int, int>> EmptyNeighbors { get; set; }

        public Wall(Tuple<int,int> coordinate)
            : base()
        {
            EmptyNeighbors = new List<Tuple<int, int>>();
            this.Coordinate = coordinate;
        }
    }
}
