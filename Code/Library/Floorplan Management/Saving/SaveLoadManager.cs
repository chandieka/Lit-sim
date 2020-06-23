using System;
using System.Drawing;
using System.Drawing.Imaging;
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

			DeleteThumbnail(item);
			File.Delete(GetFilePath(item, true));
		}

		public static void SaveThumbnail(ISavable savable, Bitmap thumbnail)
		{
			try
			{
				thumbnail.Save(GetThumbnailPath(savable.Id), ImageFormat.Png);
			} catch (Exception e)
			{
				Console.WriteLine("Unable to save thumbnail!!!!");
				Console.WriteLine(e.Message);
			}
		}

		public static Image LoadThumbnail(ISavable savable)
		{
			var filePath = GetThumbnailPath(savable.Id);

			if (!File.Exists(filePath))
				return null;

			if (File.GetAttributes(filePath).HasFlag(FileAttributes.Directory))
				throw new Exception($"The passed path ({filePath}) results to a directory");

			return Image.FromFile(filePath);
		}

		public static void DeleteThumbnail(ISavable savable)
		{
			var path = GetThumbnailPath(savable.Id);

			if (File.Exists(path))
			{
				try
				{
					File.Delete(path);
				}
				catch (Exception) {
					Console.WriteLine($"Unable to delete '{path}'!");
				}
			}
		}

		public static string GetSaveFolder(Type type, bool shouldCheck = true)
		{
			if (type != null && type.GetInterface(typeof(ISavable).Name) == null)
				throw new Exception("Cannot get the SaveFolder from a non ISavable type");

			var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Lit", (type == null) ? "Thumbnails" : type.Name);

			if (shouldCheck)
			{
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);
			}

			return path;
		}

		public static string GetFilePath(Guid id, Type type, bool shouldCheck = true)
			=> Path.Combine(GetSaveFolder(type, shouldCheck), id + (type == null ? ".png" : FileExtension));

		public static string GetFilePath(ISavable item, bool shouldCheck = true)
			=> GetFilePath(item.Id, item.GetType(), shouldCheck);

		public static string GetThumbnailPath(Guid id)
			=> GetFilePath(id, null, true);
	}
}
