using Library;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloorDesigner
{
	public partial class Designer : Form
	{
		private GridController grid;
		private string prevSaveLoc;
		private Pair prevCurPos;
		private Pair curCurPos;

		private Brush erasorBrush = new SolidBrush(Color.FromArgb(120, Color.Salmon));

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

		private Pair getGridPosFromPbPos(int x, int y)
		{
			var sizePerPixel = getSizePerPixel();
			var maxSize = getMaxSize();

			int yVal = y / sizePerPixel.Height;
			int xVal = x / sizePerPixel.Width;

			if (xVal > maxSize.Width || yVal > maxSize.Height || xVal > grid.GridWidth - 1 || yVal > grid.GridHeight - 1)
				return null;
			
			return new Pair(xVal, yVal);
		}

		private void drawGrid(Graphics g)
		{
			var sizePerPixel = getSizePerPixel();
			var maxSize = getMaxSize();

			int k = 0;

			for (int x = 0; x <= grid.GridWidth; x++)
			{
				int pos = x * sizePerPixel.Width;
				g.DrawLine(Pens.Black, pos, 0, pos, maxSize.Height);

				k += pos;
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

		private void drawSample(Graphics g)
		{
			var sizePerPixel = getSizePerPixel();

			if (prevCurPos != null && curCurPos != null)
			{
				if (rbWall.Checked)
				{
					var orderedPoints = orderPoints(prevCurPos, curCurPos, sizePerPixel);
					Brush brush = new SolidBrush(Color.FromArgb(190, Wall.Color));

					if (orderedPoints.Width > orderedPoints.Height)
						g.FillRectangle(brush, orderedPoints.X, prevCurPos.Y * sizePerPixel.Height, orderedPoints.Width, sizePerPixel.Height);
					else
						g.FillRectangle(brush, prevCurPos.X * sizePerPixel.Width, orderedPoints.Y, sizePerPixel.Width, orderedPoints.Height);

					g.FillRectangle(Brushes.Gray, prevCurPos.X * sizePerPixel.Width, prevCurPos.Y * sizePerPixel.Height, sizePerPixel.Width, sizePerPixel.Height);
				}
				else if (rbFloor.Checked || rbErase.Checked)
				{
					Brush brush;

					if (rbFloor.Checked)
						brush = new SolidBrush(Color.FromArgb(190, Floor.Color));
					else
						brush = this.erasorBrush;

					g.FillRectangle(brush, orderPoints(prevCurPos, curCurPos, sizePerPixel));
					g.FillRectangle(Brushes.Gray, prevCurPos.X * sizePerPixel.Width, prevCurPos.Y * sizePerPixel.Height, sizePerPixel.Width, sizePerPixel.Height);
				}
			}
		}

		private Rectangle orderPoints(Pair prevCurPos, Pair curCurPos, (int Width, int Height)? sizePerPixel = null)
		{
			int leftmostX = Math.Min(prevCurPos.X, curCurPos.X);
			int topmostY = Math.Min(prevCurPos.Y, curCurPos.Y);
			int rightmostX = Math.Max(prevCurPos.X, curCurPos.X);
			int bottommostY = Math.Max(prevCurPos.Y, curCurPos.Y);

			if (sizePerPixel == null)
				return new Rectangle(
					leftmostX,
					topmostY,
					(rightmostX - leftmostX + 1),
					(bottommostY - topmostY + 1)
				);
			else
				return new Rectangle(
					leftmostX * (int)sizePerPixel?.Width,
					topmostY * (int)sizePerPixel?.Height,
					(rightmostX - leftmostX + 1) * (int)sizePerPixel?.Width,
					(bottommostY - topmostY + 1) * (int)sizePerPixel?.Height
				);
		}

		private void save()
		{
			if (prevSaveLoc != null)
				this.grid.Save(prevSaveLoc);
			else
			{
				using (var dialog = new SaveFileDialog())
				{
					dialog.Filter = "Binary|*.bin";
					dialog.CheckPathExists = true;
					dialog.AddExtension = true;
					dialog.DefaultExt = ".bin";

					if (dialog.ShowDialog() == DialogResult.OK)
					{
						this.grid.Save(dialog.FileName);
						prevSaveLoc = dialog.FileName;
					}
				}
			}
		}

		private void open()
		{
			using (var dialog = new OpenFileDialog())
			{
				dialog.Filter = "Binary|*.bin|All|*";
				dialog.CheckPathExists = true;
				dialog.CheckFileExists = true;
				dialog.DefaultExt = ".bin";

				if (dialog.ShowDialog() == DialogResult.OK)
				{
					GridController grid = GridController.Load(dialog.FileName);

					if (grid == null)
						MessageBox.Show("The file could not be parsed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					else
					{
						this.grid = grid;
						pictureBoxGrid.Invalidate();
					}
				}
			}
		}

		private void pictureBoxGrid_Paint(object sender, PaintEventArgs e)
		{
			drawBitmap(e.Graphics);
			drawSample(e.Graphics);
			drawGrid(e.Graphics);
		}

		private void pictureBoxGrid_Resize(object sender, EventArgs e)
		{
			pictureBoxGrid.Invalidate();
		}

		private void pictureBoxGrid_MouseClick(object sender, MouseEventArgs e)
		{
			var pos = getGridPosFromPbPos(e.X, e.Y);

			if (pos != null)
			{
				if (rbFloor.Checked || rbWall.Checked || rbErase.Checked)
				{
					if (prevCurPos == null)
					{
						this.pictureBoxGrid.MouseMove += new MouseEventHandler(this.pictureBoxGrid_MouseMove);
						lblEscMessage.Visible = true;
						prevCurPos = pos;
					}
					else
					{
						var orderedPoints = orderPoints(prevCurPos, pos);

						if (rbFloor.Checked)
							grid.FillFloor((orderedPoints.X, orderedPoints.Y), orderedPoints.Width, orderedPoints.Height);
						else if (rbErase.Checked)
							grid.ClearArea((orderedPoints.X, orderedPoints.Y), orderedPoints.Width, orderedPoints.Height);
						else if (rbWall.Checked)
						{
							if (orderedPoints.Width > orderedPoints.Height)
								grid.FillWall((orderedPoints.X, orderedPoints.Y), orderedPoints.Width, true);
							else
								grid.FillWall((orderedPoints.X, orderedPoints.Y), orderedPoints.Height, false);
						}

						rb_CheckedChanged_Reset(null, null);
					}
				}
				else
				{
					rb_CheckedChanged_Reset(null, null);

					var posTuple = pos.ToTuple();
					if (grid.GetAt(posTuple) is Floor)
					{
						if (rbFire.Checked)
							grid.PutFire(posTuple);
						else if (rbPerson.Checked)
							grid.PutPerson(posTuple);
					}
				}

				pictureBoxGrid.Invalidate();
			}
		}

		private void pictureBoxGrid_MouseMove(object sender, MouseEventArgs e)
		{
			curCurPos = getGridPosFromPbPos(e.X, e.Y);
			
			if (curCurPos != null)
				pictureBoxGrid.Invalidate();
		}

		private void rb_CheckedChanged_Reset(object sender, EventArgs e)
		{
			this.pictureBoxGrid.MouseMove -= new MouseEventHandler(this.pictureBoxGrid_MouseMove);
			lblEscMessage.Visible = false;
			prevCurPos = null;
			curCurPos = null;

			pictureBoxGrid.Invalidate();
		}

		private void Designer_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				rb_CheckedChanged_Reset(null, null);
			else if (e.Control)
			{
				if (e.KeyCode == Keys.S)
					this.save();
				else if (e.KeyCode == Keys.O)
					this.open();
			}
		}
	}

	internal class Pair
	{
		public readonly int X, Y;

		public Pair(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public Pair((int x, int y) tuple)
		{
			this.X = tuple.x;
			this.Y = tuple.y;
		}

		public (int X, int Y) ToTuple()
		{
			return (this.X, this.Y);
		}

		public override string ToString()
		{
			return $"({this.X}, {this.Y})";
		}
	}
}
