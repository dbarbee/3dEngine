using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public struct Line : ILine
    {
        public IflPoint P1 { get; set; }
        public IflPoint P2 { get; set; }

        public Line(IflPoint p1, IflPoint p2) { P1 = p1; P2 = p2; }
        public Line(Point p1, Point p2) { P1 = new flPoint(p1); P2 = new flPoint(p2); }
        //public flPoint(Point p) { X = p.X; Y = p.Y; }

        public ILine Translate(IflPoint delta)
        {
            return new Line(P1.Translate(delta), P2.Translate(delta));
        }

        public ILine Scale(IflPoint scale)
        {
            return new Line(P1.Scale(scale), P2.Scale(scale));
        }

        public ILine Scale(double sx, double sy)
        {
            return new Line(P1.Scale(sx, sy), P2.Scale(sx, sy));
        }

        public void Draw(ICanvas c)
        {
            c.DrawLine(this);
        }
    }
}
