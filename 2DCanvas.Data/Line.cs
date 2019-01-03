using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas.Data
{
    public class Line : IDrawingObject
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public UInt32? Color { get; set; }

        public Line(Point p1, Point p2, UInt32? c = 0xFFFFFFFF) { P1 = p1; P2 = p2; Color = c; }
        //public Line(System.Drawing.Point p1, System.Drawing.Point p2) { P1 = new Point(p1); P2 = new Point(p2); }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", P1, P2);
        }

        public void Draw(ICanvas c)
        {
            c.DrawLine(this);
        }
        //public flPoint(Point p) { X = p.X; Y = p.Y; }
    }
}
