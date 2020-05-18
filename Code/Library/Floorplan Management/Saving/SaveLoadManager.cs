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
			using (Stream stream = File.Open(GetFilePath(itm.Item), FileMode.Create))
				new BinaryFormatter().Serialize(stream, itm);
		}

		public static SaveItem Load(string filePath)
		{
			if (File.GetAttributes(filePath).HasFlag(FileAttributes.Directory))
				throw new Exception($"The passed path ({filePath}) results to a directory");

			using (Stream stream = File.Open(filePath, FileMode.Open))
				return (SaveItem)new BinaryFormatter().Deserialize(stream);
		}

		public static void Delete(ISavable item)
		{
			if (!item.IsDeletable)
				throw new Exception("Cannot delete ISavable with children");

			File.Delete(GetFilePath(item));
		}

		public static void Delete(Guid id, Type type)
			=> File.Delete(GetFilePath(id, type, false));

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

		public static string GetFilePath(Guid id, Type type, bool shouldCheck = true)
			=> Path.Combine(GetSaveFolder(type, shouldCheck), id + FileExtension);

		public static string GetFilePath(ISavable item, bool shouldCheck = true)
			=> GetFilePath(item.Id, item.GetType(), shouldCheck);
	}
}
