using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Library;

namespace TesterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new Grid
            var gc = new GridController((10, 10));

            gc.Load(string.Empty);
            // add some random data to the grid
            gc.FillFloor((1, 3), 5, 5);
            gc.FillWall((1, 2), 5, 1);
            gc.PutPerson((8, 3));
            gc.PutPerson((8, 5));
            
            // generate a bitmap from the grid
            var bmp = gc.Paint();

            // store the bimap in a file
            var path = "C:\\Users\\user\\Pictures\\mypng.png";

            bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);

            // report success
            Console.WriteLine("Success!");
            Console.ReadKey();
        }

        static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.WriteLine(array[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
