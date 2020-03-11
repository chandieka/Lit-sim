using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class GridController
    {
        private Block[,] grid;
        
        public int GridWidth => this.grid.GetLength(0);
        public int GridHeight => this.grid.GetLength(1);

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
                        case Block bl:
                            // Do nothing?
                            break;
                    }
                }
            }
        }
        public Bitmap Paint()
        {
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
    }
}
