using System;

namespace _3dEngine
{
    public class Point
    {
        double[] tuple;

        public Point()
        {
            tuple = new double[3];
        }

        public Point(double x, double y, double z) : this()
        {
            tuple[0] = x;
            tuple[1] = y;
            tuple[2] = z;
        }

        public double x { get { return tuple[0]; } }
        public double y { get { return tuple[1]; } }
        public double z { get { return tuple[2]; } }

        public static Point operator +(Point p, Vector v)
        {
            return new Point(p.x + v.dx, p.y + v.dy, p.z + v.dz);
        }
        public Point AddVectorToPoint(Vector v)
        {
            return this + v;
        }
        public static Point operator -(Point p, Vector v)
        {
            return new Point(p.x - v.dx, p.y - v.dy, p.z - v.dz);
        }
        public Point SubtractVectorFromPoint(Vector v)
        {
            return this - v;
        }

        public static Vector operator -(Point p1, Point p2)
        {
            return new Vector(p1.x + p2.x, p1.y + p2.y, p1.z + p2.z);
        }

        public Vector SubtractPointFromPoint(Point p)
        {
            return null;
        }

        public Point RotateXY(double degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);

            return new Point(
                (cos * x) + (-sin * y),
                (sin * x) + (cos * y),
                z
                );
        }

        public Point RotateXZ(double degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);

            return new Point(
                (cos * x) + (sin * z),
                y,
                (-sin * x) + (cos * z)
                );
        }

        public Point RotateYZ(double degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);

            return new Point(
                x,
                (cos * y) + (-sin * z),
                (sin * y) + (cos * z)
                );
        }

        public Point Scale(Vector scale)
        {
            return new Point(x * scale.dx, y * scale.dy, z * scale.dz);
        }

        public Point Scale(double scale)
        {

            return Scale(new Vector(scale,scale,scale));
        }
        public Point Translate(Vector delta)
        {
            return new Point(x + delta.dx, y + delta.dy, z + delta.dz);
        }

        public System.Drawing.Point Draw(double Sz)
        {
            int Sx = (int)(x * (Sz / z));
            int Sy = (int)(y * (Sz / z));

            return new System.Drawing.Point(Sx,Sy);
        }
    }
}