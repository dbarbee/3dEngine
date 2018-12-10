using System;
using System.Collections.Generic;
using System.Text;

namespace _3dEngine
{
    public class Vector
    {
        double[] tuple;

        public Vector()
        {
            tuple = new double[3];
        }
        public Vector(double dx, double dy, double dz) : this()
        {
            tuple[0] = dx;
            tuple[1] = dy;
            tuple[2] = dz;
        }
        public Vector(Point p1, Point p2) : this()
        {
            tuple[0] = p2.x - p1.x;
            tuple[1] = p2.y - p1.y;
            tuple[2] = p2.z - p1.z;
        }

        public double dx { get { return tuple[0]; } }
        public double dy { get { return tuple[1]; } }
        public double dz { get { return tuple[2]; } }

        public static Vector operator +(Vector vLeft, Vector vRight)
        {
            return new Vector(vLeft.dx + vRight.dx, vLeft.dy + vRight.dy, vLeft.dz + vRight.dz);
        }
        public Vector AddVectorToVector(Vector v)
        {
            return this + v;
        }

        public static Vector operator -(Vector vLeft, Vector vRight)
        {
            return new Vector(vLeft.dx - vRight.dx, vLeft.dy - vRight.dy, vLeft.dz - vRight.dz);
        }

        public Vector SubtractVectorFromVector(Vector v)
        {
            return this - v;
        }

        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.dy * v2.dz - v1.dz * v2.dy,
                              v1.dz * v2.dx - v1.dx * v2.dz,
                              v1.dx * v2.dy - v1.dx * v2.dz);
        }

        public Vector CrossProductVectorToVector(Vector v)
        {
            return this * v;
        }

        public Vector RotateXY(double degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);

            return new Vector(
                (cos * dx) + (-sin * dy),
                (sin * dx) + (cos * dy),
                dz
                );
        }

        public Vector RotateXZ(double degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);

            return new Vector(
                (cos * dx) + (sin * dz),
                dy,
                (-sin * dx) + (cos * dz)
                );
        }

        public Vector RotateYZ(double degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);

            return new Vector(
                dx,
                (cos * dy) + (-sin * dz),
                (sin * dy) + (cos * dz)
                );
        }

        public Vector Scale(Vector scale)
        {
            return new Vector(dx * scale.dx, dy * scale.dy, dz * scale.dz);
        }

        public Vector Scale(double scale)
        {
            return Scale(new Vector(scale, scale, scale));
        }

        public Vector Translate(Vector delta)
        {
            return new Vector(dx + delta.dx, dy + delta.dy, dz + delta.dz);
        }

        //cosπ2a0+−sinπ2a1+0a2
        //    sinπ2a0+cosπ2a1+0a20a0+0a1+1a2
    }
}
