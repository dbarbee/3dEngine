//#define __DoubleCheck

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._3DEngine
{
    public class Line : I3DObject
    {
        public Point P1 { get; private set; }
        public Point P2 { get; private set; }

        public Vector Direction { get; private set; }

        public Point Max { get; private set; }
        public Point Min { get; private set; }
        public Point Center { get; private set; }

        private Line() { }

        public Line(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
            Direction = P2 - P1;

            Max = Point.Max(P1, P2);
            Min = Point.Min(P1, P2);
            Center = Point.Center(P1, P2);
        }

        public Line(Point p, Vector v)
        {
            P1 = p;
            P2 = new Point(p.x + v.dx, p.y + v.dy, p.z + v.dz);
            Direction = v;

            Max = Point.Max(P1, P2);
            Min = Point.Min(P1, P2);
            Center = Point.Center(P1, P2);
        }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", P1, P2);
        }

        /// <summary>
        /// Create a line that is the mirror image of the line, going from P2->P2
        /// </summary>
        /// <returns>
        /// The reversed line
        /// </returns>
        /// <remarks>
        /// The direction of the line can make diffence when determining if 2 lines intersect
        /// </remarks>
        public Line Reverse()
        {
            return new Line(P2, P1);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Line);
        }

        public bool Equals(Line l)
        {
            if ((object)l != null)
            {
                return P1 == l.P1 && P2 == l.P2;
            }
            return false;
        }

        public static bool operator ==(Line a, Line b)
        {
            if ((object)a == null)
            {
                return (object)b == null;
            }
            return a.Equals(b);
        }

        public static bool operator !=(Line a, Line b)
        {
            if ((object)a == null)
            {
                return (object)b != null;
            }
            return !a.Equals(b);
        }

        public Line Intersect(Surface s)
        {
            return null;
        }

        public Point Intersect2(Line l)
        {
            Point Pi = null;

            double dotVectors = Direction.Dot(l.Direction);
            double dotT = (P1 - l.P1).Dot(l.Direction);
            double dotU = (l.P1 - P1).Dot(Direction);

            Vector crossVectors = Direction.Cross(l.Direction);
            Vector crossT = (P1 - l.P1).Cross(l.Direction);
            Vector crossU = (l.P1 - P1).Cross(Direction);

            if (dotVectors == 0 && dotU == 0)
            {
                //colinear
                return null;
            }
            else if (dotVectors == 0 && dotU != 0)
            {
                // parallel 
                return null;
            }
            else if (dotVectors != 0)
            {
                double t = dotT / dotVectors;
                double u = dotU / dotVectors;

                // we now know that the lines will intersect if the extend to
                //  infinity in both directions, so test to see if the point
                //  between the end points of both lines
                if (t >= 0 && t <= 1 && u >= 0 && u <= 1)
                {
                    Pi = P1 + Direction.Scale(t);
                }
            }
            return Pi;
        }

        public bool AreCollinear(Line l)
        {
            if (Direction.Normalize() == l.Direction.Normalize())
                return true;
            return Direction.Scale(-1).Normalize() == l.Direction.Normalize();
        }

        private double Det(Vector v1, Vector v2)
        {
            return (v1.dy * v2.dz - v1.dz * v2.dy) + (v1.dz * v2.dx - v1.dx * v2.dz) + (v1.dx * v2.dy - v1.dy * v2.dx);
        }

        public Point Intersect(Line l)
        {
            Point Pt = null;
            Point Pu = null;

            Vector crossVectors = Direction.Cross(l.Direction);
            Vector crossT = (P1 - l.P1).Cross(l.Direction);
            Vector crossU = (l.P1 - P1).Cross(Direction);

            //double dotVectors = Direction.Dot(l.Direction);

            if (crossVectors.Magnitude == 0 && crossU.Magnitude == 0)
            {
                //colinear
                System.Diagnostics.Trace.WriteLine("colinear check failed, so lines are colinear with no single point of intersection intersection.");
                return null;
            }
            else if (crossVectors.Magnitude == 0 && crossU.Magnitude != 0)
            {
                // parallel 
                System.Diagnostics.Trace.WriteLine("parallel check failed, so lines are parallel with no intersection.");
                return null;
            }
            //else if (dotVectors != 0)
            //{
            myDouble t = crossT.Magnitude / crossVectors.Magnitude;
            myDouble u = crossU.Magnitude / crossVectors.Magnitude;

            Pt = P1 + Direction.Scale(t);
            Pu = l.P1 + l.Direction.Scale(u);

            if (Pt!=Pu)
            {
                System.Diagnostics.Trace.WriteLine("(Pt!=Pu) check failed, no intersection.");
                return null;
            }
            // If the point Pu is on this line, the vector from the starting point of l1 (this) to
            // Pt will point in the same direction as l1 (this). (the two vectors will have an agle of 0)
            myDouble angleU = (Pu - P1).Angle(Direction);
            if (angleU != 0)
            {
                System.Diagnostics.Trace.WriteLine("(angleU != 0) check failed, no intersection.");
                return null;
            }
            // If the point Pt is on the second line (l), the vector from the starting point of l to
            // Pt will point in the same direction as l. (the two vectors will have an agle of 0)
            myDouble angleT = (Pt - l.P1).Angle(l.Direction);
            if (angleT != 0)
            {
                System.Diagnostics.Trace.WriteLine("(angleT != 0) check failed, no intersection.");
                return null;
            }

            //double dotVectors = Direction.Dot(l.Direction);
            //double dotT = (P1 - l.P1).Dot(l.Direction);
            //double dotU = (l.P1 - P1).Dot(Direction);

            //double t = crossT.Magnitude / crossVectors.Magnitude;
            //if (dotU < 0 != dotVectors < 0)
            //    t *= -1;
            //double u = crossU.Magnitude / crossVectors.Magnitude;
            //if (dotT < 0 != dotVectors < 0)
            //    u *= -1;

            //double t = 0;
            //if (Math.Abs(crossVectors.dx) > double.Epsilon) t = crossT.dx / crossVectors.dx;
            //else if (Math.Abs(crossVectors.dy) > double.Epsilon) t = crossT.dy / crossVectors.dy;
            //else if (Math.Abs(crossVectors.dz) > double.Epsilon) t = crossT.dz / crossVectors.dz;
            //double u = 0;
            //if (Math.Abs(crossVectors.dx) > double.Epsilon) u = crossU.dx / crossVectors.dx;
            //else if (Math.Abs(crossVectors.dy) > double.Epsilon) u = crossU.dy / crossVectors.dy;
            //else if (Math.Abs(crossVectors.dz) > double.Epsilon) u = crossU.dz / crossVectors.dz;

            // we now know that the lines will intersect if the extend to
            //  infinity in both directions, so test to see if the point
            //  between the end points of both lines
            if (t >= 0 && t <= 1 && u >= 0 && u <= 1)
            {
#if __DoubleCheck == false
                //unfortunatly, t is always positive, so we don't detect if the computed
                // intersection is before P1 on the xtended line, so make sie Pi is in the
                // bounding box of the line
                //if (!(Pi <= Max && Pi >= Min) || !(Pi <= l.Max && Pi >= l.Min))
                //{
                //    return null;
                //}
                return Pt;

#endif
            }
            else
            {
                return null;
            }
        //}
#if __DoubleCheck
            Line l1 = this.Reverse();
            Line l2 = l.Reverse();
            Point Pir = null;

            Vector crossVectorsr = l1.Direction.Cross(l2.Direction);
            Vector crossTr = (l1.P1 - l2.P1).Cross(l2.Direction);
            Vector crossUr = (l2.P1 - l1.P1).Cross(l1.Direction);

            if (crossVectors.Magnitude == 0 && crossU.Magnitude == 0)
            {
                //colinear
                return Pir;
            }
            else if (crossVectors.Magnitude == 0 && crossU.Magnitude != 0)
            {
                // parallel 
                return Pir;
            }
            else if (crossVectors.Magnitude != 0)
            {
                double t = crossTr.Magnitude / crossVectorsr.Magnitude;
                double u = crossUr.Magnitude / crossVectorsr.Magnitude;
                if (t >= 0 && t <= 1 && u >= 0 && u <= 1)
                {
                    Pir = l1.P1 + l1.Direction.Scale(t);

                    //unfortunatly, t is always positive, so we don't detect if the computed
                    // intersection is before P1 on the xtended line, so make sie Pi is in the
                    // bounding box of the line
                    //if (!(Pir <= l1.Max && Pir >= l1.Min) || !(Pir <= l2.Max && Pir >= l2.Min))
                    //{
                    //    return null;
                    //}
                }
                else
                {
                    return null;
                }
            }
#endif
        }

       public void Draw(ICanvas c)
        {
            throw new NotImplementedException();
        }
    }
}