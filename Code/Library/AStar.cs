using System;
using System.Collections.Generic;

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

		private bool isValid(Block[,] grid, int row, int col)
		{
			// TODO: This is not correct!
			// Returns true if row number and column number is in range 
			return (row >= 0) && (row < grid.GetLength(0)) && (col >= 0) && (col < grid.GetLength(1));
		}

		//bool isUnBlocked(int grid[][COL], int row, int col)
		private bool isUnBlocked(Block[,] grid, int row, int col)
		{
			var gridVal = grid.GetValue(row, col);

			return !(gridVal is Fire || gridVal is Wall);
		}

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
			if (!isValid(grid, src.X, src.Y))
			{
				Console.WriteLine("Source is invalid\n");
				return null;
			}

			// If the destination is out of range 
			if (!isValid(grid, dest.X, dest.Y))
			{
				Console.WriteLine("Destination is invalid\n");
				return null;
			}

			// Either the source or the destination is blocked 
			if (!isUnBlocked(grid, src.X, src.Y) || !isUnBlocked(grid, dest.X, dest.Y))
			{
				Console.WriteLine("Source or the destination is blocked\n");
				return null;
			}

			// If the destination cell is the same as source cell 
			if (isDestination(src.X, src.Y, dest))
			{
				Console.WriteLine("We are already at the destination\n");
				return null;
			}

			int ROW = grid.GetLength(0);
			int COL = grid.GetLength(1);

			// Create a closed list and initialise it to false which means 
			// that no cell has been included yet 
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

			while (openList.Count > 0)
			{
				// I think this is the same as the C++ implementation
				PPair p = openList[0];

				// Remove this vertex from the open list 
				openList.Remove(p);

				// Add this vertex to the closed list 
				i = p.Second.X;
				j = p.Second.Y;
				closedList[i, j] = true;

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

				// TODO: All these successor thingies could easily be one method

				// To store the 'g', 'h' and 'f' of the 8 successors 
				double gNew, hNew, fNew;

				//----------- 1st Successor (North) ------------ 
				// Only process this cell if this is a valid one 
				if (isValid(grid, i - 1, j))
				{
					// If the destination cell is the same as the current successor 
					if (isDestination(i - 1, j, dest) == true)
					{
						// Set the Parent of the destination cell 
						cellDetails[i - 1, j].parent_i = i;
						cellDetails[i - 1, j].parent_j = j;
						Console.WriteLine("The destination cell is found");
						return tracePath(cellDetails, dest);
					}
					// If the successor is already on the closed list or if it is blocked, then ignore it. Else do the following 
					else if (closedList[i - 1, j] == false && isUnBlocked(grid, i - 1, j) == true)
					{
						gNew = cellDetails[i, j].g + 1.0;
						hNew = calculateHValue(i - 1, j, dest);
						fNew = gNew + hNew;

						// If it isn’t on the open list, add it to 
						// the open list. Make the current square 
						// the parent of this square. Record the 
						// f, g, and h costs of the square cell 
						//			 OR 
						// If it is on the open list already, check 
						// to see if this path to that square is better, 
						// using 'f' cost as the measure. 
						if (cellDetails[i - 1, j].f == float.MaxValue || cellDetails[i - 1, j].f > fNew)
						{
							openList.Add(new PPair(fNew, new Pair(i - 1, j)));

							// Update the details of this cell 
							cellDetails[i - 1, j].f = fNew;
							cellDetails[i - 1, j].g = gNew;
							cellDetails[i - 1, j].h = hNew;
							cellDetails[i - 1, j].parent_i = i;
							cellDetails[i - 1, j].parent_j = j;
						}
					}
				}

				//----------- 2nd Successor (South) ------------ 
				// Only process this cell if this is a valid one 
				if (isValid(grid, i + 1, j))
				{
					// If the destination cell is the same as the current successor 
					if (isDestination(i + 1, j, dest))
					{
						// Set the Parent of the destination cell 
						cellDetails[i + 1, j].parent_i = i;
						cellDetails[i + 1, j].parent_j = j;
						Console.Write("The destination cell is found\n");
						return tracePath(cellDetails, dest);
					}
					// If the successor is already on the closed 
					// list or if it is blocked, then ignore it. 
					// Else do the following 
					else if (!closedList[i + 1, j] && isUnBlocked(grid, i + 1, j))
					{
						gNew = cellDetails[i, j].g + 1.0;
						hNew = calculateHValue(i + 1, j, dest);
						fNew = gNew + hNew;

						// If it isn’t on the open list, add it to 
						// the open list. Make the current square 
						// the parent of this square. Record the 
						// f, g, and h costs of the square cell 
						//			 OR 
						// If it is on the open list already, check 
						// to see if this path to that square is better, 
						// using 'f' cost as the measure. 
						if (cellDetails[i + 1, j].f == float.MaxValue|| cellDetails[i + 1, j].f > fNew)
						{
							openList.Add(new PPair(fNew, new Pair(i + 1, j)));
							// Update the details of this cell 
							cellDetails[i + 1, j].f = fNew;
							cellDetails[i + 1, j].g = gNew;
							cellDetails[i + 1, j].h = hNew;
							cellDetails[i + 1, j].parent_i = i;
							cellDetails[i + 1, j].parent_j = j;
						}
					}
				}

				//----------- 3rd Successor (East) ------------ 
				// Only process this cell if this is a valid one 
				if (isValid(grid, i, j + 1))
				{
					// If the destination cell is the same as the current successor 
					if (isDestination(i, j + 1, dest))
					{
						// Set the Parent of the destination cell 
						cellDetails[i, j + 1].parent_i = i;
						cellDetails[i, j + 1].parent_j = j;
						Console.Write("The destination cell is found\n");
						return tracePath(cellDetails, dest);
					}

					// If the successor is already on the closed 
					// list or if it is blocked, then ignore it. 
					// Else do the following 
					else if (!closedList[i, j + 1] && isUnBlocked(grid, i, j + 1))
					{
						gNew = cellDetails[i, j].g + 1.0;
						hNew = calculateHValue(i, j + 1, dest);
						fNew = gNew + hNew;

						// If it isn’t on the open list, add it to 
						// the open list. Make the current square 
						// the parent of this square. Record the 
						// f, g, and h costs of the square cell 
						//			 OR 
						// If it is on the open list already, check 
						// to see if this path to that square is better, 
						// using 'f' cost as the measure. 
						if (cellDetails[i, j + 1].f == float.MaxValue || cellDetails[i, j + 1].f > fNew)
						{
							openList.Add(new PPair(fNew, new Pair(i, j + 1)));

							// Update the details of this cell 
							cellDetails[i, j + 1].f = fNew;
							cellDetails[i, j + 1].g = gNew;
							cellDetails[i, j + 1].h = hNew;
							cellDetails[i, j + 1].parent_i = i;
							cellDetails[i, j + 1].parent_j = j;
						}
					}
				}

				//----------- 4th Successor (West) ------------ 
				// Only process this cell if this is a valid one 
				if (isValid(grid, i, j - 1))
				{
					// If the destination cell is the same as the current successor 
					if (isDestination(i, j - 1, dest))
					{
						// Set the Parent of the destination cell 
						cellDetails[i, j - 1].parent_i = i;
						cellDetails[i, j - 1].parent_j = j;
						Console.Write("The destination cell is found\n");
						return tracePath(cellDetails, dest);
					}
					// If the successor is already on the closed 
					// list or if it is blocked, then ignore it. 
					// Else do the following 
					else if (!closedList[i, j - 1] && isUnBlocked(grid, i, j - 1))
					{
						gNew = cellDetails[i, j].g + 1.0;
						hNew = calculateHValue(i, j - 1, dest);
						fNew = gNew + hNew;

						// If it isn’t on the open list, add it to 
						// the open list. Make the current square 
						// the parent of this square. Record the 
						// f, g, and h costs of the square cell 
						//			 OR 
						// If it is on the open list already, check 
						// to see if this path to that square is better, 
						// using 'f' cost as the measure. 
						if (cellDetails[i, j - 1].f == float.MaxValue || cellDetails[i, j - 1].f > fNew)
						{
							openList.Add(new PPair(fNew, new Pair(i, j - 1)));

							// Update the details of this cell 
							cellDetails[i, j - 1].f = fNew;
							cellDetails[i, j - 1].g = gNew;
							cellDetails[i, j - 1].h = hNew;
							cellDetails[i, j - 1].parent_i = i;
							cellDetails[i, j - 1].parent_j = j;
						}
					}
				}

				//----------- 5th Successor (North-East) ------------ 
				// Only process this cell if this is a valid one 
				if (isValid(grid, i - 1, j + 1))
				{
					// If the destination cell is the same as the 
					// current successor 
					if (isDestination(i - 1, j + 1, dest) == true)
					{
						// Set the Parent of the destination cell 
						cellDetails[i - 1, j + 1].parent_i = i;
						cellDetails[i - 1, j + 1].parent_j = j;
						Console.Write("The destination cell is found\n");
						return tracePath(cellDetails, dest);
					}
					// If the successor is already on the closed 
					// list or if it is blocked, then ignore it. 
					// Else do the following 
					else if (!closedList[i - 1, j + 1] && isUnBlocked(grid, i - 1, j + 1))
					{
						gNew = cellDetails[i, j].g + 1.414;
						hNew = calculateHValue(i - 1, j + 1, dest);
						fNew = gNew + hNew;

						// If it isn’t on the open list, add it to 
						// the open list. Make the current square 
						// the parent of this square. Record the 
						// f, g, and h costs of the square cell 
						//			 OR 
						// If it is on the open list already, check 
						// to see if this path to that square is better, 
						// using 'f' cost as the measure. 
						if (cellDetails[i - 1, j + 1].f == float.MaxValue|| cellDetails[i - 1, j + 1].f > fNew)
						{
							openList.Add(new PPair(fNew, new Pair(i - 1, j + 1)));

							// Update the details of this cell 
							cellDetails[i - 1, j + 1].f = fNew;
							cellDetails[i - 1, j + 1].g = gNew;
							cellDetails[i - 1, j + 1].h = hNew;
							cellDetails[i - 1, j + 1].parent_i = i;
							cellDetails[i - 1, j + 1].parent_j = j;
						}
					}
				}

				//----------- 6th Successor (North-West) ------------ 
				// Only process this cell if this is a valid one 
				if (isValid(grid, i - 1, j - 1))
				{
					// If the destination cell is the same as the 
					// current successor 
					if (isDestination(i - 1, j - 1, dest))
					{
						// Set the Parent of the destination cell 
						cellDetails[i - 1, j - 1].parent_i = i;
						cellDetails[i - 1, j - 1].parent_j = j;
						Console.Write("The destination cell is found\n");
						return tracePath(cellDetails, dest);
					}
					// If the successor is already on the closed 
					// list or if it is blocked, then ignore it. 
					// Else do the following 
					else if (!closedList[i - 1, j - 1] && isUnBlocked(grid, i - 1, j - 1))
					{
						gNew = cellDetails[i, j].g + 1.414;
						hNew = calculateHValue(i - 1, j - 1, dest);
						fNew = gNew + hNew;

						// If it isn’t on the open list, add it to 
						// the open list. Make the current square 
						// the parent of this square. Record the 
						// f, g, and h costs of the square cell 
						//			 OR 
						// If it is on the open list already, check 
						// to see if this path to that square is better, 
						// using 'f' cost as the measure. 
						if (cellDetails[i - 1, j - 1].f == float.MaxValue || cellDetails[i - 1, j - 1].f > fNew)
						{
							openList.Add(new PPair(fNew, new Pair(i - 1, j - 1)));
							// Update the details of this cell 
							cellDetails[i - 1, j - 1].f = fNew;
							cellDetails[i - 1, j - 1].g = gNew;
							cellDetails[i - 1, j - 1].h = hNew;
							cellDetails[i - 1, j - 1].parent_i = i;
							cellDetails[i - 1, j - 1].parent_j = j;
						}
					}
				}

				//----------- 7th Successor (South-East) ------------ 
				// Only process this cell if this is a valid one 
				if (isValid(grid, i + 1, j + 1))
				{
					// If the destination cell is the same as the current successor 
					if (isDestination(i + 1, j + 1, dest))
					{
						// Set the Parent of the destination cell 
						cellDetails[i + 1, j + 1].parent_i = i;
						cellDetails[i + 1, j + 1].parent_j = j;
						Console.Write("The destination cell is found\n");
						return tracePath(cellDetails, dest);
					}

					// If the successor is already on the closed 
					// list or if it is blocked, then ignore it. 
					// Else do the following 
					else if (!closedList[i + 1, j + 1] && isUnBlocked(grid, i + 1, j + 1))
					{
						gNew = cellDetails[i, j].g + 1.414;
						hNew = calculateHValue(i + 1, j + 1, dest);
						fNew = gNew + hNew;

						// If it isn’t on the open list, add it to 
						// the open list. Make the current square 
						// the parent of this square. Record the 
						// f, g, and h costs of the square cell 
						//			 OR 
						// If it is on the open list already, check 
						// to see if this path to that square is better, 
						// using 'f' cost as the measure. 
						if (cellDetails[i + 1, j + 1].f == float.MaxValue || cellDetails[i + 1, j + 1].f > fNew)
						{
							openList.Add(new PPair(fNew, new Pair(i + 1, j + 1)));

							// Update the details of this cell 
							cellDetails[i + 1, j + 1].f = fNew;
							cellDetails[i + 1, j + 1].g = gNew;
							cellDetails[i + 1, j + 1].h = hNew;
							cellDetails[i + 1, j + 1].parent_i = i;
							cellDetails[i + 1, j + 1].parent_j = j;
						}
					}
				}

				//----------- 8th Successor (South-West) ------------ 
				// Only process this cell if this is a valid one 
				if (isValid(grid, i + 1, j - 1))
				{
					// If the destination cell is the same as the 
					// current successor 
					if (isDestination(i + 1, j - 1, dest))
					{
						// Set the Parent of the destination cell 
						cellDetails[i + 1, j - 1].parent_i = i;
						cellDetails[i + 1, j - 1].parent_j = j;
						Console.Write("The destination cell is found\n");
						return tracePath(cellDetails, dest);
					}

					// If the successor is already on the closed 
					// list or if it is blocked, then ignore it. 
					// Else do the following 
					else if (!closedList[i + 1, j - 1] && isUnBlocked(grid, i + 1, j - 1))
					{
						gNew = cellDetails[i, j].g + 1.414;
						hNew = calculateHValue(i + 1, j - 1, dest);
						fNew = gNew + hNew;

						// If it isn’t on the open list, add it to 
						// the open list. Make the current square 
						// the parent of this square. Record the 
						// f, g, and h costs of the square cell 
						//			 OR 
						// If it is on the open list already, check 
						// to see if this path to that square is better, 
						// using 'f' cost as the measure. 
						if (cellDetails[i + 1, j - 1].f == float.MaxValue || cellDetails[i + 1, j - 1].f > fNew)
						{
							openList.Add(new PPair(fNew, new Pair(i + 1, j - 1)));

							// Update the details of this cell 
							cellDetails[i + 1, j - 1].f = fNew;
							cellDetails[i + 1, j - 1].g = gNew;
							cellDetails[i + 1, j - 1].h = hNew;
							cellDetails[i + 1, j - 1].parent_i = i;
							cellDetails[i + 1, j - 1].parent_j = j;
						}
					}
				}
			}

			// When the destination cell is not found and the open 
			// list is empty, then we conclude that we failed to 
			// reach the destiantion cell. This may happen when the 
			// there is no way to destination cell (due to blockages) 
			return null;
		}
	}

	public class Pair
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
	}

	struct Cell
	{
		// Row and Column index of its parent 
		// Note that 0 <= i <= ROW-1 & 0 <= j <= COL-1 
		public int parent_i, parent_j;
		// f = g + h 
		public double f, g, h;
	}

	struct PPair
	{
		public readonly double First;
		public readonly Pair Second;

		public PPair(double one, Pair two)
		{
			this.Second = two;
			this.First = one;
		}
	}
}