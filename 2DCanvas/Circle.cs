using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public class Circle : IDrawingObject
    {
        flPoint Center;
        double Radius;
        bool Fill;

        public Circle(flPoint center, double radius, bool fill=false)
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
