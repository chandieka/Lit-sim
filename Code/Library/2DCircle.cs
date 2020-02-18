using System;

namespace Library
{
	public class _2DCircle
	{
		public double Radius { get; protected set; } = 0;
		public readonly _2DPoint Center;

		protected _2DCircle(_2DPoint center)
		{
			Center = center;
		}

		public bool IntersectsWith(_2DPoint point)
		{
			return Math.Pow(point.X - this.Center.X, 2) + Math.Pow(point.Y - this.Center.Y, 2) <= Math.Pow(this.Radius, 2);
		}
	}
}
