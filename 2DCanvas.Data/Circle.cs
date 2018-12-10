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
        bool Fill;

        public Circle(Point center, double radius, bool fill=false)
        {
            Center = center;
            Radius = radius;
            Fill = fill;
        }

        public void Draw(ICanvas g)
        {
            g.DrawCircle(Center, Radius, Fill);
        }
    }
}
