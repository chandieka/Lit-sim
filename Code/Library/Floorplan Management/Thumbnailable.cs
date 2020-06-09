using System;
using System.Drawing;

namespace Library
{
	[Serializable]
	public class Thumbnailable : Grid
	{
		public Thumbnailable(Block[,] grid)
			: base(grid)
		{
			if (!(this is ISavable))
				throw new Exception("Thumbnailable cannot be inherited by classes that are not ISavable");
		}

		public static bool CheckMaxSize(Size size)
			=> size.Width < 1024 && size.Height < 1024; // Power of 4

		public Image Render(int size)
		{
			var savedThumbnail = SaveLoadManager.LoadThumbnail((ISavable)this);

			if (savedThumbnail != null)
				return savedThumbnail;
			else if (!CheckMaxSize(new Size(size, size)))
				throw new Exception("Thumbnail size is too large");
			else
			{
				var thumbnail = Grid.Paint(this.grid, (size, size));

				SaveLoadManager.SaveThumbnail((ISavable)this, thumbnail);
				return thumbnail;
			}
		}
	}
}
