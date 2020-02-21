﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class StaticMethods
	{
		public static _2DPoint IntersectionPoint(_2DLine line_a, _2DLine line_b)
		{
			if (line_a.Slope == line_b.Slope) return null;

			// TODO: add different calculation for finite line
			// if (line_a is _2DFiniteLine) ...
			// if (line_b is _2DFiniteLine) ...

			double x = (line_a.Y_intercept - line_b.Y_intercept) / (line_a.Slope - line_b.Slope);

			return line_a.PointForX(x);
		}
		public static bool Intersects(_2DLine line, _2DPoint point) => line.PointForX(point.X).Y == point.Y;
		public static bool Intersects(_2DLine line_a, _2DLine line_b) => StaticMethods.IntersectionPoint(line_a, line_b) == null;
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
			return segmentLength < circle.Radius;
		}

		public static bool Intersects(_2DCircle circle, _2DPoint point) => _2DPoint.CalculateDistance(circle.Center, point) <= circle.Radius;
		public static bool Intersects(_2DCircle circle_a, _2DCircle circle_b) => _2DPoint.CalculateDistance(circle_a.Center, circle_b.Center) <= circle_a.Radius + circle_b.Radius;

		public static bool Intersects(_2DPoint point_a, _2DPoint point_b) => _2DPoint.CalculateDistance(point_a, point_b) == 0d;

		// extensions
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
