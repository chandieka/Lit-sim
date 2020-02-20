using System;
using System.Drawing;

namespace Library
{
	public class _2DPoint
	{
		public double X { get; protected set; }
		public double Y { get; protected set; }

		protected _2DPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		public static _2DPoint MakeNew(double x, double y)
		{
			return new _2DPoint(x, y);
		}

		public static double Distance(_2DPoint p1, _2DPoint p2)
		{
			return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
		}

		public Point ToPoint()
		{
			return new Point((int)this.X, (int)this.Y);
		}

		public override string ToString()
		{
			return $"X: {X}, Y: {Y}";
		}
	}
}
