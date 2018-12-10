using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas.Data
{
    public class Polygon :IDrawingObject
    {
        public Point[] Points { get; protected set; }
        public bool Fill { get; protected set; }

        public Polygon(Point[] points, bool fill = false)
        {
            Points = points;
            Fill = fill;
        }

        protected Polygon()
        {
            Points = null;
        }

        public void Draw(ICanvas c)
        {
            c.DrawPolygon(this);
        }
    }
}
