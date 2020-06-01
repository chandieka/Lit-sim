using System;

namespace Library
{
	[Serializable]
	public class SaveItem
	{
		public readonly ISavable Item;
		public readonly string Name;

		public SaveItem(ISavable saveItem, string name)
		{
			if (name.Trim().Length < 1)
				throw new Exception("Cannot save item with an empty name");

			this.Item = saveItem;
			this.Name = name;
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}
