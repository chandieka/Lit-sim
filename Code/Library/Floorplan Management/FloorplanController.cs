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
			foreach (var itm in saveItems)
				if (itm.Item == floorplan)
					saveItems.Remove(itm);
		}

		public SaveItem[] GetAll()
		{
			return saveItems.ToArray();
		}

		public Floorplan[] GetFloorplans()
		{
			return saveItems.ConvertAll<Floorplan>(_ => (Floorplan)_.Item).ToArray();
		}
	}
}
