using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public class Polygon : IPolygon
    {
        public IflPoint[] Points { get; protected set; }
        public bool Fill { get; protected set; }

        public Polygon(IflPoint[] points, bool fill = false)
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
            g.DrawPolygon(Points, Fill);
        }
    }
}
