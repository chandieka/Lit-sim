using System;
using System.Drawing;

namespace Library
{
	public class Fire : _2DCircle, IPaintable, IChangeableObject
	{
		private readonly static Brush Brush = new SolidBrush(Color.Red);
		private readonly static double SpreadSpeed = 1;

		public Fire(_2DPoint center) : base(center) { }

		public void Tick()
		{
			// TODO

			// TMP
			this.Radius++;
		}

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
