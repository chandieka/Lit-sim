using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Library
{
	public class SaveLoadManager
	{
		public static readonly string FilePrefix = "Lit-";

		public static void Save(SaveItem itm)
		{
			using (Stream stream = File.Open(Path.Combine(GetSaveFolder(), FilePrefix + itm.Item.Id), FileMode.Create))
				new BinaryFormatter().Serialize(stream, itm);
		}

		public static SaveItem Load(string filePath)
		{
			using (Stream stream = File.Open(filePath, FileMode.Open))
				return (SaveItem)new BinaryFormatter().Deserialize(stream);
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
	}
}
