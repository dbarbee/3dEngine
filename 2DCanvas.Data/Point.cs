using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas.Data
{
    public class Point :IDrawingObject
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y) { X = x; Y = y; }
        public Point(int x, int y) { X = x; Y = y; }
        //public Point(System.Drawing.Point p) { X = p.X; Y = p.Y; }
        //public Point(System.Drawing.Size s) { X = s.Width; Y = s.Height; }

        public void Draw(ICanvas c)
        {
            c.DrawPoint(this);
        }
    }
}
