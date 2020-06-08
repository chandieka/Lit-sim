using System;
using System.Drawing;

namespace Library
{
	[Serializable]
	public class Thumbnailable : Grid
	{
		public Thumbnailable(Block[,] grid)
			: base(grid) { }

		public Bitmap Render(int size)
			=> Grid.Paint(this.grid, (size, size));
	}
}
