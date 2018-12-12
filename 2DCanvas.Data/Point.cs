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
        public Color Color { get; set; }

        public Point(double x, double y, Color c = null) { X = x; Y = y; Color = c; }
        public Point(int x, int y, Color c = null) { X = x; Y = y; Color = c; }
        //public Point(System.Drawing.Point p) { X = p.X; Y = p.Y; }
        //public Point(System.Drawing.Size s) { X = s.Width; Y = s.Height; }

        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }

        public void Draw(ICanvas c)
        {
            c.DrawPoint(this);
        }
    }
}
