using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public class Polygon : IDrawingObject
    {
        protected flPoint[] Points;
        protected bool Fill;
        public Polygon(flPoint[] points, bool fill = false)
        {
            Points = points;
            Fill = fill;
        }

        protected Polygon()
        {
            Points = null;
        }

        public virtual void Draw(ICanvas g)
        {
            g.DrawPolygon(Points);
        }
    }
}
