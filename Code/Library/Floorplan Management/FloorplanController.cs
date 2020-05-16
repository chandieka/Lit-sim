using System.Collections.Generic;

namespace Library
{
	public class FloorplanController
	{
		private List<SaveItem> saveItems;

		public FloorplanController()
		{
			this.saveItems = new List<SaveItem>();
		}

		public void Add(SaveItem savable)
		{
			// TODO: Find Duplicate -> return something ?? throw Exception ??

			if (savable != null && savable.Item is Floorplan)
				saveItems.Add(savable);
		}

		public void Remove(SaveItem saveItem)
		{
			saveItems.Remove(saveItem);
		}

		public void Remove(Floorplan floorplan)
		{
			for (int i = saveItems.Count - 1; i >= 0; i--)
			{
				var itm = saveItems[i];
				if (itm.Item == floorplan)
					saveItems.Remove(itm);
			}
		}

		public SaveItem[] GetAll()
		{
			return saveItems.ToArray();
		}

		public SaveItem GetAt(int index)
			=> saveItems[index];

		public Floorplan[] GetFloorplans()
		{
			return saveItems.ConvertAll<Floorplan>(_ => (Floorplan)_.Item).ToArray();
		}

		public Floorplan GetFloorplanAt(int index)
			=> (Floorplan)saveItems[index].Item;
	}
}
