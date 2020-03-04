using System;
using System.IO;
using Library.Graphical;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTests
{
    [TestClass]
    [TestCategory("Point, Point intersection")]
    public class PointPoint
    {
        private readonly _2DPoint p1 = new _2DPoint(2.41, 5.66);
        private readonly _2DPoint p2 = new _2DPoint(3.14, 5.66);
        private readonly _2DPoint p3 = new _2DPoint(2.41, 5.66);

        [TestMethod]
        public void ExpectedFalse()
        {
            const bool Expected = false;

            var result = p1.IntersectsWith(p2);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void ExpectedTrue()
        {
            const bool Expected = true;

            var result = p1.IntersectsWith(p3);

            Assert.AreEqual(Expected, result);
        }
    }

    [TestClass]
    [TestCategory("Point, Line intersection")]
    public class PointLine
    {
        private readonly _2DPoint p1 = new _2DPoint(2.41, 5.66);
        private readonly _2DPoint p2 = new _2DPoint(3.14, 5.66);

        [TestMethod]
        public void ExpectedFalse()
        {
            const bool Expected = false;

            var slope = 0.10;
            var l1 = new _2DLine(p1, slope);

            var result = p2.IntersectsWith(l1);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void ExpectedTrue()
        {
            const bool Expected = true;

            var slope = _2DPoint.CalculateDistanceY(p1, p2) / _2DPoint.CalculateDistanceX(p1, p2);
            var l1 = new _2DLine(p1, slope);

            var result = p2.IntersectsWith(l1);

            Assert.AreEqual(Expected, result);
        }
    }

    [TestClass]
    [TestCategory("Point, Circle intersection")]
    public class PointCircle
    {
        private readonly _2DPoint p1 = new _2DPoint(0.00, 0.00);
        private readonly _2DPoint p2 = new _2DPoint(3.14, 5.66);
        private readonly _2DPoint p3 = new _2DPoint(1.50, 2.00);

        [TestMethod]
        public void ExpectedFalse()
        {
            const bool Expected = false;

            var c1 = new _2DCircle(p1, 3.00);

            var result = p2.IntersectsWith(c1);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void ExpectedTrue()
        {
            const bool Expected = true;

            var c1 = new _2DCircle(p1, 3.00);

            var result = p3.IntersectsWith(c1);

            Assert.AreEqual(Expected, result);
        }
    }

    [TestClass]
    [TestCategory("Line, Line intersection")]
    public class LineLine
    {
        private readonly _2DPoint p1 = new _2DPoint(2.41, 5.66);
        private readonly _2DPoint p2 = new _2DPoint(3.14, 5.66);

        [TestMethod]
        public void SameLines()
        {
            const bool Expected = true;

            var l1 = new _2DLine(p1, 1.00);
            var l2 = new _2DLine(p1, 1.00);

            var result = l1.IntersectsWith(l2);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void ParallelLines()
        {
            const bool Expected = false;

            var l1 = new _2DLine(p1, 1.00);
            var l2 = new _2DLine(p2, 1.00);

            var result = l1.IntersectsWith(l2);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void CrossingLines()
        {
            const bool Expected = true;

            var l1 = new _2DLine(p1, 1.00);
            var l2 = new _2DLine(p2, -0.50);

            var result = l1.IntersectsWith(l2);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void CrossingLinesOutOfRange()
        {
            const bool Expected = true;

            var l1 = new _2DLine(p1, 1.00);

            var p3 = l1.PointForX(double.PositiveInfinity);
            var slope = (p3.Y - p1.Y) / (p3.X - p1.X);

            var l2 = new _2DLine(p2, slope);

            var result = l1.IntersectsWith(l2);

            Assert.AreEqual(Expected, result);
        }
    }

    [TestClass]
    [TestCategory("Line, Circle intersection")]
    public class LineCircle
    {
        private readonly _2DCircle c1 = new _2DCircle(new _2DPoint(1.00, 2.00), 1.50);

        [TestMethod]
        public void LineNotThroughCircle()
        {
            const bool Expected = false;

            var l1 = new _2DLine(new _2DPoint(2.00, 0.00), 1.00);

            var result = l1.IntersectsWith(c1);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void LineThroughCircleEdge()
        {
            const bool Expected = true;

            var l1 = new _2DLine(new _2DPoint(0.00, 0.50), 0.00);

            var result = l1.IntersectsWith(c1);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void LineThroughCircle()
        {
            const bool Expected = true;

            var l1 = new _2DLine(new _2DPoint(0.00, 0.00), 1.00);

            var result = l1.IntersectsWith(c1);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void LineThroughCircleCenter()
        {
            const bool Expected = true;

            var l1 = new _2DLine(new _2DPoint(0.00, 2.00), 0.00);

            var result = l1.IntersectsWith(c1);

            Assert.AreEqual(Expected, result);
        }
    }

    [TestClass]
    [TestCategory("Circle, Circle intersection")]
    public class CircleCircle
    {
        private readonly _2DPoint p1 = new _2DPoint(5.00, 5.00);
        private readonly _2DPoint p2 = new _2DPoint(-5.00, -6.00);

        [TestMethod]
        public void SameCircles()
        {
            const bool Expected = true;

            var c1 = new _2DCircle(p1, 7.00);
            var c2 = new _2DCircle(p1, 7.00);

            var result = c1.IntersectsWith(c2);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void InnerCircle()
        {
            const bool Expected = true;

            var c1 = new _2DCircle(p1, 7.00);
            var c2 = new _2DCircle(p1, 4.00);

            var result = c1.IntersectsWith(c2);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void NotOverlappingCircles()
        {
            const bool Expected = false;

            var c1 = new _2DCircle(p1, 7.00);
            var c2 = new _2DCircle(p2, 2.00);

            var result = c1.IntersectsWith(c2);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TouchingCircles()
        {
            const bool Expected = true;

            var c1 = new _2DCircle(p1, 7.00);
            var c2 = new _2DCircle(p2, _2DPoint.CalculateDistance(p1, p2) - 7.00);

            var result = c1.IntersectsWith(c2);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void SlightlyOverlappingCircles()
        {
            const bool Expected = true;

            var c1 = new _2DCircle(p1, 7.00);
            var c2 = new _2DCircle(p2, _2DPoint.CalculateDistance(p1, p2) - 6.50);

            var result = c1.IntersectsWith(c2);

            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void MuchOverlappingCircles()
        {
            const bool Expected = true;

            var c1 = new _2DCircle(p1, 7.00);
            var c2 = new _2DCircle(p2, _2DPoint.CalculateDistance(p1, p2));
            Console.WriteLine(_2DPoint.CalculateDistance(p1, p2));

            var result = c1.IntersectsWith(c2);

            Assert.AreEqual(Expected, result);
        }
    }
}
