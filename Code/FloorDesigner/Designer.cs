using Library;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloorDesigner
{
	public partial class Designer : Form
	{
		private Tuple<int, int> prevCurPos;
		private GridController grid;

		public Designer(int width, int height)
		{
			grid = new GridController((width, height));
			InitializeComponent();
		}

		private (int Width, int Height) getSizePerPixel()
		{
			return (pictureBoxGrid.Width / grid.GridWidth, pictureBoxGrid.Height / grid.GridHeight);
		}

		private (int Width, int Height) getMaxSize()
		{
			var sizePixel = getSizePerPixel();
			return (sizePixel.Width * grid.GridWidth, sizePixel.Height * grid.GridHeight);
		}

		private void drawGrid(Graphics g)
		{
			var sizePerPixel = getSizePerPixel();
			var maxSize = getMaxSize();

			for (int x = 0; x <= grid.GridWidth; x++)
			{
				int pos = x * sizePerPixel.Width;
				g.DrawLine(Pens.Black, pos, 0, pos, maxSize.Height);
			}

			for (int y = 0; y <= grid.GridHeight; y++)
			{
				int pos = y * sizePerPixel.Height;
				g.DrawLine(Pens.Black, 0, pos, maxSize.Width, pos);
			}
		}

		private void drawBitmap(Graphics g)
		{
			var bitmap = grid.Paint(getSizePerPixel());
			var maxSize = getMaxSize();

			g.DrawImage(bitmap, 0, 0, maxSize.Width, maxSize.Height);
		}

		private (int x, int y) getGridPosFromPbPos(int x, int y)
		{
			var sizePerPixel = getSizePerPixel();
			var maxSize = getMaxSize();

			int yVal = y / sizePerPixel.Height;
			int xVal = x / sizePerPixel.Width;

			if (xVal > maxSize.Width || yVal > maxSize.Height)
				throw new IndexOutOfRangeException();

			return (xVal, yVal);
		}

		private void pictureBoxGrid_Paint(object sender, PaintEventArgs e)
		{
			drawBitmap(e.Graphics);
			drawGrid(e.Graphics);
		}

		private void pictureBoxGrid_Resize(object sender, EventArgs e)
		{
			pictureBoxGrid.Invalidate();
		}

		private void pictureBoxGrid_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				var pos = getGridPosFromPbPos(e.X, e.Y);

				if (rbFloor.Checked)
				{
					if (prevCurPos == null)
						prevCurPos = new Tuple<int, int>(pos.x, pos.y);
					else
					{
						grid.FillFloor((prevCurPos.Item1, prevCurPos.Item2), pos.x - prevCurPos.Item1 + 1, pos.y - prevCurPos.Item2 + 1);
						prevCurPos = null;
					}
				}
				else if (grid.GetAt(pos) is Floor)
				{
					if (rbFire.Checked)
						grid.PutFire(pos);
					else if (rbPerson.Checked)
						grid.PutPerson(pos);
				}

				pictureBoxGrid.Invalidate();
			} catch (Exception) { }
		}
	}
}
