using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public struct flPoint : IflPoint
    {
        public double X {get;set;}
        public double Y {get;set;}

        public flPoint(double x, double y) { X = x; Y = y; }
        public flPoint(int x, int y) { X = x; Y = y; }
        public flPoint(Point p) { X = p.X; Y = p.Y; }
        public flPoint(Size s) { X = s.Width; Y = s.Height; }

        public IflPoint Translate(IflPoint delta)
        {
            return new flPoint(X + delta.X, Y + delta.Y);
        }

        public IflPoint Scale(IflPoint scale)
        {
            return new flPoint(X * scale.X, Y * scale.Y);
        }

        public IflPoint Scale(double sx, double sy)
        {
            return new flPoint(X * sx, Y * sy);
        }

        public IflPoint Rotate(double degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            return RotateRad(radians);
        }

        public IflPoint RotateRad(double radians)
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
        public static IflPoint[] Translate(IflPoint[] points, IflPoint delta)
        {
            IflPoint[] value = new IflPoint[points.Length];
            for (int idx =0; idx< points.Length;  idx++)
            {
                value[idx] = (flPoint) points[idx].Translate(delta);
            }
            return value;
        }

        public static IflPoint[] Scale(IflPoint[] points, IflPoint scale)
        {
            IflPoint[] value = new IflPoint[points.Length];
            for (int idx = 0; idx < points.Length; idx++)
            {
                value[idx] = (flPoint) points[idx].Scale(scale);
            }
            return value;
        }

        public static IflPoint[] Scale(IflPoint[] points, double sx, double sy)
        {
            IflPoint[] value = new IflPoint[points.Length];
            for (int idx = 0; idx < points.Length; idx++)
            {
                value[idx] = (flPoint) points[idx].Scale(sx, sy);
            }
            return value;
        }

        public static IflPoint[] Rotate(IflPoint[] points, double degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            return RotateRad(points, radians);
        }

        public static IflPoint[] RotateRad(IflPoint[] points, double radians)
        {
            IflPoint[] value = new IflPoint[points.Length];
            for (int idx = 0; idx < points.Length; idx++)
            {
                value[idx] = (flPoint) points[idx].RotateRad(radians);
            }
            return value;
        }
    }
}
