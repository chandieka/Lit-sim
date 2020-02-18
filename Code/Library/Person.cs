using System.Drawing;

namespace Library
{
	class Person : _2DPoint, IAnimatedObject
	{
		private readonly static Brush HoldsExtinguisherBrush = new SolidBrush(Color.Orange);
		private readonly static Brush MainBrush = new SolidBrush(Color.Blue);
		private readonly static int PaintSize = 5;

		private const double WalkingSpeed = 5;
		public bool HasExtinguisher { get; private set; } = false;
		public bool IsAlive { get; private set; } = true;

		public Person(double x, double y) : base(x, y) { }

		public void Tick()
		{
			// TODO
		}

		public override void Paint(Graphics g)
		{
			float sizeHalf = Person.PaintSize / 2;

			Rectangle rect = new Rectangle(
				(int) (this.X - sizeHalf),
				(int) (this.Y - sizeHalf),
				Person.PaintSize,
				Person.PaintSize
			);

			g.FillEllipse(HasExtinguisher ? Person.HoldsExtinguisherBrush : Person.MainBrush, rect);
		}
	}
}
