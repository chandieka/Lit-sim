using System.Collections.Generic;

namespace Library
{
	public class Floorplan
	{
		public List<Layout> Layouts { get; private set; }
		public Block[,] Grid { get; private set; }

		public Floorplan(Block[,] grid)
		{
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
