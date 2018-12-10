using System;
using System.Collections.Generic;
using System.Text;

namespace dbarbee.GraphicsEngine._3DEngine
{
    public class Vector
    {
        myDouble[] tuple;

        public Vector()
        {
            tuple = new myDouble[3];
        }
        public Vector(double dx, double dy, double dz) : this()
        {
            tuple[0] = dx;
            tuple[1] = dy;
            tuple[2] = dz;

            Magnitude = Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public double dx { get { return tuple[0]; } }
        public double dy { get { return tuple[1]; } }
        public double dz { get { return tuple[2]; } }

        public double Magnitude { get; private set; }

        public override string ToString()
        {
            return string.Format("<{0},{1},{2}>", dx, dy, dz);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vector);
        }

        public bool Equals(Vector v)
        {
            if ((object)v != null)
            {
                return dx == v.dx && dy == v.dy && dz == v.dz;
            }
            return false;
        }

        public static bool operator ==(Vector a, Vector b)
        {
            if ((object)a == null)
            {
                return (object)b == null;
            }
            return a.Equals(b);
        }

        public static bool operator !=(Vector a, Vector b)
        {
            if ((object)a == null)
            {
                return (object)b != null;
            }
            return !a.Equals(b);
        }

        private static double ABS(double v) { return v >= 0 ? v : -1 * v; }
        // create a simular vector where the smallest nonzero companent is 1
        // if all components are zero, return that.
        public Vector Normalize()
        {
            if (dx == 0 && dy == 0 && dz == 0)
                return this;
            myDouble ABSdx = ABS(dx);
            myDouble ABSdy = ABS(dy);
            myDouble ABSdz = ABS(dz);
            if (dx != 0 && (dy == 0 || ABSdx <= ABSdy) && (dz == 0 || ABSdx <= ABSdz))
                return new Vector(dx / ABSdx, dy / ABSdx, dz / ABSdx);
            else if (dy != 0 && (dx == 0 || ABSdy <= ABSdx) && (dz == 0 || ABSdy <= ABSdz))
                return new Vector(dx / ABSdy, dy / ABSdy, dz / ABSdy);
            return new Vector(dx / ABSdz, dy / ABSdz, dz / ABSdz);
        }

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

        /// <summary>
        /// Cross product operator
        /// </summary>
        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.dy * v2.dz - v1.dz * v2.dy,
                              v1.dz * v2.dx - v1.dx * v2.dz,
                              v1.dx * v2.dy - v1.dy * v2.dx);
        }

        public Vector Cross(Vector v)
        {
            return this * v;
        }

        public static double Dot(Vector v1, Vector v2)
        {
            return v1.dx * v2.dx + v1.dy * v2.dy + v1.dz * v2.dz;
        }

        public static double Dot(Vector v, Point p)
        {
            return v.dx * p.x + v.dy * p.y + v.dz * p.z;
        }

        public double Dot(Vector v)
        {
            return this.dx * v.dx + this.dy * v.dy + this.dz * v.dz;
        }

        public double Dot(Point p)
        {
            return this.dx * p.x + this.dy * p.y + this.dz * p.z;
        }

        public Vector RotateXY(double degrees)
        {
            myDouble radians = Math.PI * degrees / 180.0;

            myDouble sin = Math.Sin(radians);
            myDouble cos = Math.Cos(radians);

            return new Vector(
                (cos * dx) + (-sin * dy),
                (sin * dx) + (cos * dy),
                dz
                );
        }

        public Vector RotateXZ(double degrees)
        {
            myDouble radians = Math.PI * degrees / 180.0;

            myDouble sin = Math.Sin(radians);
            myDouble cos = Math.Cos(radians);

            return new Vector(
                (cos * dx) + (sin * dz),
                dy,
                (-sin * dx) + (cos * dz)
                );
        }

        public Vector RotateYZ(double degrees)
        {
            myDouble radians = Math.PI * degrees / 180.0;

            myDouble sin = Math.Sin(radians);
            myDouble cos = Math.Cos(radians);

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

        public double Angle(Vector v)
        {
            myDouble dot = Dot(v);
            myDouble div = new myDouble( dot / (Magnitude * v.Magnitude), 1);

            myDouble arcCos = Math.Acos(div);
            return arcCos;
        }

        //cosπ2a0+−sinπ2a1+0a2
        //    sinπ2a0+cosπ2a1+0a20a0+0a1+1a2
    }
}
