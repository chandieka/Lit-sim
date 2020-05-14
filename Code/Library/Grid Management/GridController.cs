using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Library
{
	public class GridController : ICloneable
	{
		#region Internal static propeties
		internal static Floor Floor = new Floor();
		internal static Fire Fire = new Fire();
		#endregion

		#region Private Fields
		// playing fields
		private bool hasFoundFireInPreviusTick = false;
		public bool ShouldDrawPaths = true;
		private bool hasTicked = false;

		private List<History> gridHistory;

        // Core Variable
		private Block[,] grid;
		private List<FireExtinguisher> fireExtinguishers = new List<FireExtinguisher>();
		private List<Person> persons = new List<Person>();

		private int personDelayCounter = 0;
		private int personDelay = 2;
		// others 
		#endregion

		#region Public Properties
		public int GridWidth => this.grid.GetLength(0);
		public int GridHeight => this.grid.GetLength(1);

		public event EventHandler Finished;
		#endregion

		#region Constructor
		public GridController((int width, int height) gridSize)
		{
			this.grid = new Block[gridSize.width, gridSize.height];
			this.gridHistory = new List<History>();
			// fill the grid with empty blocks.
			this.Clear();
		}

		public GridController(Block[,] grid)
		{
			this.gridHistory = new List<History>();
            this.grid = grid;
            fillLists();
		}
		#endregion

		#region Methods
		#region Grid Manipulation
		public void Clear()
		{
			// fill the grid with empty blocks.
			for (int x = 0; x < this.grid.GetLength(0); x++)
			{
				for (int y = 0; y < this.grid.GetLength(1); y++)
				{
					this.grid[x, y] = Block.Empty;
				}
			}

			this.hasTicked = false;
		}

        public void ClearLayout()
        {
            for (int x = 0; x < this.grid.GetLength(0); x++)
            {
                for (int y = 0; y < this.grid.GetLength(1); y++)
                {
                    if (this.grid[x, y].GetType() == typeof(Person) || this.grid[x, y].GetType() == typeof(Fire) || this.grid[x, y].GetType() == typeof(FireExtinguisher))
                        this.grid[x, y] = new Floor();
                }
            }
            this.hasTicked = false;
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
			persons.Add(p);
			this.grid[location.x, location.y] = p;
		}

		public bool RandomizePersons(int amount, int? seed = null)
		{
			Random rand;

			// Prevent infinite simulation
			persons.Clear();

			if (seed.HasValue)
				rand = new Random(seed.Value);
			else
				rand = new Random();

			var floorSpots = this.GetFloorBlocks();

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
			Random rand;
			List<(int x, int y)> floorSpot = GetFloorBlocks();

			if (seed.HasValue)
				rand = new Random(seed.Value);
			else
				rand = new Random();

			int rng = rand.Next(0, floorSpot.Count - 1);
			grid[floorSpot[rng].x, floorSpot[rng].y] = Fire;
		}

		public void PutFireExtinguisher((int x, int y) location)
		{
			FireExtinguisher f = new FireExtinguisher();
			fireExtinguishers.Add(f);
			this.grid[location.x, location.y] = f;
		}

		public bool RandomizeFireExtinguishers(int amount, int? seed = null)
		{
			fireExtinguishers.Clear();
			Random rand;

			if (seed.HasValue)
				rand = new Random(seed.Value);
			else
				rand = new Random();

			var floorSpots = this.GetFloorBlocks();
			var filteredSpots = floorSpots.Where(_ => this.HasNeighbor(_, this.grid, typeof(Wall))).ToList();

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

		public bool Ended()
		{
			return this.persons.TrueForAll(p => p.IsDead);
		}

		public void Tick()
		{
			if (hasTicked && !hasFoundFireInPreviusTick)
				return;

			this.hasFoundFireInPreviusTick = false;
			this.hasTicked = true;

			// This is needed to prevent the fire from spreading rapidly
			var gridCopy = this.grid.Clone() as Block[,];

			for (int x = 0; x < gridCopy.GetLength(0); x++)
			{
				for (int y = 0; y < gridCopy.GetLength(1); y++)
				{
					switch (gridCopy[x, y])
					{
						case FunctionalBlock fb:
							if (fb is Fire)
								hasFoundFireInPreviusTick = true;
							else if (fb is Person)
								if (personDelayCounter < personDelay)
									continue;

							fb.Function(this.grid, x, y);
							break;
					}
				}
			}

			personDelayCounter++;
			if (personDelayCounter > personDelay)
				personDelayCounter = 0;

			if (!hasFoundFireInPreviusTick)
				this.Finished?.Invoke(this, new EventArgs());
		}

		public void Stop()
		{
			foreach (Person p in this.persons)
				p.Kill();
		}

		#endregion
		#region Grid Visualization
		public Bitmap Paint((int xScale, int yScale) scaleSize)
		{
			#pragma warning disable CS8321 // disable the warning about the un-used method.
			Bitmap UseLockbits(Bitmap bmp)
			{
				var bmpdata = bmp.LockBits(new Rectangle(0, 0, GridWidth, GridHeight), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

				// turn the bitmap data into a byte-array
				// note: instead of turning the bitmap into an array and editing the raw bytes, you could also do bmp.SetPixel(x, y, color), but that is MUUUUCH slower. ;)
				var ptr = bmpdata.Scan0;
				var bytes = new byte[GridHeight * bmpdata.Stride];
				System.Runtime.InteropServices.Marshal.Copy(ptr, bytes, 0, bytes.Length);

				var bpp = (double)bmpdata.Stride / GridWidth;

				// fill the byte-array with the right data
				for (int x = 0; x < GridWidth; x++)
				{
					for (int y = 0; y < GridHeight; y++)
					{
						var color = (Color)this.grid[x, y].GetType().GetField("color").GetValue(this.grid[x, y]);
						var offset = (int)(((y * GridWidth) + x) * bpp);

						Array.Copy(new[] { color.R, color.G, color.B }, 0, bytes, offset, (int)bpp);
					}
				}

				// turn the byte-array back into a bitmap
				System.Runtime.InteropServices.Marshal.Copy(bytes, 0, ptr, bytes.Length);
				bmp.UnlockBits(bmpdata);

				return bmp;
			}
			Bitmap UseGraphics(Bitmap bmp)
			{
				Color getColor(int x, int y)
				{
					if (this.grid[x, y] is Person)
						return ((Person)this.grid[x, y]).Color;
					else
						return (Color)this.grid[x, y].GetType().GetField("Color").GetValue(this.grid[x, y]);
				}

				var gr = Graphics.FromImage(bmp);
				Brush br;

				for (int x = 0; x < GridWidth; x++)
				{
					for (int y = 0; y < GridHeight; y++)
					{
						br = new SolidBrush(getColor(x, y));

						gr.FillRectangle(br, x * scaleSize.xScale, y * scaleSize.yScale, 1 * scaleSize.xScale, 1 * scaleSize.xScale);
					}
				}

				if (this.ShouldDrawPaths && !this.hasTicked)
				{
					Brush brush = new SolidBrush(Color.FromArgb(120, Color.Coral));

					foreach (Person p in this.persons)
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
            var bitmap = new Bitmap(GridWidth* scaleSize.xScale, GridHeight* scaleSize.yScale);
            // set DPI resolution
            return UseGraphics(bitmap);
        }

		// Instead of doing gridcontroller.Tick() and painting the result on the form for every time
		// the timer goes off, you can save a copy of this object and paint the next bitmap in this
		// every time the timer goes off. This also allows you to "go back" one tick, or "speed up"
		// the simulation.
		public AnimationFrames PaintAll((int xScale, int yScale) scaleSize)
        {
            return new AnimationFrames(this, scaleSize);
        }
		#endregion
		#region History
		public void AddToHistory(string reason)
		{
			this.gridHistory.Add(new History(reason, (Block[,])this.grid.Clone()));
		}

		public History[] GetHistory()
		{
			return this.gridHistory.ToArray();
		}

		public void ClearHistory()
		{
			this.gridHistory = new List<History>();
		}

		#endregion
		#region IO

		public static string defaultPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "grid.bin");

		private static Block[,] getSavedGrid(string path)
		{
			try
			{
				using (FileStream stream = new FileStream(path, FileMode.Open))
				{
					BinaryFormatter bformatter = new BinaryFormatter();

					return (Block[,])bformatter.Deserialize(stream);
				}
			}
			catch (SerializationException ex)
			{
				Console.WriteLine("Object could not be serialized. Error: " + ex.Message);
				return null;
			}
			catch (IOException ex)
			{
				Console.WriteLine("Object could not be saved. Error: " + ex.Message);
				return null;
			}
		}

		private bool setSavedGrid(string path)
		{
			try
			{
				using (FileStream stream = new FileStream(path, FileMode.Create))
				{
					BinaryFormatter bformatter = new BinaryFormatter();
					bformatter.Serialize(stream, this.grid);
					return true;
				}
			}
			catch (SerializationException ex)
			{
				Console.WriteLine("Object could not be serialized. Error: " + ex.Message);
				return false;
			}
			catch (IOException ex)
			{
				Console.WriteLine("Object could not be saved. Error: " + ex.Message);
				return false;
			}
		}

		/// <summary>
		/// Check if the current verison is savable
		/// </summary>
		/// <returns></returns>
		public bool IsSavable()
		{
			return getSavedGrid(defaultPath) == this.grid || getSavedGrid(defaultPath) != null;
		}

		/// <summary>
		/// Saving the grid
		/// </summary>
		/// <param name="path"></param>
		public bool Save(string path)
		{
			return setSavedGrid(path ?? defaultPath);
		}

		/// <summary>
		/// Checks if the saved version is loadable
		/// </summary>
		/// <returns></returns>
		public static bool IsLoadable()
		{
			return File.Exists(defaultPath);
		}

		/// <summary>
		/// Loading the grid
		/// </summary>
		/// <param name="path"></param>
		public void Load(string path)
		{
			if (string.IsNullOrEmpty(path))
				path = defaultPath;

			var grid = getSavedGrid(path ?? defaultPath);

			if (grid != null)
				this.grid = grid;
		}

		#endregion
		#region Other methods
		public object Clone()
        {
            var gc = new GridController(this.grid);
            return gc;
        }

        public Block[,] DeepCloneBlock()
        {
            Block[,] newGrid = new Block[grid.GetLength(0), grid.GetLength(1)];
            // Deep Copy the Grid
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j].GetType() == typeof(Person))
                    {
                        newGrid[i, j] = new Person();
                    }
                    else if (grid[i, j].GetType() == typeof(Wall))
                    {
                        newGrid[i, j] = new Wall();
                    }
                    else if (grid[i, j].GetType() == typeof(Floor))
                    {
                        newGrid[i, j] = new Floor();
                    }
                    else if (grid[i, j].GetType() == typeof(Fire))
                    {
                        newGrid[i, j] = new Fire();
                    }
                    else if (grid[i, j].GetType() == typeof(FireExtinguisher))
                    {
                        newGrid[i, j] = new FireExtinguisher();
                    }
                }
            }

            return newGrid;
        }

        public static Block[,] DeepCloneBlock(Block[,] grid)
        {
            Block[,] newGrid = new Block[grid.GetLength(0), grid.GetLength(1)];
            // Deep Copy the Grid
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j].GetType() == typeof(Person))
                    {
                        newGrid[i, j] = new Person();
                    }
                    else if (grid[i, j].GetType() == typeof(Wall))
                    {
                        newGrid[i, j] = new Wall();
                    }
                    else if (grid[i, j].GetType() == typeof(Floor))
                    {
                        newGrid[i, j] = new Floor();
                    }
                    else if (grid[i, j].GetType() == typeof(Fire))
                    {
                        newGrid[i, j] = new Fire();
                    }
                    else if (grid[i, j].GetType() == typeof(FireExtinguisher))
                    {
                        newGrid[i, j] = new FireExtinguisher();
                    }
                }
            }

            return newGrid;
        }

        public int GetFireExtinguisherSpot()
        {
            var floorSpots = this.GetFloorBlocks();
            var filteredSpots = floorSpots.Where(_ => this.HasNeighbor(_, this.grid, typeof(Wall))).ToList();

            return filteredSpots.Count;
        }

        public List<(int x, int y)> GetFloorBlocks()
        {
            var result = new List<(int x, int y)>();

            for (int x = 0; x < this.GridWidth; x++)
            {
                for (int y = 0; y < this.GridHeight; y++)
                {
                    if (this.grid[x, y].GetType() == typeof(Floor))
                    {
                        result.Add((x, y));
                    }
                }
            }

            return result;
        }

        private bool HasNeighbor((int x, int y) self, Block[,] grid, Type neighbor)
        {
            for (int XOffset = -1; XOffset <= 1; XOffset++)
            {
                for (int YOffset = -1; YOffset <= 1; YOffset++)
                {
                    if ((self.x + XOffset < 0) || (self.x + XOffset > grid.GetLength(0) - 1) || (self.y + YOffset < 0) || (self.y + YOffset > grid.GetLength(1) - 1) || (XOffset == 0 && YOffset == 0))
                        continue;

                    if (grid[(self.x + XOffset), (self.y + YOffset)].GetType() == neighbor) return true;
                }
            }

            return false;
        }

        public int GetNrOfPeople()
        {
            return persons.Count();
        }

        public int GetNrOfFireExtinguishers()
        {
            return fireExtinguishers.Count();
        }

        public int GetTotalDeaths()
        {
            return persons.Count(p => p.IsDead);
        }
		
		public void fillLists()
		{
			this.fireExtinguishers.Clear();
			this.persons.Clear();

			for (int x = 0; x < this.GridWidth; x++)
			{
				for (int y = 0; y < this.GridHeight; y++)
				{
					var val = grid[x, y];

					if (val is Person)
						this.persons.Add((Person)val);
					else if (val is FireExtinguisher)
						this.fireExtinguishers.Add((FireExtinguisher)val);
				}
			}
		}

		public Block GetAt((int x, int y) loc)
		{
			return this.grid[loc.x, loc.y];
		}

		private Pair[] GetFireExtinguishers(BackgroundWorker worker, DoWorkEventArgs e)
		{
			List<Pair> extinguishers = new List<Pair>();

			for (int x = 0; x < this.GridWidth; x++)
			{
				for (int y = 0; y < this.GridHeight; y++)
				{
					if (worker.CancellationPending == false)
					{
						if (this.grid[x, y] is FireExtinguisher)
							extinguishers.Add(new Pair(x, y));
					}
					else
					{
						e.Cancel = true;
						break;
					}
				}
			}

			return extinguishers.ToArray();
		}

		public Action SetupInDifferentThread(Action<bool> callback, Action<int> progress, Action<string> progressReport)
		{
			BackgroundWorker bg = new BackgroundWorker();
			List<Task> tasks = new List<Task>();
			bool cancelled = false;

			bg.WorkerSupportsCancellation = true;
			bg.WorkerReportsProgress = true;

			bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler((object o, RunWorkerCompletedEventArgs e) => callback(cancelled));
			bg.ProgressChanged += new ProgressChangedEventHandler((object o, ProgressChangedEventArgs e) => progress(e.ProgressPercentage));
			bg.DoWork += new DoWorkEventHandler((object o, DoWorkEventArgs e) =>
			{
				BackgroundWorker worker = o as BackgroundWorker;

				progressReport("Finding all fire extinguishers...");
				var fes = GetFireExtinguishers(worker, e);

				progressReport("Finding all persons...");
				for (int x = 0; x < this.GridWidth; x++)
				{
					for (int y = 0; y < this.GridHeight; y++)
					{
						if (worker.CancellationPending)
							break;
						else
						{
							Block entry = this.grid[x, y];

							if (entry is Person)
							{
								progressReport("Calculating path for person...");
								var task = ((Person)entry).CalculatePaths(this.grid, new Pair(x, y), fes, (worker, e), () =>
								{
									if (worker.CancellationPending)
										e.Cancel = true;
									else
									{
										var allFinishedTasks = (double)(tasks.FindAll(t => t.IsCompleted).Count + 1);
										worker.ReportProgress((int)Math.Floor(allFinishedTasks / tasks.Count * 100));
									}
								});

								tasks.Add(task);
							}
						}
					}
				}

				progressReport("Waiting for all A* calls to finish...");
				Task.WaitAll(tasks.ToArray());
				progressReport("Done!");
				e.Result = true;
			});

			bg.RunWorkerAsync();
			return () =>
			{
				cancelled = true;
				bg.CancelAsync();
			};
		}

		#endregion
		#endregion
	}

	/// <summary>
	/// A class to handle what, to the outside, looks like an array of images, but in reality is a
	/// bit more complicated because an actual array of bitmaps would take up a lot more memory.
	/// </summary>
	public class AnimationFrames
	{
		private Bitmap this[int index]
		{
			get
			{
				if (index >= lazyBitmaps.Length) return null;
				if (index < 0) return null;

				return this.lazyBitmaps[index].Value;
			}
		}

		private readonly Lazy<Bitmap>[] lazyBitmaps;
		private int index = 0;

		public AnimationFrames(GridController gridController, (int xScale, int yScale) scaleSize)
		{
			var gc = (GridController)gridController.Clone();
			var lb = new List<Lazy<Bitmap>>();

			do
			{
				//gc.Tick();
				var gc1 = (GridController)gc.Clone();

				lb.Add(new Lazy<Bitmap>(() => gc1.Paint(scaleSize)));
			}
			while (!gc.Ended());

			this.lazyBitmaps = lb.ToArray();
		}

		public bool Forward(int amount = 1)
		{
			if (amount < 0)
				return false;
			if (index + amount >= lazyBitmaps.Length)
				return false;

			index += amount;
			return true;
		}

		public bool Backward(int amount = 1)
		{
			if (amount < 0)
				return false;
			if (index - amount < 0)
				return false;

			index -= amount;
			return true;
		}

		public Image GetCurrentFrame()
		{
			return this[index];
		}
	}
}
