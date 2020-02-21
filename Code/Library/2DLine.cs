using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class _2DLine
	{
		private readonly double slope;
		private readonly Lazy<double> x_intercept;
		private readonly double y_intercept;

		/// <summary>
		/// The amount at which the y-value goes up for each x-value of 1.
		/// </summary>
		public double Slope => this.slope;
		/// <summary>
		/// The x-value at which the line crosses the x-axis (x for y = 0).
		/// </summary>
		public double X_intercept => this.x_intercept.Value;
		/// <summary>
		/// The y-value at which the line crosses the y-axis (y for x = 0).
		/// </summary>
		public double Y_intercept => this.y_intercept;

		private _2DLine()
		{
			this.x_intercept = new Lazy<double>(this.CalculateXIntercept);
		}
		public _2DLine(_2DPoint reference_point, double slope)
			:this()
        {
			this.slope = slope;
			this.y_intercept = _2DLine.CalculateYIntercept(this.Slope, reference_point);
        }

		// static line info
		public static double CalculateXIntercept(double slope, _2DPoint reference_point) => (reference_point.Y - _2DLine.CalculateYIntercept(slope, reference_point)) / slope;
		public static double CalculateYIntercept(double slope, _2DPoint reference_point) => reference_point.Y - (slope * reference_point.X);

		// basic line info
		protected double CalculateXIntercept() => _2DLine.CalculateXIntercept(this.Slope, new _2DPoint(0, this.Y_intercept));

        public _2DPoint PointForX(double x) => new _2DPoint(x, (this.Slope * x) + this.Y_intercept);
        public _2DPoint PointForY(double y) => new _2DPoint((y - this.Y_intercept) / this.Slope, y);

		// overrides
		public override string ToString() => $"Slope: {this.Slope}, Y intercept: {this.Y_intercept}";
	}
}
