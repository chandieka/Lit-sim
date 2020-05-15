using System;
using System.Collections.Generic;

namespace Library
{
	[Serializable]
	public class Floorplan : ISavable
	{
		private readonly List<Layout> layouts = new List<Layout>();
		public Guid Id { get; } = Guid.NewGuid();

		private readonly Block[,] grid;

		public Floorplan(Block[,] grid)
		{
			this.grid = grid;
		}

		public GridController ToGridController()
			=> new GridController(Grid.DeepCloneBlock(this.grid));

		public void AddLayout(Layout layout)
		{
			// TODO: if Find Duplicate -> return something
			if (layout != null)
				layouts.Add(layout);
		}

		public void RemoveLayout(Layout layout)
		{
			layouts.Remove(layout);
		}

		public Layout[] GetLayouts()
		{
			return layouts.ToArray();
		}

		public override string ToString()
		{
			return Id.ToString();
		}
	}
}
