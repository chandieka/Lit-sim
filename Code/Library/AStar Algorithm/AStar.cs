using System;
using System.Collections.Generic;
using System.Threading;

/* https://www.geeksforgeeks.org/a-search-algorithm/ */

namespace Library
{
	public class AStar
	{
		private Block[,] grid;
		private Pair dest;
		private Pair src;

		public AStar(Block[,] grid, Pair src, Pair dest)
		{
			this.grid = grid;
			this.dest = dest;
			this.src = src;
		}

		/// <summary>
		/// Checks if the row and column number is within range and if it is a valid type
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="row"></param>
		/// <param name="col"></param>
		/// <returns></returns>
		private bool isValid(Block[,] grid, int row, int col, Type type)
		{
			return
				(row >= 0 && row < grid.GetLength(0)) &&
				(col >= 0 && col < grid.GetLength(1)) &&
				grid[row, col].GetType() == type;
		}

		private bool isValid(Block[,] grid, int row, int col)
		{
			if (!
				(row >= 0 && row < grid.GetLength(0)) &&
				(col >= 0 && col < grid.GetLength(1))
			)
				return false;

			var gridVal = grid[row, col];
			return (
				gridVal != Block.Empty &&
				!(gridVal is Person)
			);
		}

		/// <summary>
		/// Checks if the target is accessible
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="row"></param>
		/// <param name="col"></param>
		/// <returns></returns>
		private bool isUnBlocked(Block[,] grid, int row, int col)
			=> grid[row, col] is Floor;

		private bool isDestination(int row, int col, Pair dest)
		{
			return row == dest.X && col == dest.Y;
		}

		private double calculateHValue(int row, int col, Pair dest)
		{
			// TODO: This is eucledian distance, this is not correct
			return Math.Sqrt(Math.Pow(row - dest.X, 2) + Math.Pow(col - dest.Y, 2));
		}

		private Pair[] tracePath(Cell[,] cellDetails, Pair dest)
		{
			int row = dest.X;
			int col = dest.Y;

			Stack<Pair> path = new Stack<Pair>();

			while (!(cellDetails[row, col].parent_i == row && cellDetails[row, col].parent_j == col))
			{
				path.Push(new Pair(row, col));
				int temp_row = cellDetails[row, col].parent_i;
				int temp_col = cellDetails[row, col].parent_j;
				row = temp_row;
				col = temp_col;
			}

			path.Push(new Pair(row, col));
			return path.ToArray();
		}

		public Pair[] aStarSearch()
		{
			// If the source is out of range 
			if (!isValid(grid, src.X, src.Y, typeof(Person)))
				throw new Exception("Source is invalid");

			// If the destination is out of range 
			if (!isValid(grid, dest.X, dest.Y))
				throw new Exception("Destination is invalid");

			// If the destination cell is the same as source cell 
			if (isDestination(src.X, src.Y, dest))
				throw new Exception("We are already at the destination");


			int ROW = grid.GetLength(0);
			int COL = grid.GetLength(1);

			// Create a closed list and initialise it to false which means that no cell has been included yet
			// This closed list is implemented as a boolean 2D array
			bool[,] closedList = new bool[ROW, COL];

			// Declare a 2D array of structure to hold the details of that cell 
			Cell[,] cellDetails = new Cell[ROW, COL];

			int i, j;

			for (i = 0; i < ROW; i++)
			{
				for (j = 0; j < COL; j++)
				{
					cellDetails[i, j].f = float.MaxValue;
					cellDetails[i, j].g = float.MaxValue;
					cellDetails[i, j].h = float.MaxValue;
					cellDetails[i, j].parent_i = -1;
					cellDetails[i, j].parent_j = -1;
				}
			}

			// Initialising the parameters of the starting node 
			i = src.X;
			j = src.Y;

			cellDetails[i, j].f = 0.0;
			cellDetails[i, j].g = 0.0;
			cellDetails[i, j].h = 0.0;
			cellDetails[i, j].parent_i = i;
			cellDetails[i, j].parent_j = j;

			/*
			Create an open list having information as-
			<f, <i, j>>
			where f = g + h,
			and i, j are the row and column index of that cell
			Note that 0 <= i <= ROW-1 & 0 <= j <= COL-1
			This open list is implenented as a set of pair of pair.*/
			List<PPair> openList = new List<PPair>();

			// Put the starting cell on the open list and set its 'f' as 0 
			openList.Add(new PPair(0.0, new Pair(i, j)));

			while (openList.Count > 0 && Thread.CurrentThread.IsAlive)
			{
				// I think this is the same as the C++ implementation
				PPair p = openList[0];

				// Remove this vertex from the open list 
				openList.Remove(p);

				// Add this vertex to the closed list 
				i = p.Second.X;
				j = p.Second.Y;
				closedList[i, j] = true;

				// To store the 'g', 'h' and 'f' of the 8 successors 
				double gNew, hNew, fNew;

				Pair[] generateCellSuccessors(int x, int y, double addG)
				{
					if (isValid(grid, x, y))
					{
						// If the destination cell is the same as the 
						// current successor 
						if (isDestination(x, y, dest))
						{
							// Set the Parent of the destination cell 
							cellDetails[x, y].parent_i = i;
							cellDetails[x, y].parent_j = j;

							return tracePath(cellDetails, dest);
						}
						// If the successor is already on the closed list or if it is blocked, then ignore it. Else do the following 
						else if (!closedList[x, y] && isUnBlocked(grid, x, y))
						{
							gNew = cellDetails[i, j].g + addG;
							hNew = calculateHValue(x, y, dest);
							fNew = gNew + hNew;

							// If it isn’t on the open list, add it to 
							// the open list. Make the current square 
							// the parent of this square. Record the 
							// f, g, and h costs of the square cell 
							//			 OR 
							// If it is on the open list already, check 
							// to see if this path to that square is better, 
							// using 'f' cost as the measure. 
							if (cellDetails[x, y].f == float.MaxValue || cellDetails[x, y].f > fNew)
							{
								openList.Add(new PPair(fNew, new Pair(x, y)));

								// Update the details of this cell 
								cellDetails[x, y].f = fNew;
								cellDetails[x, y].g = gNew;
								cellDetails[x, y].h = hNew;
								cellDetails[x, y].parent_i = i;
								cellDetails[x, y].parent_j = j;
							}
						}
					}

					return null;
				}

				/*
					Generating all the 8 successor of this cell

							N.W N N.E
							\ | /
							\ | /
						W----Cell----E
							/ | \
							/ | \
							S.W S S.E

					Cell-->Popped Cell (i, j)
					N --> North	 (i-1, j)
					S --> South	 (i+1, j)
					E --> East	 (i, j+1)
					W --> West		 (i, j-1)
					N.E--> North-East (i-1, j+1)
					N.W--> North-West (i-1, j-1)
					S.E--> South-East (i+1, j+1)
					S.W--> South-West (i+1, j-1)
				*/
				Tuple<int, int, double>[] areas = new Tuple<int, int, double>[] {
					new Tuple<int, int, double>(i - 1, j, 1.0),
					new Tuple<int, int, double>(i + 1, j, 1.0),
					new Tuple<int, int, double>(i, j + 1, 1.0),
					new Tuple<int, int, double>(i, j - 1, 1.0),

					new Tuple<int, int, double>(i - 1, j + 1, 1.414),
					new Tuple<int, int, double>(i - 1, j - 1, 1.414),
					new Tuple<int, int, double>(i + 1, j + 1, 1.414),
					new Tuple<int, int, double>(i + 1, j - 1, 1.414),
				};

				foreach (var a in areas)
				{
					if (!Thread.CurrentThread.IsAlive)
						return null;

					var returnVal = generateCellSuccessors(a.Item1, a.Item2, a.Item3);

					if (returnVal != null)
						return returnVal;
				}
			}

			// When the destination cell is not found and the open 
			// list is empty, then we conclude that we failed to 
			// reach the destiantion cell. This may happen when the 
			// there is no way to destination cell (due to blockages) 
			return null;
		}
	}


}