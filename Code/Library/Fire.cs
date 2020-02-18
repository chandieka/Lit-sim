using System.Drawing;

namespace Library
{
	class Fire : _2DCircle, IAnimatedObject
	{
		private readonly static Brush Brush = new SolidBrush(Color.Red);

		public Fire(_2DPoint center) : base(center) { }

		public void Tick()
		{
			// TODO
		}

		public override void Paint(Graphics ctx)
		{
			Rectangle rect = new Rectangle(
				(int)(this.Center.X - Radius),
				(int)(this.Center.Y - Radius),
				(int) this.Radius,
				(int) this.Radius
			);

			g.FillEllipse(Fire.Brush, rect);
		}
	}
}
