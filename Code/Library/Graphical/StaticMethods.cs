namespace Library.Graphical
{
    public static class StaticMethods
	{
		/// <summary>
		/// Tries to find the intersection point between 2 lines.
		/// </summary>
		/// <param name="line_a"></param>
		/// <param name="line_b"></param>
		/// <returns>The point at which they intersect, can also return null if they don't intersect.</returns>
		public static _2DPoint IntersectionPoint(_2DLine line_a, _2DLine line_b)
		{
			// If a is the same, the lines are parallel, so they don't intersect
			if (line_a.Slope == line_b.Slope) return null;

			// TODO: add different calculation for finite line
			// if (line_a is _2DFiniteLine) ...
			// if (line_b is _2DFiniteLine) ...

			// both lines: y = ax + b
			// ax + b = ax + b	-> 2x + 3 = 1x + 5
			// ax - ax = b - b	-> 2x - 1x = 5 - 3
			// (a - a)x = b - b	-> 1x = 2
			// x = (b-b)/(a-a)	-> x = 2
			double x = (line_a.Y_intercept - line_b.Y_intercept) / (line_a.Slope - line_b.Slope);

			return line_a.PointForX(x);
		}

		/// <summary>
		/// Checks if the point is on the line.
		/// </summary>
		/// <param name="line"></param>
		/// <param name="point"></param>
		/// <returns></returns>
		public static bool Intersects(_2DLine line, _2DPoint point) => 
			line.PointForX(point.X).Y == point.Y;

		/// <summary>
		/// Checks if the 2 lines intersect.
		/// </summary>
		/// <param name="line_a"></param>
		/// <param name="line_b"></param>
		/// <returns></returns>
		public static bool Intersects(_2DLine line_a, _2DLine line_b) => 
			StaticMethods.IntersectionPoint(line_a, line_b) == null;

		/// <summary>
		/// Checks if the line intersects with the circle.
		/// </summary>
		/// <param name="line"></param>
		/// <param name="circle"></param>
		/// <returns></returns>
		public static bool Intersects(_2DLine line, _2DCircle circle)
		{
			// TODO: Check devide by 0

			// Steps:
			// 1: Find the line perpendicular to this line, through the center of the circle
			// 2: Get the intersection point of the new line with the origional line
			// 3: Get the Length of the line, through the center of the circle, intersecting with the origional line
			// 4: If this lengtn is bigger than the radius of the circle, they don't intersect

			// Step 1
			double slope_perpendicular = -1 / line.Slope;
			double y_intercept = _2DLine.CalculateYIntercept(slope_perpendicular, circle.Center);

			_2DLine perpendicular = new _2DLine(new _2DPoint(0, y_intercept), slope_perpendicular);

			// Step 2
			_2DPoint intersectionPoint = StaticMethods.IntersectionPoint(line, perpendicular);

			// Step 3
			double segmentLength = _2DPoint.CalculateDistance(intersectionPoint, circle.Center);

			// Step 4
			return segmentLength <= circle.Radius;
		}

		/// <summary>
		/// Checks if the point is somewhere on the circle.
		/// </summary>
		/// <param name="circle"></param>
		/// <param name="point"></param>
		/// <returns></returns>
		public static bool Intersects(_2DCircle circle, _2DPoint point) => 
			_2DPoint.CalculateDistance(circle.Center, point) <= circle.Radius;

		/// <summary>
		/// Checks if the 2 circles overlap.
		/// </summary>
		/// <param name="circle_a"></param>
		/// <param name="circle_b"></param>
		/// <returns></returns>
		public static bool Intersects(_2DCircle circle_a, _2DCircle circle_b) => 
			_2DPoint.CalculateDistance(circle_a.Center, circle_b.Center) <= circle_a.Radius + circle_b.Radius;

		/// <summary>
		/// Checks if the 2 points are the same.
		/// </summary>
		/// <param name="point_a"></param>
		/// <param name="point_b"></param>
		/// <returns></returns>
		public static bool Intersects(_2DPoint point_a, _2DPoint point_b) =>
			_2DPoint.CalculateDistance(point_a, point_b) == 0d;

		// Extensions
		public static bool IntersectsWith(this _2DLine line_self, _2DPoint point) => StaticMethods.Intersects(line_self, point);
		public static bool IntersectsWith(this _2DLine line_self, _2DCircle circle) => StaticMethods.Intersects(line_self, circle);
		public static bool IntersectsWith(this _2DLine line_self, _2DLine line) => StaticMethods.Intersects(line_self, line);

		public static bool IntersectsWith(this _2DCircle circle_self, _2DPoint point) => StaticMethods.Intersects(circle_self, point);
		public static bool IntersectsWith(this _2DCircle circle_self, _2DLine line) => StaticMethods.Intersects(line, circle_self);
		public static bool IntersectsWith(this _2DCircle circle_self, _2DCircle circle) => StaticMethods.Intersects(circle_self, circle);

		public static bool IntersectsWith(this _2DPoint point_self, _2DPoint point) => StaticMethods.Intersects(point_self, point);
		public static bool IntersectsWith(this _2DPoint point_self, _2DCircle circle) => StaticMethods.Intersects(circle, point_self);
		public static bool IntersectsWith(this _2DPoint point_self, _2DLine line) => StaticMethods.Intersects(line, point_self);
	}
}
