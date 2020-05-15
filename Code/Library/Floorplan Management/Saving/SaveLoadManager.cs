using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Library
{
	public static class SaveLoadManager
	{
		public static string FileExtension = ".bin";

		public static void Save(SaveItem itm)
		{
			using (Stream stream = File.Open(CombinePath(itm.Item), FileMode.Create))
				new BinaryFormatter().Serialize(stream, itm);
		}

		public static SaveItem Load(string filePath)
		{
			using (Stream stream = File.Open(filePath, FileMode.Open))
				return (SaveItem)new BinaryFormatter().Deserialize(stream);
		}

		public static void Delete(ISavable item)
			=> File.Delete(CombinePath(item));

		public static string GetSaveFolder(Type type, bool shouldCheck = true)
		{
			if (type.GetInterface(typeof(ISavable).Name) == null)
				throw new Exception("Cannot get the SaveFolder from a non ISavable type");

			var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Lit", type.Name);

			if (shouldCheck)
			{
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);
			}

			return path;
		}

		public static string GetSaveFolder(ISavable savable)
			=> GetSaveFolder(savable.GetType(), true);

		private static string CombinePath(ISavable item)
			=> Path.Combine(GetSaveFolder(item), item.Id + FileExtension);
	}
}
