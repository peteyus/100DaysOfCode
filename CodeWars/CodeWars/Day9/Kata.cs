namespace CodeWars.Day9
{
    using System;
    using System.Collections.Generic;

    public class Kata
    {
        public int RectangleRotation(int a, int b)
        {
            var topRight = new Point(a / 2, b / 2);
            var topLeft = new Point(topRight.X - a, b / 2);
            var bottomLeft = new Point(topRight.X - a, topRight.Y - b);
            var bottomRight = new Point(a / 2, topRight.Y - b);

            var newTopRight = Rotate(topRight);
            var newTopLeft = Rotate(topLeft);
            var newBottomLeft = Rotate(bottomLeft);
            var newBottomRight = Rotate(bottomRight);

            int maxX = (int)Math.Ceiling(newBottomRight.X);
            int maxY = (int)Math.Ceiling(newTopRight.Y);
            int minX = (int)Math.Floor(newTopLeft.X);
            int minY = (int)Math.Floor(newBottomLeft.Y);

            var possiblePoints = new List<Point>();
            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    possiblePoints.Add(new Point(x, y));
                }
            }


        }

        private static Point Rotate(Point start)
        {
            double xPrime = start.X * Math.Cos(45) - start.Y * Math.Sin(45);
            double yPrime = start.X * Math.Sin(45) + start.Y * Math.Cos(45);

            return new Point(xPrime, yPrime);
        }

        private class Point
        {
            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            public double X { get; }

            public double Y { get; }
        }
    }
}
