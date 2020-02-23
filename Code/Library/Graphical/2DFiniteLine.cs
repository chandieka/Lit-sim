using System;

namespace Library.Graphical
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
		/// <summary>
		/// Calculate the rate at which a line goes up/down with the given start point and end point.
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		private static double CalculateSlope(_2DPoint start, _2DPoint end)
		{
			// TODO: Check devide by 0

			// a = (y1 - y2) / (x1 - x2)
			return _2DPoint.CalculateDistanceY(end, start) / _2DPoint.CalculateDistanceX(end, start);
		}

		/// <summary>
		/// Calculate the length of a line between the given start point and end point.
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		private static double CalculateLength(_2DPoint start, _2DPoint end) => 
			_2DPoint.CalculateDistance(start, end);

		// basic line info
		/// <summary>
		/// Calculate the length of this line.
		/// </summary>
		/// <returns></returns>
		private double CalculateLength() => 
			_2DFiniteLine.CalculateLength(this.StartPoint, this.EndPoint);

		// overrides
		public override string ToString() => 
			$"Start: {this.StartPoint}; End: {this.EndPoint}";
	}
}
