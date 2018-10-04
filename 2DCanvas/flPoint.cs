using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public struct flPoint
    {
        public double X;
        public double Y;

        public flPoint(double x, double y) { X = x; Y = y; }
        public flPoint(int x, int y) { X = x; Y = y; }
        public flPoint(Point p) { X = p.X; Y = p.Y; }

        public flPoint Translate(flPoint delta)
        {
            return new flPoint(X + delta.X, Y + delta.Y);
        }

        public flPoint Scale(flPoint scale)
        {
            return new flPoint(X * scale.X, Y * scale.Y);
        }

        public flPoint Scale(double sx, double sy)
        {
            return new flPoint(X * sx, Y * sy);
        }

        public flPoint Rotate(double degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            return RotateRad(radians);
        }

        public flPoint RotateRad(double radians)
        {
            if (radians == 0)
            {
                return this;
            }
            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);

            return new flPoint(
                (cos * X) + (-sin * Y),
                (sin * X) + (cos * Y)
                );
        }
        public static flPoint[] Translate(flPoint[] points, flPoint delta)
        {
            flPoint[] value = new flPoint[points.Length];
            for (int idx =0; idx< points.Length;  idx++)
            {
                value[idx] = points[idx].Translate(delta);
            }
            return value;
        }

        public static flPoint[] Scale(flPoint[] points, flPoint scale)
        {
            flPoint[] value = new flPoint[points.Length];
            for (int idx = 0; idx < points.Length; idx++)
            {
                value[idx] = points[idx].Scale(scale);
            }
            return value;
        }

        public static flPoint[] Scale(flPoint[] points, double sx, double sy)
        {
            flPoint[] value = new flPoint[points.Length];
            for (int idx = 0; idx < points.Length; idx++)
            {
                value[idx] = points[idx].Scale(sx, sy);
            }
            return value;
        }

        public static flPoint[] Rotate(flPoint[] points, double degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            return RotateRad(points, radians);
        }

        public static flPoint[] RotateRad(flPoint[] points, double radians)
        {
            flPoint[] value = new flPoint[points.Length];
            for (int idx = 0; idx < points.Length; idx++)
            {
                value[idx] = points[idx].RotateRad(radians);
            }
            return value;
        }
    }
}
