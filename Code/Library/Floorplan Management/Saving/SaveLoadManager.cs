using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Library
{
	public class SaveLoadManager
	{
		public static string FileExtension = ".bin";

		public static void Save(SaveItem itm)
		{
			using (Stream stream = File.Open(CombinePath(itm.Item.Id), FileMode.Create))
				new BinaryFormatter().Serialize(stream, itm);
		}

		public static SaveItem Load(string filePath)
		{
			using (Stream stream = File.Open(filePath, FileMode.Open))
				return (SaveItem)new BinaryFormatter().Deserialize(stream);
		}

		public static void Delete(ISavable item)
		{
			File.Delete(CombinePath(item.Id));
		}

		public static void Delete(Guid id)
		{
			File.Delete(CombinePath(id));
		}

		public static string GetSaveFolder(bool shouldCheck = true)
		{
			var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Lit");

			if (shouldCheck)
			{
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);
			}

			return path;
		}

		private static string CombinePath(Guid id)
			=> Path.Combine(GetSaveFolder(false), id + FileExtension);
	}
}
