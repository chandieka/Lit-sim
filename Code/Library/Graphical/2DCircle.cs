namespace Library.Graphical
{
	public class _2DCircle
	{
		/// <summary>
		/// The radius of the circle.
		/// </summary>
		public double Radius { get; protected set; } = 0;
		/// <summary>
		/// The middle point of the circle.
		/// </summary>
		public readonly _2DPoint Center;

		protected _2DCircle(_2DPoint center)
		{
			Center = center;
		}

		// overrides
		public override string ToString() => $"Center: {this.Center}; Radius: {this.Radius}";
	}
}
