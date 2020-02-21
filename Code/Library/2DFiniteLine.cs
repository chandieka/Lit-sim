using System;

namespace Library
{
	public class _2DFiniteLine : _2DLine
	{
		public readonly _2DPoint StartPoint;
		public readonly _2DPoint EndPoint;
		private readonly Lazy<double> length;

		/// <summary>
		/// The distance between the start point and end point of the line.
		/// </summary>
		public double Length => this.length.Value;

		protected _2DFiniteLine(_2DPoint start, _2DPoint end)
			: base(start, _2DFiniteLine.CalculateSlope(start, end))
		{
			this.StartPoint = start;
			this.EndPoint = end;

			this.length = new Lazy<double>(this.CalculateLength);
		}

		// static line info
		private static double CalculateSlope(_2DPoint start, _2DPoint end) => _2DPoint.CalculateDistanceX(start, end) / _2DPoint.CalculateDistanceY(start, end);
		private static double CalculateLength(_2DPoint start, _2DPoint end) => _2DPoint.CalculateDistance(start, end);

		// basic line info
		private double CalculateLength() => _2DFiniteLine.CalculateLength(this.StartPoint, this.EndPoint);

		// overrides
		public override string ToString() => $"Start: {this.StartPoint}; End: {this.EndPoint}";
	}
}
