using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas.Data
{
    public class Circle : IDrawingObject
    {
        Point Center;
        double Radius;
        public Color EdgeColor { get; protected set; }
        public Color FillColor { get; protected set; }

        public Circle(Point center, double radius, Color edgeColor = null, Color fillColor = null)
        {
            Center = center;
            Radius = radius;
            EdgeColor = edgeColor;
            FillColor = fillColor;
        }

        public void Draw(ICanvas g)
        {
            g.DrawCircle(Center, Radius, EdgeColor, FillColor);
        }
    }
}
