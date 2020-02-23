using System;
using System.Drawing;

namespace Library.Graphical
{
	public class _2DPoint
	{
		/// <summary>
		/// The X value of the location of this object.
		/// </summary>
		public double X { get; protected set; }
		/// <summary>
		/// The Y value of the location of this object.
		/// </summary>
		public double Y { get; protected set; }

		public _2DPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		// static point info
		/// <summary>
		/// Calculate the difference between the X values of the 2 given points.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static double CalculateDistanceX(_2DPoint a, _2DPoint b) => 
			a.X - b.X;
		
		/// <summary>
		/// Calculate the difference between the Y values of the 2 given points.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static double CalculateDistanceY(_2DPoint a, _2DPoint b) => 
			a.Y - b.Y;
		
		/// <summary>
		/// Calculate the difference between the values of the 2 given points.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static double CalculateDistance(_2DPoint a, _2DPoint b)
		{
			// Pythagoras: a^2 + b^2 = c^2 => c = √(a^2 + b^2)
			return Math.Sqrt(Math.Pow(_2DPoint.CalculateDistanceX(a, b), 2) + Math.Pow(_2DPoint.CalculateDistanceY(a, b), 2));
		}

		/// <summary>
		/// Convert the object to System.Drawing.Point, which can be used for painting.
		/// </summary>
		/// <returns></returns>
		public Point ToPoint() => 
			new Point((int)this.X, (int)this.Y);
		
		/// <summary>
		/// Conver the object to System.Drawing.PointF, which can be used for painting.
		/// </summary>
		/// <returns></returns>
		public PointF ToPointF() =>
			new PointF((float)this.X, (float)this.Y);

		// overrides
		public override string ToString() => $"X: {X}, Y: {Y}";
	}
}
