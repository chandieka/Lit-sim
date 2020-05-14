using System;
using System.Collections.Generic;

namespace Library
{
	[Serializable]
	public class Floorplan : ISavable
	{
		public List<Layout> Layouts { get; private set; }
		public Block[,] Grid { get; private set; }
		public Guid Id { get; } = Guid.NewGuid();

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

        public Layout[] GetLayouts()
        {
            return Layouts.ToArray();
        }
	}
}
