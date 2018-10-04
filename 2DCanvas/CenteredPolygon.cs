using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public class CenteredPolygon : IDrawingObject
    {
        protected flPoint Center;
        protected double Orientation;
        protected bool Fill;
        public flPoint Size;


        protected flPoint[] Points;

        public CenteredPolygon(flPoint[] points, bool fill = false)
        {
            Points = points;
            Fill = fill;
        }

        protected CenteredPolygon()
        {
            Points = null;
        }

        public virtual void Draw(ICanvas g)
        {
            g.DrawPolygon(flPoint.Translate(flPoint.Rotate(Points, Orientation),Center));
        }
    }
}
