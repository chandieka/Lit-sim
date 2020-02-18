using System.Drawing;

namespace Library
{
	abstract class _2DCircle : IPaintable
	{
		public double Radius { get; private set; } = 0;
		public readonly _2DPoint Center;

		protected _2DCircle(_2DPoint center)
		{
			Center = center;
		}

		abstract public void Paint(Graphics ctx);
	}
}
