using System.Drawing;

namespace Library
{
	abstract class _2DPoint : IPaintable
	{
		public double X { get; private set; }
		public double Y { get; private set; }

		protected _2DPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		public abstract void Paint(Graphics g);
	}
}
