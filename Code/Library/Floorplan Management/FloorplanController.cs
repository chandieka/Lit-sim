using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class FloorplanController
    {
        private List<Floorplan> FloorPlans;

        public FloorplanController()
        {
            FloorPlans = new List<Floorplan>();
        }

        public void AddFloorPlan(Floorplan floorplan)
        {
            if (floorplan != null)
            {
                // TODO: Find Duplicate -> return something ?? throw Exception ??
                FloorPlans.Add(floorplan);
            }
        }

        public void RemoveFloorPlan(Floorplan floorplan)
        {
            if (floorplan != null)
            {
                FloorPlans.Remove(floorplan);
            }
        }

        public Floorplan[] GetFloorPlans()
        {
            return FloorPlans.ToArray();
        }

        //public bool RemoveLayoutFromFloorplan(Floorplan floorplan, Layout layout)
        //{
        //    return false;
        //}
    }
}
