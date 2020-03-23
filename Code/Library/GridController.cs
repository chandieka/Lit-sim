using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Library
{
    public class GridController
    {
        #region Private Fields

        private Block[,] grid;

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
            this.grid[location.x, location.y] = new Wall();
        }

        public void FillWall((int x, int y) topLeft, int width, int height)
        {
            // Only for horizon and vertical wall
         
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
            this.grid[location.x, location.y] = new Person();
        }

        public void PutFire((int x, int y) location)
        {
            this.grid[location.x, location.y] = new Fire();
        }

        public void PutFireExtinguisher((int x, int y) location)
        {
            this.grid[location.x, location.y] = new FireExtinguisher();
        }
        
        public void PutDefaultFloorPlan()
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
            
            // check whether the grid size is in ratio of 10
            if (this.GridHeight % 10 == 0 & this.GridWidth % 10 == 0)
            {
                int heightScale = GridHeight / 10;
                int widthScale = GridWidth / 10;
                int wallThickness = 1;

                // Do horizonal wall fill
                // AB
                FillWall((0, 0), GridWidth, wallThickness);
                // LM
                FillWall((4 * widthScale, 3 * heightScale), 3 * widthScale, wallThickness);
                // IK
                FillWall((0 * widthScale, 4 * heightScale), 4 * widthScale, wallThickness);
                // QF
                FillWall((6 * widthScale, 6 * heightScale), 4 * widthScale, wallThickness);
                // JN
                FillWall((0 * widthScale, 7 * heightScale), 4 * widthScale, wallThickness);
                // OP
                FillWall((4 * widthScale, 8 * heightScale), 2 * widthScale, wallThickness);
                // CD
                FillWall((0 * widthScale, GridHeight - 1), GridWidth, wallThickness);

                // Do vertical wall fill
                // AC
                FillWall((0, 0), wallThickness, GridHeight);
                // LK
                FillWall((4 * widthScale, 3 * heightScale), wallThickness, 1 * heightScale);
                // NH
                FillWall((4 * widthScale, 7 * heightScale), wallThickness, 3 * heightScale);
                // QG
                FillWall((6 * widthScale, 6 * heightScale), wallThickness, 4 * heightScale);
                // ER
                FillWall((7 * widthScale, 0 * heightScale), wallThickness, 6 * heightScale);
                // BD
                FillWall((GridWidth - 1, 0 * heightScale), wallThickness, GridHeight);


                //     Do horizonal door fill

                //     Do vertical door fill

                // Fill all empty array as floor
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
        public Bitmap Paint()
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

                        gr.FillRectangle(br, x, y, 1, 1);
                    }
                }

                return bmp;
            }

            // create a new bitmap
            var bitmap = new Bitmap(GridWidth, GridHeight);
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
