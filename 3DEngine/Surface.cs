using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._3DEngine
{
    public class Surface : I3DObject
    {
        // Vertices must be co-planer for a surface
        public Point[] Vertices { get; private set; }

        public Line[] Edges { get; private set; }

        // which direction is out/up
        public bool Orientation { get; private set; }

        public Vector Normal { get; private set; }

        public Point Max { get; private set; }
        public Point Min { get; private set; }
        public Point Center { get; private set; }

        public Surface(Point[] vertices, bool orientation = true)
        {
            Vertices = new Point[vertices.Length];
            Edges = new Line[vertices.Length];
            Orientation = orientation;

            for (int idx = 0; idx < vertices.Length; idx++)
            {
                Vertices[idx] = vertices[idx];
                if (idx < vertices.Length - 1)
                {
                    Edges[idx] = new Line(vertices[idx], vertices[idx + 1]);
                }
                else
                {
                    Edges[idx] = new Line(vertices[idx], vertices[0]);
                }
            }
            ComputeNormal();

            Max = Point.Max(vertices);
            Min = Point.Min(vertices);
            Center = Point.Center(vertices);
        }

        // Mathematical description of the plane defined the surface 
        //  = Ax+By+Cz+D
        public double A { get { return Normal.dx; } }
        public double B { get { return Normal.dy; } }
        public double C { get { return Normal.dz; } }
        public double D { get; private set; }

        public double MaxY => throw new NotImplementedException();

        private void ComputeNormal()
        {
            Vector v1 = Vertices[0] - Vertices[1];
            Vector v2 = Vertices[2] - Vertices[1];

            Normal = v1 * v2;

            D = -1 * (Normal.dx * Vertices[0].x + Normal.dy * Vertices[0].y + Normal.dz * Vertices[0].z);
        }

        public bool AreParallel(Surface s)
        {
            Vector cross = Normal.Cross(s.Normal);

            return cross.Magnitude < double.Epsilon;
         }

        /**
        * Determines the point of intersection between a plane defined by a point and a normal vector and a line defined by a point and a direction vector.
        *
        * @param planePoint    A point on the plane.
        * @param planeNormal   The normal vector of the plane.
        * @param linePoint     A point on the line.
        * @param lineDirection The direction vector of the line.
        * @return The point of intersection between the line and the plane, null if the line is parallel to the plane.
        */
        public static Point Intersection(Point planePoint, Vector planeNormal, Point linePoint, Vector lineDirection)
        {
            //ax × bx + ay × by
            double dot = planeNormal.Dot(lineDirection);
            if (dot == 0)
            {
                return null;
            }

            double t = (planeNormal.Dot(planePoint) - planeNormal.Dot(linePoint)) / planeNormal.Dot(lineDirection);

            return linePoint + lineDirection.Scale(t);
        }

        public Point Intersection(Line l)
        {
            return Intersection(Vertices[0], Normal, l.P1, l.Direction);
        }

        public Line Intersection(Surface s)
        {
            Vector direction = Normal.Cross(s.Normal);
            double det = direction.Magnitude * direction.Magnitude;
            if (det <= double.Epsilon)
            {
                //planes are parallel
                return null;
            }
            // calculate a point on the line
            Point p = (Point) ((direction.Cross(s.Normal).Scale(D)) +
                       (Normal.Cross(direction).Scale(s.D))).Scale(1/det);

            return new Line(p, direction);
        }

        public void Draw(ICanvas c)
        {
            throw new NotImplementedException();
        }
    }
}
