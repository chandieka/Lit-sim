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
		private Fire f;
		private Wall w;

		public AnimationPainter()
		{
			InitializeComponent();

			w = new Wall(new _2DPoint(50, 800), new _2DPoint(120, 0));
			p1 = new Person(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
			p2 = new Person(this.ClientSize.Width / 2 - 200, this.ClientSize.Height / 2);
			fe = new FireExtinguisher(this.ClientSize.Width - 500, 100);
			f = new Fire(new _2DPoint(10, 100));
			b = new Bitmap(cellAmnt, cellAmnt);

			//p1.Died();
			
			//for (int i = 0; i < 50; i++)
			//	f.Tick();
		}

		private void AnimationPainter_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = Graphics.FromImage(b);

			//f.Paint(g);
			//p1.Paint(g);
			//p2.Paint(g);
			//fe.Paint(g);
			//w.Paint(g);

			//Console.WriteLine(f.IntersectsWith(w));
			//Console.WriteLine(f.IntersectsWith(fe));
			//Console.WriteLine(f.IntersectsWith(p2));
			//Console.WriteLine(f.IntersectsWith(p1));

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
