using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Library
{
    public class GridController
    {
        #region Private Fields
        // playing fields
        private Block[,] grid;

        // Blocks 
        private List<Block> persons;
        private List<Block> fireExtinguishers;
        private List<Block> walls;

        #endregion

        #region Public Properties

        public int GridWidth => this.grid.GetLength(0);
        public int GridHeight => this.grid.GetLength(1);

        #endregion

        #region Constructor

        public GridController((int width, int height) gridSize)
        {
            this.grid = new Block[gridSize.width, gridSize.height];

            // fill the grid with empty blocks.
            for (int x = 0; x < this.grid.GetLength(0); x++)
            {
                for (int y = 0; y < this.grid.GetLength(1); y++)
                {
                    this.grid[x, y] = Block.Empty;
                }
            }

            persons = new List<Block>();
            fireExtinguishers = new List<Block>();
            walls = new List<Block>();
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
        }
        public void PutFloor((int x, int y) location)
        {
            this.grid[location.x, location.y] = new Floor();
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
        public void PutWall((int x, int y) location)
        {
            Wall nwWall = new Wall(new Tuple<int, int>(location.x, location.y));
            this.grid[location.x, location.y] = nwWall;
            walls.Add(nwWall);
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

        public void PutPerson((int x, int y) location)
        {
            Person nwPerson = new Person(new Tuple<int, int>(location.x, location.y));
            this.grid[location.x, location.y] = nwPerson;
            persons.Add(nwPerson);
        }

        public bool PutPersons(int persons, int seeds = 0)
        { 
            if (persons > 0)
            {
                Random rand;

                if (seeds != 0)
                {
                    rand = new Random(seeds);
                }

                rand = new Random();

                for (int i = 0; i < persons; i++)
                {
                    bool isPlace = false;

                    while (!isPlace)
                    {
                        int x = rand.Next(0, GridWidth);
                        int y = rand.Next(0, GridHeight);

                        if (grid[x,y] is Floor && !(grid[x, y] is Person))
                        {
                            PutPerson((x, y));
                            isPlace = true;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PutFire((int x, int y) location)
        {
            this.grid[location.x, location.y] = new Fire();
        }

        public void PutFireExtinguisher((int x, int y) location)
        {
            this.grid[location.x, location.y] = new FireExtinguisher();
        }
        public bool PutFireExtinguishers(int fireExtinguishers)
        {
            if (fireExtinguishers > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PutDefaultFloorPlan(int _thickness)
        {
            /// <summary>
            /// TODO:
            ///     check the scale of the grid array if its scalable by 10
            ///     Do horizonal wall fill
            ///     Do vertical wall fill
            ///     Do horizonal door fill
            ///     Do vertical door fill
            /// </summary>
            /// 
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
                    FillWall((4 * widthScale, 3 * heightScale), thickness, 1 * heightScale);
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
                else
                {

                }
            }
            else
            {

            }
        }

        public void Tick()
        {
            for (int x = 0; x < this.grid.GetLength(0); x++)
            {
                for (int y = 0; y < this.grid.GetLength(1); y++)
                {
                    switch (this.grid[x, y])
                    {
                        case FunctionalBlock fb:
                            this.grid = fb.Function(this.grid);
                            break;
                        //case Block bl:
                        //     Do nothing?
                        //   break;
                    }
                }
            }
        }
        #endregion
        #region Grid Visualization
        public Bitmap Paint((int xScale, int yScale)scaleSize)
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
                var gr = Graphics.FromImage(bmp);
                Brush br;

                for (int x = 0; x < GridWidth; x++)
                {
                    for (int y = 0; y < GridHeight; y++)
                    {
                        var color = (Color)this.grid[x, y].GetType().GetField("color").GetValue(this.grid[x, y]);
                        br = new SolidBrush(color);

                        gr.FillRectangle(br, x * scaleSize.xScale, y * scaleSize.yScale, 1 * scaleSize.xScale, 1 * scaleSize.xScale);
                    }
                }

                return bmp;
            }

            // create a new bitmap
            var bitmap = new Bitmap(GridWidth* scaleSize.xScale, GridHeight* scaleSize.yScale);
            // set DPI resolution
            return UseGraphics(bitmap);
        }
        #endregion
        #region IO
        private string defaultPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "grid.bin");
        private Block[,] getSavedGrid(string path)
        {
            try
            {
                using (Stream stream = File.Open(path, FileMode.Open, FileAccess.Read))
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
                using (Stream stream = File.Open(path, FileMode.Create, FileAccess.Write))
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
            return getSavedGrid(defaultPath) != this.grid;
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
        public bool IsLoadable()
        {
            return File.Exists(defaultPath);
        }

        /// <summary>
        /// Loading the grid
        /// </summary>
        /// <param name="path"></param>
        public bool Load(string path = null)
        {
            var savedGrid = getSavedGrid(path ?? defaultPath);

            if (savedGrid == null) return false;

            this.grid = savedGrid;
            return true;
        }
        #endregion
        #endregion
    }
}
