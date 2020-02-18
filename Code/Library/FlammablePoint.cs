using System.Drawing;

namespace Library
{
	public class FlammablePoint : _2DPoint
	{
		public bool OnFire { get; private set; } = false;

		protected FlammablePoint(double x, double y) : base(x, y) { }

		public void Light()
		{
			OnFire = true;
		}
	}
}
