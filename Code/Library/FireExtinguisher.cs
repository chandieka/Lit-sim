using System.Drawing;

namespace Library
{
	public class FireExtinguisher : FlammablePoint, IPaintable
	{
		private readonly static Brush Brush = new SolidBrush(Color.Green);
		private static readonly int PaintSize = 8;

		public const double Range = 10;

		public FireExtinguisher(double x, double y) : base(x, y) { }

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
	}
}
