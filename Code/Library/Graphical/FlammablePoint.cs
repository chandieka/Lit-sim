namespace Library.Graphical
{
	public class FlammablePoint : _2DPoint
	{
		/// <summary>
		/// Check if the object is on fire.
		/// </summary>
		public bool OnFire { get; private set; } = false;

		protected FlammablePoint(double x, double y) : base(x, y) { }

		/// <summary>
		/// Set the object on fire.
		/// </summary>
		public void Light()
		{
			OnFire = true;
		}
	}
}
