using System;
using System.Drawing;

namespace Library.Graphical
{
	public class Person : _2DPoint, IPaintable, IChangeableObject
	{
        // temporary, for testing purpose
        public Action On_Tick; 

		private readonly static Brush HoldsExtinguisherBrush = new SolidBrush(Color.Orange);
		private readonly static Brush MainBrush = new SolidBrush(Color.Blue);
		private readonly static Pen DeathPen = Pens.Black;
		private readonly static int PaintSize = 10;

		/// <summary>
		/// The amount at which the person moves in a specified direction.
		/// </summary>
		private const double WalkingSpeed = 5;
		/// <summary>
		/// Check if the person is holding a fire extinguisher.
		/// </summary>
		public bool HasFireExtinguisher { get; private set; } = false;
		/// <summary>
		/// Check if the person is still alive.
		/// </summary>
		public bool IsAlive { get; private set; } = true;

		public Person(double x, double y) : base(x, y) { }

		/// <summary>
		/// Indicate that the person has died.
		/// </summary>
		public void Died()
		{
			this.IsAlive = false;
		}

		/// <summary>
		/// Move the person to the next frame in its animation.
		/// </summary>
		public void Tick()
		{
            // TODO

            this.On_Tick();
		}

		/// <summary>
		/// Indicate that the person has picked up a fire extinguisher.
		/// </summary>
		/// <param name="fireExtinguisher"></param>
		/// <remarks>
		/// The fire extinguisher will be used after this.
		/// </remarks>
		public void PickUpFireExtinguisher(FireExtinguisher fireExtinguisher)
		{
			this.HasFireExtinguisher = true;

			fireExtinguisher.Use();
		}

		/// <summary>
		/// Move the person to the given location, this will go at the rate of this person's movespeed.
		/// </summary>
		/// <param name="location"></param>
        public void WalkToward(_2DPoint location)
        {
			double diff_x = _2DPoint.CalculateDistanceX(location, this);
			double diff_y = _2DPoint.CalculateDistanceY(location, this);

			// Same as: _2DPoint.CalculateDistance
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

		/// <summary>
		/// Paint the person on the given graphics object.
		/// </summary>
		/// <param name="g"></param>
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

				g.FillEllipse(HasFireExtinguisher ? Person.HoldsExtinguisherBrush : Person.MainBrush, rect);
			} else
			{
				g.DrawLine(Person.DeathPen, (int)(this.X - sizeHalf), (int)(this.Y - sizeHalf), (int)(this.X + sizeHalf), (int)(this.Y + sizeHalf));
				g.DrawLine(Person.DeathPen, (int)(this.X - sizeHalf), (int)(this.Y + sizeHalf), (int)(this.X + sizeHalf), (int)(this.Y - sizeHalf));
			}
		}
	}
}
