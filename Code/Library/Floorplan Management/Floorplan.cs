using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Floorplan
    {
        public readonly Guid Id = Guid.NewGuid();
        public Block[,] Grid { get; private set; }
        public List<Layout> Layouts { get; private set; }

        public Floorplan(Block[,] grid)
        {
            this.Grid = grid;
            Layouts = new List<Layout>();
        }

        public void AddLayout(Layout layout)
        {
            // TODO: if Find Duplicate -> return something
            if (layout != null)
                Layouts.Add(layout);
        }

        public void RemoveLayoutById(Layout layout)
        {
            if (layout != null)
                Layouts.Remove(layout);
        }
    }
}
