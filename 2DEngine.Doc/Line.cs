using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas.Data
{
    public class Line : DrawingObject
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }

        public Line(Point p1, Point p2) { P1 = p1; P2 = p2; }
        //public Line(System.Drawing.Point p1, Point p2) { P1 = new Point(p1); P2 = new Point(p2); }
        //public flPoint(Point p) { X = p.X; Y = p.Y; }
    }
}
