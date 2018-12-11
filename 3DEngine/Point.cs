using System;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._3DEngine
{
    public class Point : I3DObject
    {
        myDouble[] tuple;

        public Point()
        {
            tuple = new myDouble[3];
        }

        public Point(double x, double y, double z) : this()
        {
            tuple[0] = x;
            tuple[1] = y;
            tuple[2] = z;
        }
        public Point(Point p) : this()
        {
            tuple[0] = p.x;
            tuple[1] = p.y;
            tuple[2] = p.z;
        }

        public double x { get { return tuple[0]; } set { tuple[0] = value; } }
        public double y { get { return tuple[1]; } set { tuple[1] = value; } }
        public double z { get { return tuple[2]; } set { tuple[2] = value; } }

        Point I3DObject.Max => throw new NotImplementedException();

        Point I3DObject.Min => throw new NotImplementedException();

        Point I3DObject.Center => throw new NotImplementedException();

        public static implicit operator Point(Vector v)
        {
            return new Point(v.dx, v.dy, v.dz);
        }

        public static implicit operator Vector(Point p)
        {
            return new Vector(p.x, p.y, p.z);
        }

        public override string ToString()
        {
            return string.Format("({0},{1},{2})", x, y, z);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Point);
        }

        public bool Equals(Point p)
        {
            if ((object)p != null)
            {
                return x == p.x && y == p.y && z == p.z;
            }
            return false;
        }

        public static bool operator ==(Point a, Point b)
        {
            if ((object)a == null)
            {
                return (object)b == null;
            }
            return a.Equals(b);
        }

        public static bool operator !=(Point a, Point b)
        {
            if ((object)a == null)
            {
                return (object)b != null;
            }
            return !a.Equals(b);
        }

        // NOTE: these < and > are not complimentary it is posible for 2 
        //       points to be ! < && !> if some coordinates match the criterea
        //       and some don't
        // is < if x, y and z are all less than the corresponding coordinate
        public static bool operator <(Point l, Point r)
        {
            return l.x < r.x && l.y < r.y && l.z < r.z;
        }
        // is > if x, y and z are all greater than the corresponding coordinate
        public static bool operator >(Point l, Point r)
        {
            return l.x > r.x && l.y > r.y && l.z > r.z;
        }

        // NOTE: these <= and >= are not complimentary it is posible for 2 
        //       points to be ! <= && ! >= if some coordinates match the criterea
        //       and some don't
        // is <= if x, y and z are all <= than the corresponding coordinate
        public static bool operator <=(Point l, Point r)
        {
            return l.x <= r.x && l.y <= r.y && l.z <= r.z;
        }
        // is >= if x, y and z are all >= than the corresponding coordinate
        public static bool operator >=(Point l, Point r)
        {
            return l.x >= r.x && l.y >= r.y && l.z >= r.z;
        }

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
            return new Vector(p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);
        }

        public Vector SubtractPointFromPoint(Point p)
        {
            return null;
        }

        /// <summary>
        /// Cross product operator
        /// </summary>
        public static Point operator *(Point p1, Point p2)
        {
            return new Point(p1.y * p2.z - p1.z * p2.y,
                              p1.z * p2.x - p1.x * p2.z,
                              p1.x * p2.y - p1.x * p2.z);
        }

        public Point Cross(Point p)
        {
            return this * p;
        }

        public static double Dot(Point p1, Point p2)
        {
            return p1.x * p2.x + p1.y * p2.y + p1.z * p2.z;
        }

        public static double Dot(Point p, Vector v)
        {
            return v.dx * p.x + v.dy * p.y + v.dz * p.z;
        }

        public double Dot(Point p)
        {
            return this.x * p.x + this.y * p.y + this.z * p.z;
        }

        public double Dot(Vector v)
        {
            return this.x * v.dx + this.y * v.dy + this.z * v.dz;
        }


        public I3DObject RotateXY(double degrees)
        {
            myDouble radians = Math.PI * degrees / 180.0;

            myDouble sin = Math.Sin(radians);
            myDouble cos = Math.Cos(radians);

            return new Point(
                (cos * x) + (-sin * y),
                (sin * x) + (cos * y),
                z
                );
        }

        public I3DObject RotateXZ(double degrees)
        {
            myDouble radians = Math.PI * degrees / 180.0;

            myDouble sin = Math.Sin(radians);
            myDouble cos = Math.Cos(radians);

            return new Point(
                (cos * x) + (sin * z),
                y,
                (-sin * x) + (cos * z)
                );
        }

        public I3DObject RotateYZ(double degrees)
        {
            myDouble radians = Math.PI * degrees / 180.0;

            myDouble sin = Math.Sin(radians);
            myDouble cos = Math.Cos(radians);

            return new Point(
                x,
                (cos * y) + (-sin * z),
                (sin * y) + (cos * z)
                );
        }

        public I3DObject Scale(Vector scale)
        {
            return new Point(x * scale.dx, y * scale.dy, z * scale.dz);
        }

        public I3DObject Scale(double scale)
        {
            return Scale(new Vector(scale,scale,scale));
        }

        public I3DObject Translate(Vector delta)
        {
            return this + delta;
        }

        public static Point Max(params Point[] points)
        {
            Point val = new Point(points[0]);
            if (points.Length > 1)
            {
                for (int idx = 1; idx < points.Length; idx++)
                {
                    if (points[idx].x > val.x)
                        val.x = points[idx].x;
                    if (points[idx].y > val.y)
                        val.y = points[idx].y;
                    if (points[idx].z > val.z)
                        val.z = points[idx].z;
                }
            }
            return val;
        }

        public static Point Min(params Point[] points)
        {
            Point val = new Point(points[0]);
            if (points.Length > 1)
            {
                for (int idx = 1; idx < points.Length; idx++)
                {
                    if (points[idx].x < val.x)
                        val.x = points[idx].x;
                    if (points[idx].y < val.y)
                        val.y = points[idx].y;
                    if (points[idx].z < val.z)
                        val.z = points[idx].z;
                }
            }
            return val;
        }

        public static Point Center(params Point[] points)
        {
            Point max = Max(points);
            Point min = Min(points);

            Point val = new Point(max);

            val.x += min.x;
            val.y += min.y;
            val.z += min.z;

            val.x /= 2;
            val.y /= 2;
            val.z /= 2;

            return val;
        }
        public double Norm()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public void Render(I3DCamera c)
        {
            c.DrawPoint(this);
        }
    }
}