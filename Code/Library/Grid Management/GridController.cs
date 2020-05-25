using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
	public class GridController : Grid
	{
		#region Internal static propeties
		internal static Floor Floor = new Floor();
		internal static Fire Fire = new Fire();
		#endregion

		#region Constructor
		public GridController((int width, int height) gridSize)
			: base(new Block[gridSize.width, gridSize.height])
		{
			this.Clear();
		}

		public GridController(Grid grid)
			: base(grid) { }
		#endregion

		#region Methods
		#region Grid Manipulation
		public void Clear()
		{
			for (int x = 0; x < this.GridWidth; x++)
				for (int y = 0; y < this.GridHeight; y++)
					this.grid[x, y] = Block.Empty;
		}

		public void ClearLayout()
		{
			for (int x = 0; x < this.GridWidth; x++)
			{
				for (int y = 0; y < this.GridHeight; y++)
				{
					if (this.grid[x, y].GetType() == typeof(Person) || this.grid[x, y].GetType() == typeof(Fire) || this.grid[x, y].GetType() == typeof(FireExtinguisher))
						this.grid[x, y] = GridController.Floor;
				}
			}
		}

		public Block[,] GetGridCopy()
			=> DeepCloneBlock(grid);

		public void SetGrid(Block[,] newGrid)
		{
			this.grid = newGrid;
		}

		public void PutFloor((int x, int y) location)
		{
			this.grid[location.x, location.y] = GridController.Floor;
		}

		public void FillFloor((int x, int y) topLeft, int width, int height)
		{
			for (int x = topLeft.x; x < topLeft.x + width; x++)
			{
				for (int y = topLeft.y; y < topLeft.y + height; y++)
				{
					this.PutFloor((x, y));
				}
			}
		}

		public void ClearArea((int x, int y) topLeft, int width, int height)
		{
			for (int x = topLeft.x; x < topLeft.x + width; x++)
				for (int y = topLeft.y; y < topLeft.y + height; y++)
					this.grid[x, y] = Block.Empty;
		}

		public void ClearLayoutArea((int x, int y) topLeft, int width, int height)
		{
			for (int x = topLeft.x; x < topLeft.x + width; x++)
				for (int y = topLeft.y; y < topLeft.y + height; y++)
				{
					{
						if (this.grid[x, y].GetType() == typeof(Person) || this.grid[x, y].GetType() == typeof(Fire) || this.grid[x, y].GetType() == typeof(FireExtinguisher))
							this.grid[x, y] = GridController.Floor;
					}
				}
		}

		public void PutWall((int x, int y) location)
		{
			this.grid[location.x, location.y] = new Wall();
		}

		public void FillWall((int x, int y) topLeft, int width, int height)
		{
			// Only for horizontal and vertical wall

			for (int x = topLeft.x; x < topLeft.x + width; x++)
			{
				for (int y = topLeft.y; y < topLeft.y + height; y++)
				{
					this.PutWall((x, y));
				}
			}
		}

		public void FillWall((int x, int y) location, int length, bool horizontal)
		{
			if (horizontal)
			{
				for (int i = 0; i < length; i++)
					this.PutWall((location.x + i, location.y));
			}
			// If not horizontal, then vertical
			else
			{
				for (int i = 0; i < length; i++)
					this.PutWall((location.x, location.y + i));
			}
		}

		public void PutPerson((int x, int y) location)
		{
			Person p = new Person();
			this.grid[location.x, location.y] = p;
		}

		public bool RandomizePersons(int amount, int? seed = null)
		{
			Random rand;

			if (seed.HasValue)
				rand = new Random(seed.Value);
			else
				rand = new Random();

			var floorSpots = this.GetFloorBlocks().ToList();

			if (amount > floorSpots.Count || amount < 1)
				return false;

			for (int i = 0; i < amount; i++)
			{
				var rand_int = rand.Next(0, floorSpots.Count);

				this.PutPerson(floorSpots[rand_int]);
				floorSpots.RemoveAt(rand_int);
			}
			return true;
		}

		public void PutFire((int x, int y) location)
		{
			this.grid[location.x, location.y] = GridController.Fire;
		}

		public void RandomizeFire(int amount, int? seed = null)
		{
			var floorSpot = GetFloorBlocks();
			Random rand;

			if (seed.HasValue)
				rand = new Random(seed.Value);
			else
				rand = new Random();

			int rng = rand.Next(0, floorSpot.Length - 1);
			grid[floorSpot[rng].x, floorSpot[rng].y] = Fire;
		}

		public void PutFireExtinguisher((int x, int y) location)
		{
			FireExtinguisher f = new FireExtinguisher();
			this.grid[location.x, location.y] = f;
		}

		public bool RandomizeFireExtinguishers(int amount, int? seed = null)
		{
			Random rand;

			if (seed.HasValue)
				rand = new Random(seed.Value);
			else
				rand = new Random();

			var floorSpots = this.GetFloorBlocks();
			var filteredSpots = floorSpots.Where(_ => this.HasNeighbor(_, typeof(Wall))).ToList();

			if (amount > filteredSpots.Count || amount < 1)
				return false;

			for (int i = 0; i < amount; i++)
			{
				var rand_int = rand.Next(0, filteredSpots.Count);

				this.PutFireExtinguisher(filteredSpots[rand_int]);
				filteredSpots.RemoveAt(rand_int);
			}
			return true;
		}

		public void PutDefaultFloorPlan(int _thickness)
		{
			if (_thickness > 0)
			{
				// check whether the grid size is in ratio of 10
				if (this.GridHeight % 10 == 0 & this.GridWidth % 10 == 0)
				{
					int heightScale = GridHeight / 10;
					int widthScale = GridWidth / 10;
					int thickness = _thickness;

					// Fill all empty array as floor
					for (int i = 0; i < this.GridHeight; i++)
					{
						for (int j = 0; j < this.GridWidth; j++)
						{
							PutFloor((i, j));
						}
					}

					// Do horizonal wall fill
					// AB
					FillWall((0, 0), GridWidth, thickness);
					// LM
					FillWall((4 * widthScale, 3 * heightScale), 3 * widthScale, thickness);
					// IK
					FillWall((0 * widthScale, 4 * heightScale), 4 * widthScale, thickness);
					// QF
					FillWall((6 * widthScale, 6 * heightScale), 4 * widthScale, thickness);
					// JN
					FillWall((0 * widthScale, 7 * heightScale), 4 * widthScale, thickness);
					// OP
					FillWall((4 * widthScale, 8 * heightScale), 2 * widthScale, thickness);
					// CD
					FillWall((0 * widthScale, GridHeight - 1), GridWidth, thickness);

					// Do vertical wall fill
					// AC
					FillWall((0, 0), thickness, GridHeight);
					// LK
					FillWall((4 * widthScale, 3 * heightScale), thickness, 2 * heightScale);
					// NH
					FillWall((4 * widthScale, 7 * heightScale), thickness, 3 * heightScale);
					// QG
					FillWall((6 * widthScale, 6 * heightScale), thickness, 4 * heightScale);
					// ER
					FillWall((7 * widthScale, 0 * heightScale), thickness, 6 * heightScale);
					// BD
					FillWall((GridWidth - 1, 0 * heightScale), thickness, GridHeight);


					// Do vertical door fill
					// Door 1
					FillFloor((1 * widthScale, 4 * heightScale), 1 * widthScale, thickness);
					// Door 4
					FillFloor((8 * widthScale, 6 * heightScale), 1 * widthScale, thickness);
					// Door 5
					FillFloor((2 * widthScale, 7 * heightScale), 1 * widthScale, thickness);
					// Door 6
					FillFloor((4 * widthScale, 8 * heightScale), 1 * widthScale, thickness);

					int x;
					int y;
					for (int i = 0; i < thickness; i++)
					{
						x = (4 * widthScale);
						y = (8 * heightScale);

						PutWall((x, y));
					}

					// Do horizonal door fill
					// Door 2
					FillFloor((7 * widthScale, 1 * heightScale), thickness, 1 * widthScale);
					// Door 3
					FillFloor((7 * widthScale, 4 * heightScale), thickness, 1 * widthScale);
				}
			}
		}

		#endregion
		#region Other methods
		public System.Drawing.Bitmap Paint((int xScale, int yScale) scaleSize)
			=> Grid.Paint(grid, scaleSize);

		public SaveItem SaveAsFloorplan(string name)
		{
			// The grid doesn't need to be deep-cloned for saving
			var saveItem = new SaveItem(new Floorplan(this.grid), name);
			SaveLoadManager.Save(saveItem);
			return saveItem;
		}

		public SaveItem SaveAsLayout(string name, SaveItem parent)
		{
			if (parent == null || !(parent.Item is Floorplan))
				throw new Exception("Cannot save to a parent that is not of type Floorplan");

			Layout layout = new Layout(this.grid);
			// The grid doesn't need to be deep-cloned for saving
			SaveItem saveItem = new SaveItem(layout, name);

			SaveLoadManager.Save(saveItem);
			((Floorplan)parent.Item).AddLayout(layout.Id);

			SaveLoadManager.Save(parent);
			return saveItem;
		}

		public static Floorplan CreateDefaultFloorplan()
		{
			GridController gc = new GridController((100, 100));
			gc.PutDefaultFloorPlan(1);

			return new Floorplan(gc.grid);
		}

		public int GetFireExtinguisherSpots()
		{
			var floorSpots = this.GetFloorBlocks();
			var filteredSpots = floorSpots.Where(_ => this.HasNeighbor(_, typeof(Wall))).ToList();

			return filteredSpots.Count;
		}

		private (int x, int y)[] GetFloorBlocks()
		{
			var result = new List<(int x, int y)>();

			for (int x = 0; x < this.GridWidth; x++)
				for (int y = 0; y < this.GridHeight; y++)
					if (this.grid[x, y].GetType() == typeof(Floor))
						result.Add((x, y));

			return result.ToArray();
		}

		private bool HasNeighbor((int x, int y) self, Type neighbor)
		{
			for (int XOffset = -1; XOffset <= 1; XOffset++)
			{
				for (int YOffset = -1; YOffset <= 1; YOffset++)
				{
					if ((self.x + XOffset < 0) || (self.x + XOffset > this.GridWidth - 1) || (self.y + YOffset < 0) || (self.y + YOffset > this.GridHeight - 1) || (XOffset == 0 && YOffset == 0))
						continue;

					if (grid[(self.x + XOffset), (self.y + YOffset)].GetType() == neighbor)
						return true;
				}
			}

			return false;
		}

		public bool IsFloor((int x, int y) loc)
			=> this.grid[loc.x, loc.y] is Floor;

		public string CheckCriteria(bool isFloorplan)
		{
			/*
			 * For floorplan:
			 * 	Checks if the user placed at least four floors
			 * 
			 * For layout:
			 * 	 Checks if the user placed at least one fire, person & fire extinguisher		 
			 */

			const int minLayoutElemCount = 1;
			const int minFloorCount = 4;

			int personCount = 0;
			int floorCount = 0;
			int fireCount = 0;
			int feCount = 0;

			for (int x = 0; x < GridWidth; x++)
			{
				for (int y = 0; y < GridHeight; y++)
				{
					var block = grid[x, y];

					if (isFloorplan)
					{
						if (block is Floor)
							floorCount++;

						if (floorCount >= minFloorCount)
							return null;
					}
					else
					{
						if (block is Person)
							personCount++;
						else if (block is Fire)
							fireCount++;
						else if (block is FireExtinguisher)
							feCount++;

						if (
							personCount >= minLayoutElemCount &&
							fireCount >= minLayoutElemCount &&
							feCount >= minLayoutElemCount
						)
							return null;
					}
				}
			}

			const string defaultStr = "You need to place at least";
			if (isFloorplan)
				return $"{defaultStr} {minFloorCount} floor elements";
			else if (personCount < minLayoutElemCount)
				return $"{defaultStr} {minLayoutElemCount} person";
			else if (fireCount < minLayoutElemCount)
				return $"{defaultStr} {minLayoutElemCount} fire";
			else if (feCount < minLayoutElemCount)
				return $"{defaultStr} {minLayoutElemCount} fire extinguisher";
			else
				return null;
		}
		#endregion
		#endregion
	}
}
