using System.Drawing;

namespace Library
{
	public class Person : _2DPoint, IPaintable, IChangeableObject
	{
		private readonly static Brush HoldsExtinguisherBrush = new SolidBrush(Color.Orange);
		private readonly static Brush MainBrush = new SolidBrush(Color.Blue);
		private readonly static Pen DeathPen = Pens.Black;
		private readonly static int PaintSize = 10;

		private const double WalkingSpeed = 5;
		public bool HasExtinguisher { get; private set; } = false;
		public bool IsAlive { get; private set; } = true;

		public Person(double x, double y) : base(x, y) { }

		public void Died()
		{
			this.IsAlive = false;
		}

		public void Tick()
		{
			// TODO
		}

		public void Paint(Graphics g)
		{
			float sizeHalf = Person.PaintSize / 2;

			if (IsAlive)
			{
				Rectangle rect = new Rectangle(
					(int)(this.X - sizeHalf),
					(int)(this.Y - sizeHalf),
					Person.PaintSize,
					Person.PaintSize
				);

				g.FillEllipse(HasExtinguisher ? Person.HoldsExtinguisherBrush : Person.MainBrush, rect);
			} else
			{
				g.DrawLine(Person.DeathPen, (int)(this.X - sizeHalf), (int)(this.Y - sizeHalf), (int)(this.X + sizeHalf), (int)(this.Y + sizeHalf));
				g.DrawLine(Person.DeathPen, (int)(this.X - sizeHalf), (int)(this.Y + sizeHalf), (int)(this.X + sizeHalf), (int)(this.Y - sizeHalf));
			}
		}
	}
}
