using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library
{
	[Serializable]
	public class Floorplan : Thumbnailable, ISavable
	{
		private readonly List<Guid> layouts = new List<Guid>();
		public Guid Id { get; } = Guid.NewGuid();

		[field: NonSerialized]
		private List<SaveItem> parsedLayouts = new List<SaveItem>();

		// Used to check if the 'layouts' list was changed after the 'parsedLayouts' list was updated
		private bool parsedLayoutsListIsDirty = true;

		public bool IsDeletable => LayoutAmount <= 0;
		public int LayoutAmount => layouts.Count;

		public Floorplan(Block[,] grid)
			: base(grid) { }

		public GridController ToGridController()
			=> new GridController(Grid.DeepCloneBlock(this.grid));

		public void AddLayout(Guid layout)
		{
			if (layouts.Contains(layout))
				throw new Exception("Cannot add Layout multiple times");

			layouts.Add(layout);
			parsedLayoutsListIsDirty = true;
		}

		public void RemoveLayout(Guid layout)
		{
			parsedLayouts.RemoveAt(parsedLayouts.FindIndex(_ => _.Item.Id == layout));
			layouts.Remove(layout);
		}

		public void DeleteAllChildren()
		{
			for (int i = layouts.Count - 1; i >= 0; i--)
			{
				var child = layouts[i];

				SaveLoadManager.Delete(child, typeof(Layout));
				RemoveLayout(child);
			}
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

		public SaveItem[] GetAllLayouts(bool skipNotFound = false)
		{
			if (!parsedLayoutsListIsDirty)
				return parsedLayouts.ToArray();

			List<SaveItem> items = new List<SaveItem>();

			for (int i = layouts.Count - 1; i >= 0; i--)
			{
				if (!skipNotFound)
					items.Add(GetLayout(layouts[i]));
				else
				{
					try
					{
						items.Add(GetLayout(layouts[i]));
					}
					catch (System.IO.FileNotFoundException)
					{
						Console.WriteLine($"Warning!: Could not find child Layout! ({layouts[i]})");
						this.layouts.RemoveAt(i);
					}
				}
			}

			parsedLayoutsListIsDirty = false;
			items.Reverse();
			return items.ToArray();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			this.parsedLayouts = new List<SaveItem>();
		}

		public override string ToString()
			=> Id.ToString();
	}
}
