using System;

namespace Library
{
	public class _2DLine
	{
		public readonly _2DPoint StartPoint;
		public readonly _2DPoint EndPoint;

		protected _2DLine(_2DPoint start, _2DPoint end)
		{
			StartPoint = start;
			EndPoint = end;
		}

		public bool IntersectsWith(_2DPoint point)
		{
			// TODO: Check my math
			double a = getA();
			double b = getB(a);
			return GetYForX(point.X, a, b) == point.Y;
		}

		public bool IntersectsWith(_2DLine line)
		{
			return this.intersectionPoint(line) != null;
		}

		internal bool IntersectsWith(_2DCircle circle)
		{
			// TODO: Check devide by 0

			// Steps:
			// 1: Find the line perpendicular to this line, through the center of the circle
			// 2: Get the intersection point of the new line with the origional line
			// 3: Get the length of the line, through the center of the circle, intersecting with the origional line
			// 4: If this lengtn is bigger than the radius of the circle, they don't intersect

			double a = this.getA();
			double b = this.getB(a);

			// Step 1
			double newA = -1 / a;
			double newB = _2DLine.getB(newA, circle.Center);

			// Step 2
			_2DPoint intersectionPoint = _2DLine.intersectionPoint(a, newA, b, newB);

			// Step 3
			double segmentLength = _2DPoint.Distance(circle.Center, intersectionPoint);

			// Step 4
			return segmentLength <= circle.Radius;
		}

		private double getA()
		{
			// TODO: Check devide by 0

			// a = (y1 - y2) / (x1 - x2)
			return (StartPoint.Y - EndPoint.Y) / (StartPoint.X - EndPoint.X);
		}

		private double getB(double a)
		{
			return getB(a, StartPoint.X, StartPoint.Y);	
		}

		private _2DPoint intersectionPoint(_2DLine line)
		{
			double thisA = this.getA();
			double lineA = line.getA();

			return intersectionPoint(thisA, lineA, this.getB(thisA), line.getB(lineA));
		}

		private static double getB(double a, _2DPoint p)
		{
			return getB(a, p.X, p.Y);
		}

		private static double getB(double a, double x, double y)
		{
			// y = ax + b
			// b = y - ax
			return y - a * x;
		}

		// Warning: Could return null
		private static _2DPoint intersectionPoint(double l1A, double l2A, double l1B, double l2B)
		{
			// If a is the same, the lines are parallel, so they don't intersect
			if (l1A == l2A)
				return null;
			else
			{
				// Prevent devide by 0 error
				double x;
				try
				{
					// both lines: y = ax + b
					// ax + b = ax + b	-> 2x + 3 = 1x + 5
					// ax - ax = b - b	-> 2x - 1x = 5 - 3
					// (a - a)x = b - b	-> 1x = 2
					// x = (b-b)/(a-a)	-> x = 2
					x = (l1B - l2B) / (l2A - l1A);
				} catch (DivideByZeroException)
				{
					return null;
				}

				// For y use one of the lines and fill in x
				double y = l1A * x + l1B;

				// TODO: Maybe add check if for the same x, both equations give the same y
				return _2DPoint.MakeNew(x, y);
			}
		}

		private static double GetXForY(double y, double a, double b)
		{
			// TODO: Check devide by 0

			// y = ax + b
			// ax = y - b
			// x = (y - b) / a
			return (y - b) / a;
		}

		private static double GetYForX(double x, double a, double b)
		{
			// y = ax + b
			return a * x + b;
		}

		public override string ToString()
		{
			return $"Start: {this.StartPoint}; End: {this.EndPoint}";
		}
	}
}
