namespace Library
{
	class FlammablePoint : _2DPoint
	{
		public bool onFire { get; private set; } = false;

		protected FlammablePoint(double x, double y) : base(x, y) { }

		public void Light()
		{
			onFire = true;
		}
	}
}
