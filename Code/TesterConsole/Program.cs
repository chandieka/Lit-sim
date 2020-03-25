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
            Console.WriteLine("Supplied arguments: " + string.Join(", ", args));

            // create a new Grid
            var gc = new GridController((100, 100));

            //gc.Load(string.Empty);
            // add some random data to the grid
            gc.PutDefaultFloorPlan(1);
            gc.PutPersons(10);
            gc.PutFireExtinguishers(10);

            //gc.FillWall((1, 2), 5, 1);
            //gc.PutPerson((8, 3));
            //gc.PutPerson((8, 5));

            // generate a bitmap from the grid
            var bmp = gc.Paint((10, 10));

            // store the bimap in a file
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/mylayout.png";

            bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);

            // report success
            Console.WriteLine("Successfully saved to " + path);
            Console.ReadKey();
        }

        #pragma warning disable IDE0051 // disable the warning about the un-used method.
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
