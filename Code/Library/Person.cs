using System;
using System.Drawing;

namespace Library
{
	public class Person : _2DPoint, IPaintable, IChangeableObject
	{
        // temporary, for testing purpose
        public Action On_Tick; 

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

            this.On_Tick();
		}

        public void WalkToward(_2DPoint location)
        {
            double diff_x = location.X - this.X;
            double diff_y = location.Y - this.Y;

            double diff = Math.Sqrt(Math.Pow(diff_x, 2) + Math.Pow(diff_y, 2));

            if (diff < Person.WalkingSpeed)
            {
                this.X = location.X;
                this.Y = location.Y;
            }
            else
            {
                double ratio_x = diff_x / diff;
                double ratio_y = diff_y / diff;

                this.X += ratio_x * Person.WalkingSpeed;
                this.Y += ratio_y * Person.WalkingSpeed;
            }
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
