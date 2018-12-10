using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._2DEngine
{
    public class Rectangle : CenteredPolygon
    {
        public Rectangle(IflPoint center, IflPoint size, bool fill=false, double orientation = 0)
        {
            Center = center;
            Size = size;
            Fill = fill;
            Orientation = orientation;
            Points = new IflPoint[4];

            Points[0] =  Globals.Classfactory.NewflPoint(-size.X / 2, -size.Y / 2);
            Points[1] =  Globals.Classfactory.NewflPoint(-size.X / 2, size.Y / 2);
            Points[2] =  Globals.Classfactory.NewflPoint(size.X / 2, size.Y / 2);
            Points[3] =  Globals.Classfactory.NewflPoint(size.X / 2, -size.Y / 2);
        }
    }
}
