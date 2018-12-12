using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas;
using dbarbee.GraphicsEngine._2DCanvas.Data;

namespace dbarbee.GraphicsEngine._2DCanvas.Doc
{
    public class Rectangle : CenteredPolygon
    {
        public Rectangle(Point center, Point size, double orientation = 0, Color edgeColor = null, Color fillColor = null)
        {
            Center = center;
            Size = size;
            Orientation = orientation;
            EdgeColor = edgeColor;
            FillColor = fillColor;

            Points = new Point[4];

            Points[0] = new Point(-size.X / 2, -size.Y / 2);
            Points[1] = new Point(-size.X / 2, size.Y / 2);
            Points[2] = new Point(size.X / 2, size.Y / 2);
            Points[3] = new Point(size.X / 2, -size.Y / 2);
        }
    }
}
