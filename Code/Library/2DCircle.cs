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
			return _2DPoint.Distance(this.Center, point) <= this.Radius;
		}

		public bool IntersectsWith(_2DLine line)
		{
			return line.IntersectsWith(this);
		}

		public bool IntersectsWith(_2DCircle circle)
		{
			// TODO: Check my math
			return _2DPoint.Distance(this.Center, circle.Center) <= this.Radius + circle.Radius;
		}

		public override string ToString()
		{
			return $"Center: {this.Center}; Radius: {this.Radius}";
		}
	}
}
