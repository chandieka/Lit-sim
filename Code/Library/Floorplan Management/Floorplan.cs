using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library
{
	[Serializable]
	public class Floorplan : Grid, ISavable
	{
		private readonly List<Guid> layouts = new List<Guid>();
		public Guid Id { get; } = Guid.NewGuid();

		[field: NonSerialized]
		private List<SaveItem> parsedLayouts = new List<SaveItem>();

		// Used to check if the 'layouts' list was changed after the 'parsedLayouts' list was updated
		private bool parsedLayoutsListIsDirty = true;

		public Floorplan(Block[,] grid)
			: base(grid) { }

		public GridController ToGridController()
			=> new GridController(Grid.DeepCloneBlock(this.grid));

		public void AddLayout(Guid layout)
		{
			// TODO: if Find Duplicate -> return something
			layouts.Add(layout);
			parsedLayoutsListIsDirty = true;
		}

		public void RemoveLayout(Guid layout)
		{
			parsedLayouts.RemoveAt(parsedLayouts.FindIndex(_ => _.Item.Id == layout));
			layouts.Remove(layout);
		}

		public Guid[] GetGuids()
		{
			return layouts.ToArray();
		}

		public SaveItem GetLayout(Guid id)
		{
			var foundLayout = parsedLayouts.Find(_ => _.Item.Id == id);

			if (foundLayout != null)
				return foundLayout;
			else
			{
				SaveItem saveItem = SaveLoadManager.Load(SaveLoadManager.GetFilePath(id, typeof(Layout), false));
				parsedLayouts.Add(saveItem);
				return saveItem;
			}
		}

		public SaveItem GetLayoutAt(int index)
		{
			if (index >= 0 && index < layouts.Count)
				return GetLayout(layouts[index]);

			return null;
		}

		public SaveItem[] GetAllLayouts()
		{
			if (!parsedLayoutsListIsDirty)
				return parsedLayouts.ToArray();

			SaveItem[] items = new SaveItem[layouts.Count];

			for (int i = 0; i < layouts.Count; i++)
				items[i] = GetLayout(layouts[i]);

			parsedLayoutsListIsDirty = false;
			return items;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			this.parsedLayouts = new List<SaveItem>();
		}

		public override string ToString()
		{
			return Id.ToString();
		}
	}
}
