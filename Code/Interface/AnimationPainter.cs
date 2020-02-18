using System.Windows.Forms;
using Library;

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

			w = new Wall(_2DPoint.MakeNew(0, 0), _2DPoint.MakeNew(this.ClientSize.Width, this.ClientSize.Height));
			p1 = new Person(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
			p2 = new Person(this.ClientSize.Width / 2 - 200, this.ClientSize.Height / 2);
			fe = new FireExtinguisher(this.ClientSize.Width - 500, 100);
			f = new Fire(_2DPoint.MakeNew(0, 0));

			p1.Died();

			for (int i = 0; i < 100; i++)
				f.Tick();
		}

		private void AnimationPainter_Paint(object sender, PaintEventArgs e)
		{
			p1.Paint(e.Graphics);
			p2.Paint(e.Graphics);
			fe.Paint(e.Graphics);
			f.Paint(e.Graphics);
			w.Paint(e.Graphics);
		}
	}
}
