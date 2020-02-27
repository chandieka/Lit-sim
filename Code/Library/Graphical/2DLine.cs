using System;

namespace Library.Graphical
{
    public class _2DLine
	{
		private readonly Lazy<double> x_intercept;
		private readonly double y_intercept;
		private readonly double slope;

		/// <summary>
		/// The amount at which the y-value goes up for each x-value of 1.
		/// </summary>
		public double Slope => this.slope;
		/// <summary>
		/// The x-value at which the line crosses the x-axis (x for y = 0).
		/// </summary>
		public double X_intercept { get { return this.x_intercept.Value; } }
		/// <summary>
		/// The y-value at which the line crosses the y-axis (y for x = 0).
		/// </summary>
		public double Y_intercept { get { return this.y_intercept; } }

		private _2DLine()
		{
			this.x_intercept = new Lazy<double>(this.CalculateXIntercept);
		}

		public _2DLine(_2DPoint reference_point, double slope) : this()
        {
			this.slope = slope;
			this.y_intercept = _2DLine.CalculateYIntercept(this.Slope, reference_point);
        }

		// static line info
		/// <summary>
		/// Calculate the value for y at which the line through the reference point with the given slope goes through the x-axis.
		/// </summary>
		/// <param name="slope"></param>
		/// <param name="reference_point"></param>
		/// <returns></returns>
		public static double CalculateXIntercept(double slope, _2DPoint reference_point)
		{
			// TODO: Check devide by 0

			// y = ax + b
			// ax = y - b
			// x = (y - b) / a

			return (reference_point.Y - _2DLine.CalculateYIntercept(slope, reference_point)) / slope;
		}

		/// <summary>
		/// Calculate the value for x at which the line through the reference point with the given slope goes through the y-axis.
		/// </summary>
		/// <param name="slope"></param>
		/// <param name="reference_point"></param>
		/// <returns></returns>
		public static double CalculateYIntercept(double slope, _2DPoint reference_point)
		{
			// TODO: Add calculation comment
			return reference_point.Y - (slope * reference_point.X);
		}

		// basic line info
		/// <summary>
		/// Calculate the value for y at which this line goes through the x-axis.
		/// </summary>
		/// <returns></returns>
		protected double CalculateXIntercept() => 
			_2DLine.CalculateXIntercept(this.Slope, new _2DPoint(0, this.Y_intercept));

		/// <summary>
		/// Calculate the point that sits on this line for the given x value.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
        public _2DPoint PointForX(double x)
		{
			// y = ax + b
			return new _2DPoint(x, (this.Slope * x) + this.Y_intercept);
		}

		/// <summary>
		/// Calculate the point that sits on this line for the given y value.
		/// </summary>
		/// <param name="y"></param>
		/// <returns></returns>
        public _2DPoint PointForY(double y)
		{
			// TODO: Check devide by 0

			// y = ax + b
			// ax = y - b
			// x = (y - b) / a
			return new _2DPoint((y - this.Y_intercept) / this.Slope, y);
		}

		// overrides
		public override string ToString() => 
			$"Slope: {this.Slope}, Y intercept: {this.Y_intercept}";
	}
}
