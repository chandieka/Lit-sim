using System.Drawing;

namespace Library.Graphical
{
	public class Wall : _2DFiniteLine, IPaintable
	{
		private readonly static Pen Pen = Pens.Black;

		public Wall(_2DPoint start, _2DPoint end) : base(start, end) { }

		/// <summary>
		/// Paint the wall on the given graphics object.
		/// </summary>
		/// <param name="g"></param>
		public void Paint(Graphics g)
		{
			g.DrawLine(Wall.Pen, this.StartPoint.ToPoint(), this.EndPoint.ToPoint());
		}
	}
}
