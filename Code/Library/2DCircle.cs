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

		// overrides
		public override string ToString() => $"Center: {this.Center}; Radius: {this.Radius}";
	}
}
