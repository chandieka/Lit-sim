using System;
using System.Collections.Generic;

namespace Library
{
	[Serializable]
	public class Floorplan : Grid, ISavable
	{
		private readonly List<Guid> layouts = new List<Guid>();
		public Guid Id { get; } = Guid.NewGuid();

		public Floorplan(Block[,] grid)
			: base(grid) { }

		public GridController ToGridController()
			=> new GridController(Grid.DeepCloneBlock(this.grid));

		public void AddLayout(Guid layout)
		{
			// TODO: if Find Duplicate -> return something
			layouts.Add(layout);
		}

		public void RemoveLayout(Guid layout)
		{
			layouts.Remove(layout);
		}

		public Guid[] GetGuids()
		{
			return layouts.ToArray();
		}

		public Layout GetLayout(Guid id)
		{
			// TODO
			return null;
		}

		public override string ToString()
		{
			return Id.ToString();
		}
	}
}
