using Library.Graphical;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Interface
{
	public partial class AnimationPainter : Form
	{
		private const int cellAmnt = 50;
		private Bitmap b;

		private FireExtinguisher fe;
		private Person p1;
		private Person p2;
		private Fire f1;
		private Fire f2;
		private Wall w;

		public AnimationPainter()
		{
			InitializeComponent();

			w = new Wall(new _2DPoint(30, 200), new _2DPoint(500, 0));
			p1 = new Person(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
			p2 = new Person(this.ClientSize.Width / 2 - 200, this.ClientSize.Height / 2);
			fe = new FireExtinguisher(100, 100);
			f1 = new Fire(new _2DPoint(0, 0));
			f2 = new Fire(new _2DPoint(200, 200));
			//b = new Bitmap(cellAmnt, cellAmnt);

			p1.Died();

			for (int i = 0; i < 150; i++)
			{
				f1.Tick();
				f2.Tick();
			}
		}

		private void AnimationPainter_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			f2.Paint(g);
			f1.Paint(g);
			p1.Paint(g);
			p2.Paint(g);
			fe.Paint(g);
			w.Paint(g);

			Console.WriteLine("Fire extinguisher\t" + f1.IntersectsWith(fe));
			Console.WriteLine("Person 2\t\t\t" + f1.IntersectsWith(p2));
			Console.WriteLine("Person 1\t\t\t" + f1.IntersectsWith(p1));
			Console.WriteLine("Fire\t\t\t\t" + f1.IntersectsWith(f2));
			Console.WriteLine("Wall\t\t\t\t" + f2.IntersectsWith(w));

			//this.gridTest(e);
		}

		private void gridTest(PaintEventArgs e)
		{
			Graphics g = Graphics.FromImage(b);
			g.FillEllipse(Brushes.Red, 0, 0, b.Width / 2, b.Height / 2);

			int size = Math.Min(this.ClientSize.Width, this.ClientSize.Height);
			Rectangle mainRect = new Rectangle(0, 0, size, size);

			e.Graphics.FillRectangle(Brushes.Gray, mainRect);
			e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(b, mainRect);

			// Grid
			double s = (size / b.Width);
			Font font = new Font(new FontFamily("Segoe UI"), (int)(s / 2));
			int c = (int)(s / 2 - font.Height / 2);
			e.Graphics.DrawString("1", font, Brushes.Black, c, c);
			for (int i = 1; i <= cellAmnt; i++)
			{
				int pos = (int)(s * i);

				e.Graphics.DrawLine(Pens.Black, pos, 0, pos, size);
				e.Graphics.DrawLine(Pens.Black, 0, pos, size, pos);
				e.Graphics.DrawString((i + 1).ToString(), font, Brushes.Black, pos, c);
				e.Graphics.DrawString((i + 1).ToString(), font, Brushes.Black, c, pos);
			}
		}
	}
}
