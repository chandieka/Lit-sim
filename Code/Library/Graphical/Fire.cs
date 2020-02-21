using System.Drawing;

namespace Library.Graphical
{
	public class Fire : _2DCircle, IPaintable, IChangeableObject
	{
		private readonly static Brush Brush = new SolidBrush(Color.Red);
		/// <summary>
		/// The rate at which the fire's radius will increase.
		/// </summary>
		private readonly static double SpreadSpeed = 1;

		public Fire(_2DPoint center) : base(center) { }

		/// <summary>
		/// Move the fire to its next frame in the animation.
		/// </summary>
		public void Tick()
		{
			// TODO
			this.Radius+= Fire.SpreadSpeed;
		}

		/// <summary>
		/// Paint the fire on the given graphics object.
		/// </summary>
		/// <param name="g"></param>
		public void Paint(Graphics g)
		{
			RectangleF rect = new RectangleF(
				(float)(this.Center.X - Radius),
				(float)(this.Center.Y - Radius),
				(float)(this.Radius * 2),
				(float)(this.Radius * 2)
			);

			g.FillEllipse(Fire.Brush, rect);
		}
	}
}
