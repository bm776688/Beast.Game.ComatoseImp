﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComatoseImp
{
	public struct Point
	{
		public int X { get; set; }

		public int Y { get; set; }

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static Point operator +(Point a, Point b) 
		{
			return new Point(a.X + b.X, a.Y + b.Y);
		}

		public static Point operator -(Point a, Point b) 
		{
			return new Point(a.X - b.X, a.Y - b.Y);
		}
	}
}
