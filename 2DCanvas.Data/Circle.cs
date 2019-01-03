using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas.Data
{
    public class Circle : IDrawingObject
    {
        public Point Center { get; protected set; }
        public double Radius { get; protected set; }
        public UInt32? EdgeColor { get; protected set; }
        public UInt32? FillColor { get; protected set; }

        public Circle(Point center, double radius, UInt32? edgeColor = 0XFFFFFFFF, UInt32? fillColor = 0XFF7F7F7F)
        {
            Center = center;
            Radius = radius;
            EdgeColor = edgeColor;
            FillColor = fillColor;
        }

        public void Draw(ICanvas g)
        {
            g.DrawCircle(this);
        }
    }
}
