using System;

namespace Library.Saving
{
	[Serializable]
	public class SaveItem
	{
		public readonly ISavable Item;
		public readonly string Name;

		public SaveItem(ISavable saveItem, string name)
		{
			this.Item = saveItem;
			this.Name = name;
		}
	}
}
