using System;
using System.Drawing;

namespace Library
{
	public class _2DPoint
	{
		public double X { get; protected set; }
		public double Y { get; protected set; }

		public _2DPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		// static point info
		public static double CalculateDistanceX(_2DPoint a, _2DPoint b) => a.X - b.X;
		public static double CalculateDistanceY(_2DPoint a, _2DPoint b) => a.Y - b.Y;
		public static double CalculateDistance(_2DPoint a, _2DPoint b)=> Math.Sqrt(Math.Pow(_2DPoint.CalculateDistanceX(a, b), 2) + Math.Pow(_2DPoint.CalculateDistanceY(a, b), 2));

		public Point ToPoint() => new Point((int)this.X, (int)this.Y);
		public PointF ToPointF() => new PointF((float)this.X, (float)this.Y);

		// overrides
		public override string ToString() => $"X: {X}, Y: {Y}";
	}
}
