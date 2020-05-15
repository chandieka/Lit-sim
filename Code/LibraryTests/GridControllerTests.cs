using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Library.Tests
{
    [TestClass]
    public class GridControllerTests
    {
        [TestMethod, TestCategory("Interface Tests")]
        public void PaintFloorTest()
        {
            List<bool> GetHash(Bitmap bmpSource)
            {
                List<bool> lResult = new List<bool>();
                //create new image with 16x16 pixel
                Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
                for (int j = 0; j < bmpMin.Height; j++)
                {
                    for (int i = 0; i < bmpMin.Width; i++)
                    {
                        //reduce colors to true / false                
                        lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                    }
                }
                return lResult;
            }

            var gc = new GridController((100, 100));

            gc.PutDefaultFloorPlan(1);
            var outputImage = gc.Paint((10, 10));

            // create a 16 by 16 hash for both the saved, correct image and the output image
            var outputHash = GetHash(outputImage);
            var correctHash = GetHash(LibraryTests.Properties.Resources.DefaultFloorplanImage);

            // assume that when at least 90% of the images match (because of compression incosistencies), the algorithm is correct
            var possibleCorrectCount = 16 * 16;
            var realCorrectCount = outputHash.Zip(correctHash, (x, y) => x == y).Count(eq => eq);

            Assert.IsTrue(realCorrectCount >= possibleCorrectCount * .9d);
        }

        [TestMethod, TestCategory("Person Tests")]
        public void PutPersonTest()
        {
            var gc = new GridController((10, 10));
            gc.PutPerson((4, 5));
            gc.PutPerson((8, 9));

            //Assert.AreEqual(2, gc.GetNrOfPeople());
        }

        [TestMethod, TestCategory("Person Tests")]
        public void PutRandomPersonTest()
        {
            var gc = new GridController((10, 10));
            gc.FillFloor((0, 0), 10, 10);
            gc.RandomizePersons(4);

            //Assert.AreEqual(4, gc.GetNrOfPeople());
        }

        [TestMethod, TestCategory("Fire Extinguisher Tests")]
        public void PutFireExtinguisherTest()
        {
            var gc = new GridController((10, 10));
            gc.PutFireExtinguisher((3, 3));
            gc.PutFireExtinguisher((4, 7));

            //Assert.AreEqual(2, gc.GetNrOfFireExtinguishers());
        }

        [TestMethod, TestCategory("Fire Extinguisher Tests")]
        public void PutRandomFireExtinguisherTest()
        {
            var gc = new GridController((10, 10));
            gc.FillFloor((0, 0), 10, 10);
            gc.FillWall((1, 5), 8, 2);
            gc.RandomizeFireExtinguishers(4);

            //Assert.AreEqual(4, gc.GetNrOfFireExtinguishers());
        }

        [TestMethod, TestCategory("Fire Extinguisher Tests")]
        public void FailingPutRandomFireExtinguisherTest()
        {
            var gc = new GridController((10, 10));
            gc.FillFloor((0, 0), 10, 10);

            Assert.IsFalse(gc.RandomizeFireExtinguishers(5));
        }
    }
}