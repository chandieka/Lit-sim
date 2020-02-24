using System.Drawing;

namespace Library.Graphical
{
	public class FireExtinguisher : FlammablePoint, IPaintable
	{
		private readonly static Brush Brush = new SolidBrush(Color.Green);
		private static readonly int PaintSize = 10;

		/// <summary>
		/// The radius of the circle in which fires will be extinguished.
		/// </summary>
		public const double Range = 10;
		/// <summary>
		/// See if the fire extinguisher is already picked up by someone.
		/// </summary>
		public bool Used { get; private set; } = false;

		public FireExtinguisher(double x, double y) : base(x, y) { }

		/// <summary>
		/// Paint the fire extinguisher on the given graphics object.
		/// </summary>
		/// <param name="g"></param>
		public void Paint(Graphics g)
		{
			float sizeHalf = FireExtinguisher.PaintSize / 2;

			g.FillRectangle(FireExtinguisher.Brush, new Rectangle(
				(int) (this.X - sizeHalf),
				(int) (this.Y - sizeHalf),
				FireExtinguisher.PaintSize,
				FireExtinguisher.PaintSize
			));
		}

		/// <summary>
		/// Indicate that the fire extinguisher has been/is being used.
		/// </summary>
		public void Use()
		{
			this.Used = true;
		}
	}
}
