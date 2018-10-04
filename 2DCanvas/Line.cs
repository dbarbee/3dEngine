using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public struct Line :IDrawingObject
    {
        public flPoint P1;
        public flPoint P2;

        public Line(flPoint p1, flPoint p2) { P1 = p1; P2 = p2; }
        public Line(Point p1, Point p2) { P1 = new flPoint(p1); P2 = new flPoint(p2); }
        //public flPoint(Point p) { X = p.X; Y = p.Y; }

        public Line Translate(flPoint delta)
        {
            return new Line(P1.Translate(delta), P2.Translate(delta));
        }

        public Line Scale(flPoint scale)
        {
            return new Line(P1.Scale(scale), P2.Scale(scale));
        }

        public Line Scale(double sx, double sy)
        {
            return new Line(P1.Scale(sx, sy), P2.Scale(sx, sy));
        }

        public void Draw(ICanvas c)
        {
            c.DrawLine(this);
        }
    }
}
