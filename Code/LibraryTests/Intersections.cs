using System;
using System.IO;
using Library.Graphical;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTests
{
    [TestClass]
    public class Intersections
    {
        [TestMethod]
        public void PointPoint()
        {
            const bool Expected = false;

            var p1 = new _2DPoint(2.41, 5.66);
            var p2 = new _2DPoint(3.14, 5.66);

            var result = p1.IntersectsWith(p2);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void PointLine()
        {
            const bool Expected = false;

            var p1 = new _2DPoint(2.41, 5.66);
            var l1 = new _2DLine(new _2DPoint(3.14, 5.66), 0.50);

            var result = p1.IntersectsWith(l1);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void PointCircle()
        {
            const bool Expected = true;

            var p1 = new _2DPoint(2.41, 5.66);
            var c1 = new _2DCircle(new _2DPoint(3.14, 5.66), 3.00);

            var result = p1.IntersectsWith(c1);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void LineLine()
        {
            const bool Expected = true;

            var l1 = new _2DLine(new _2DPoint(0.00, 0.00), 1.00);
            var l2 = new _2DLine(new _2DPoint(0.00, 5.00), -0.50);

            var result = l1.IntersectsWith(l2);

            Assert.AreEqual(Expected, result);
        }

        // TODO
        // - add LineLine for parallel lines
        // - add LineLine for intersection beyond integer-sized coordinate

        [TestMethod]
        public void LineCircle()
        {
            const bool Expected = true;

            var l1 = new _2DLine(new _2DPoint(0.00, 0.00), 1.00);
            var c1 = new _2DCircle(new _2DPoint(1.00, 2.00), 1.50);

            var result = l1.IntersectsWith(c1);

            Assert.AreEqual(Expected, result);
        }

        // TODO
        // - add LineCircle for a line through the circle's center
        // - add LineCircle for a line through the edge of the circle

        [TestMethod]
        public void CircleCircle()
        {
            const bool Expected = false;

            var c1 = new _2DCircle(new _2DPoint(5.00, 5.00), 7.00);
            var c2 = new _2DCircle(new _2DPoint(-5.00, -6.00), 2.00);

            var result = c1.IntersectsWith(c2);

            Assert.AreEqual(Expected, result);
        }

        // TODO
        // - add CircleCircle where one circle's center is within the other's range 
        // - add CircleCircle where they just barely touch eachother
    }
}
