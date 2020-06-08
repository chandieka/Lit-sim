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

		public bool IsDeletable => LayoutAmount <= 0;
		public int LayoutAmount => layouts.Count;

		public Floorplan(Block[,] grid)
			: base(grid) { }

		public GridController ToGridController()
			=> new GridController(this.Clone());

		public void AddLayout(Guid layout)
		{
			if (layouts.Contains(layout))
				throw new Exception("Cannot add Layout multiple times");

			layouts.Add(layout);
		}

		public void RemoveLayout(Guid layout)
			=> layouts.Remove(layout);

		public void DeleteAllChildren()
		{
			for (int i = layouts.Count - 1; i >= 0; i--)
			{
				var child = layouts[i];
				var layout = GetLayout(child).Item;

				layout.DeleteAllChildren();
				SaveLoadManager.Delete(layout);
				RemoveLayout(child);
			}
		}

		public Guid[] GetGuids()
		{
			return layouts.ToArray();
		}

		public SaveItem GetLayout(Guid id)
		{
			return SaveLoadManager.Load(SaveLoadManager.GetFilePath(id, typeof(Layout), false));
		}

		public SaveItem GetLayoutAt(int index)
		{
			if (index >= 0 && index < layouts.Count)
				return GetLayout(layouts[index]);

			return null;
		}

		public SaveItem[] GetAllLayouts(bool skipNotFound = false)
		{
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

			items.Reverse();
			return items.ToArray();
		}

		public override string ToString()
			=> Id.ToString();
	}
}
