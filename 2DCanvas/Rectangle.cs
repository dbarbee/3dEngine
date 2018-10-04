using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public class Rectangle : CenteredPolygon
    {
        public Rectangle(flPoint center, flPoint size, bool fill=false, double orientation = 0)
        {
            Center = center;
            Size = size;
            Fill = fill;
            Orientation = orientation;
            Points = new flPoint[4];

            Points[0] = new flPoint(-size.X / 2, -size.Y / 2);
            Points[1] = new flPoint(-size.X / 2, size.Y / 2);
            Points[2] = new flPoint(size.X / 2, size.Y / 2);
            Points[3] = new flPoint(size.X / 2, -size.Y / 2);
        }
    }
}
