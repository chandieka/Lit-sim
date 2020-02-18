using System.Drawing;

namespace Library
{
	public class _2DPoint
	{
		public double X { get; private set; }
		public double Y { get; private set; }

		protected _2DPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}
		
		public static _2DPoint MakeNew(double x, double y)
		{
			return new _2DPoint(x, y);
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
