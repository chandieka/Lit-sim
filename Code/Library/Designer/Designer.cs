using System;
using System.Collections.Generic;
using System.Drawing;

namespace Library
{
	public class Designer
	{
		private GridController grid;

		private List<History> history = new List<History>();
		private int currentPointInHistory;

		private int pbGridWidth;
		private int pbGridHeight;

		private Brush erasorBrush = new SolidBrush(Color.FromArgb(120, Color.Salmon));

		public Designer(GridController gridController, int pbGridWidth, int pbGridHeight)
		{
			grid = gridController;
			this.pbGridWidth = pbGridWidth;
			this.pbGridHeight = pbGridHeight;
		}

		public SaveItem SaveAsFloorplan(string name)
			=> grid.SaveAsFloorplan(name);

		public SaveItem SaveAsLayout(string name, SaveItem parent)
			=> grid.SaveAsLayout(name, parent);

		private (int Width, int Height) getSizePerPixel()
		{
			return (pbGridWidth / grid.GridWidth, pbGridHeight / grid.GridHeight);
		}

		private (int Width, int Height) getMaxSize()
		{
			var sizePixel = getSizePerPixel();
			return (sizePixel.Width * grid.GridWidth, sizePixel.Height * grid.GridHeight);
		}

		public Pair getGridPosFromPbPos(int x, int y)
		{
			var sizePerPixel = getSizePerPixel();
			var maxSize = getMaxSize();

			int yVal = y / sizePerPixel.Height;
			int xVal = x / sizePerPixel.Width;

			if (xVal > maxSize.Width || yVal > maxSize.Height || xVal > grid.GridWidth - 1 || yVal > grid.GridHeight - 1)
				return null;

			return new Pair(xVal, yVal);
		}

		public void drawGrid(Graphics g)
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

		public void drawBitmap(Graphics g)
		{
			var bitmap = grid.Paint(getSizePerPixel());
			var maxSize = getMaxSize();

			g.DrawImage(bitmap, 0, 0, maxSize.Width, maxSize.Height);
		}

		public void drawSample(Graphics g, GUIElement element, Pair curCurPos, Pair prevCurPos)
		{
			var sizePerPixel = getSizePerPixel();

			if (prevCurPos != null && curCurPos != null)
			{
				if (element == GUIElement.WALL)
				{
					var orderedPoints = orderPoints(prevCurPos, curCurPos, sizePerPixel);
					Brush brush = new SolidBrush(Color.FromArgb(190, Wall.Color));

					if (orderedPoints.Width > orderedPoints.Height)
						g.FillRectangle(brush, orderedPoints.X, prevCurPos.Y * sizePerPixel.Height, orderedPoints.Width, sizePerPixel.Height);
					else
						g.FillRectangle(brush, prevCurPos.X * sizePerPixel.Width, orderedPoints.Y, sizePerPixel.Width, orderedPoints.Height);

					g.FillRectangle(Brushes.Gray, prevCurPos.X * sizePerPixel.Width, prevCurPos.Y * sizePerPixel.Height, sizePerPixel.Width, sizePerPixel.Height);
				}
				else if (element == GUIElement.FLOOR || element == GUIElement.ERASER)
				{
					Brush brush;

					if (element == GUIElement.FLOOR)
						brush = new SolidBrush(Color.FromArgb(190, Floor.Color));
					else
						brush = this.erasorBrush;

					g.FillRectangle(brush, orderPoints(prevCurPos, curCurPos, sizePerPixel));
					g.FillRectangle(Brushes.Gray, prevCurPos.X * sizePerPixel.Width, prevCurPos.Y * sizePerPixel.Height, sizePerPixel.Width, sizePerPixel.Height);
				}
			}
		}

		public void FillFloor((int x, int y) topLeft, int width, int height)
		{
			grid.FillFloor(topLeft, width, height);
		}

		public void ClearArea((int x, int y) topLeft, int width, int height)
		{
			grid.ClearArea(topLeft, width, height);
		}

		public void ClearLayoutArea((int x, int y) topleft, int width, int height)
		{
			grid.ClearLayoutArea(topleft, width, height);
		}

		public void FillWall((int x, int y) location, int length, bool horizontal)
		{
			grid.FillWall(location, length, horizontal);
		}

		public Block GetAt((int x, int y) loc)
		{
			return grid.GetAt(loc);
		}

		public void PutFire((int x, int y) location)
		{
			grid.PutFire(location);
		}

		public void PutPerson((int x, int y) location)
		{
			grid.PutPerson(location);
		}

		public void PutFireExtinguisher((int x, int y) location)
		{
			grid.PutFireExtinguisher(location);
		}

		public void ClearAll()
		{
			grid.Clear();
		}

		public void ClearLayout()
		{
			grid.ClearLayout();
		}

		public Rectangle orderPoints(Pair prevCurPos, Pair curCurPos, (int Width, int Height)? sizePerPixel = null)
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

		#region History
		public void AddHistory(string reason)
		{
			if (currentPointInHistory != history.Count - 1 && history.Count != 0)
				this.history.RemoveRange(currentPointInHistory + 1, history.Count - currentPointInHistory - 1);

			this.history.Add(new History(reason, this.grid.GetGridCopy()));
			currentPointInHistory = history.Count - 1;
		}

		public History[] GetHistory()
			=> history.ToArray();

		public void UpdateGrid(int pointInHistory)
		{
			History his = this.history[pointInHistory];
			currentPointInHistory = pointInHistory;
			this.grid.SetGrid(his.Grid);
			his.Grid = this.grid.GetGridCopy();
		}
		#endregion
	}
}
