﻿using Library;
using System;
using System.Windows.Forms;

namespace Interface
{
	public partial class AnimationPainter : Form
	{
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

			p1.Died();

			for (int i = 0; i < 100; i++)
				f.Tick();
		}

		private void AnimationPainter_Paint(object sender, PaintEventArgs e)
		{
			f.Paint(e.Graphics);
			p1.Paint(e.Graphics);
			p2.Paint(e.Graphics);
			fe.Paint(e.Graphics);
			w.Paint(e.Graphics);

			Console.WriteLine(f.IntersectsWith(w));
			Console.WriteLine(f.IntersectsWith(fe));
			Console.WriteLine(f.IntersectsWith(p2));
			Console.WriteLine(f.IntersectsWith(p1));
		}
	}
}
