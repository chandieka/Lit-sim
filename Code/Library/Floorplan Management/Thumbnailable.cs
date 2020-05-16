using System;
using System.Drawing;

namespace Library
{
	[Serializable]
	public class Thumbnailable : Grid
	{
		[field: NonSerialized]
		private Bitmap bitmap;

		public Thumbnailable(Block[,] grid)
			: base(grid) { }

		public Bitmap Render(int size)
		{
			if (bitmap == null)
				bitmap = Grid.Paint(this.grid, (size, size));

			return bitmap;
		}
	}
}
