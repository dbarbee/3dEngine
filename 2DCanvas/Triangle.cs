using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public class Triangle : CenteredPolygon
    {
        public Triangle(flPoint center, flPoint size, bool fill = false, double orientation = 0)
        {
            Center = center;
            Size = size;
            Fill = fill;
            Orientation = orientation;
            Points = new flPoint[3];

            Points[0] = new flPoint(-size.X / 2, -size.Y / 2);
            Points[1] = new flPoint(size.X / 2, -size.Y / 2);
            Points[2] = new flPoint(0, size.Y / 2);
        }
    }
}
