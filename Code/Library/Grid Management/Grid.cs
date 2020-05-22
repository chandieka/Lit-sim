using System;
using System.Drawing;

namespace Library
{
	[Serializable]
	public class Grid
	{
		protected Block[,] grid;

		public int GridWidth => this.grid.GetLength(0);
		public int GridHeight => this.grid.GetLength(1);

		public Grid(Block[,] grid)
		{
			this.grid = grid;
		}

		protected Grid(Grid grid)
        {
			this.grid = grid.grid;
        }

		public Grid Clone()
			=> new Grid(DeepCloneBlock(this.grid));

		public static Block[,] DeepCloneBlock(Block[,] grid)
		{
			Block[,] newGrid = new Block[grid.GetLength(0), grid.GetLength(1)];

			// Deep Copy the Grid
			for (int i = 0; i < grid.GetLength(0); i++)
			{
				for (int j = 0; j < grid.GetLength(1); j++)
				{
					var gridObjectType = grid[i, j].GetType();

					if (gridObjectType == typeof(Person))
						newGrid[i, j] = new Person();
					else if (gridObjectType == typeof(Wall))
						newGrid[i, j] = new Wall();
					else if (gridObjectType == typeof(Floor))
						newGrid[i, j] = new Floor();
					else if (gridObjectType == typeof(Fire))
						newGrid[i, j] = new Fire();
					else if (gridObjectType == typeof(FireExtinguisher))
						newGrid[i, j] = new FireExtinguisher();
					else
						newGrid[i, j] = Block.Empty;
				}
			}

			return newGrid;
		}

		public static Bitmap Paint(Block[,] grid, (int xScale, int yScale) scaleSize, Person[] persons = null)
		{
			Bitmap UseGraphics(Bitmap bmp)
			{
				Color getColor(int x, int y)
				{
					if (grid[x, y] is Person)
						return ((Person)grid[x, y]).Color;
					else
						return (Color)grid[x, y].GetType().GetField("Color").GetValue(grid[x, y]);
				}

				var gr = Graphics.FromImage(bmp);
				Brush br;

				for (int x = 0; x < grid.GetLength(0); x++)
				{
					for (int y = 0; y < grid.GetLength(1); y++)
					{
						br = new SolidBrush(getColor(x, y));

						gr.FillRectangle(br, x * scaleSize.xScale, y * scaleSize.yScale, 1 * scaleSize.xScale, 1 * scaleSize.xScale);
					}
				}

				if (persons != null) // this.ShouldDrawPaths && !this.hasTicked
				{
					Brush brush = new SolidBrush(Color.FromArgb(120, Color.Coral));

					foreach (Person p in persons)
						if (p.ShortestPath == null)
							break;
						else
						{
							for (int i = 1; i < p.ShortestPath.Length - 1; i++)
							{
								var pair = p.ShortestPath[i];
								gr.FillRectangle(brush, pair.X * scaleSize.xScale, pair.Y * scaleSize.yScale, scaleSize.xScale, scaleSize.xScale);
							}
						}
				}

				return bmp;
			}

			// create a new bitmap
			var bitmap = new Bitmap(grid.GetLength(0) * scaleSize.xScale, grid.GetLength(1) * scaleSize.yScale);
			return UseGraphics(bitmap);
		}
	}
}
