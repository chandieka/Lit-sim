using System;
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
            //gc.RandomizePersons(10);
            //gc.RandomizeFireExtinguishers(10);

            //gc.FillWall((1, 2), 5, 1);
            //gc.PutPerson((8, 3));
            //gc.PutPerson((8, 5));

            // generate a bitmap from the grid
            var bmp = gc.Paint((10, 10));

            // store the bimap in a file
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\mylayout.bmp";

            bmp.Save(path, bmp.RawFormat);

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
