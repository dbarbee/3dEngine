using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Data;

namespace dbarbee.GraphicsEngine._2DEngine.Doc
{
    public static class PointEx
    {
        public static Point Translate(this Point p, Point delta)
        {
            return new Point(p.X + delta.X, p.Y + delta.Y);
        }

        public static Point Scale(this Point p, Point scale)
        {
            return new Point(p.X * scale.X, p.Y * scale.Y);
        }

        public static Point Scale(this Point p, double sx, double sy)
        {
            return new Point(p.X * sx, p.Y * sy);
        }

        public static Point Rotate(this Point p, double degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            return p.RotateRad(radians);
        }

        public static Point RotateRad(this Point p, double radians)
        {
            if (radians == 0)
            {
                return p;
            }
            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);

            return new Point(
                (cos * p.X) + (-sin * p.Y),
                (sin * p.X) + (cos * p.Y)
                );
        }
        public static Point[] Translate(Point[] points, Point delta)
        {
            Point[] value = new Point[points.Length];
            for (int idx =0; idx< points.Length;  idx++)
            {
                value[idx] = (Point) points[idx].Translate(delta);
            }
            return value;
        }

        public static Point[] Scale(Point[] points, Point scale)
        {
            Point[] value = new Point[points.Length];
            for (int idx = 0; idx < points.Length; idx++)
            {
                value[idx] = (Point) points[idx].Scale(scale);
            }
            return value;
        }

        public static Point[] Scale(Point[] points, double sx, double sy)
        {
            Point[] value = new Point[points.Length];
            for (int idx = 0; idx < points.Length; idx++)
            {
                value[idx] = (Point) points[idx].Scale(sx, sy);
            }
            return value;
        }

        public static Point[] Rotate(Point[] points, double degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            return RotateRad(points, radians);
        }

        public static Point[] RotateRad(Point[] points, double radians)
        {
            Point[] value = new Point[points.Length];
            for (int idx = 0; idx < points.Length; idx++)
            {
                value[idx] = (Point) points[idx].RotateRad(radians);
            }
            return value;
        }
    }
}
