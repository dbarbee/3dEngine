using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Data;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public static class exPolygon
    {
        public virtual void Draw(this IDrawingObject p, ICanvas g)
        {
            Polygon poly = p as Polygon;
            if (poly == null) return;
            g.DrawPolygon(poly.Points, poly.Fill);
        }
    }
}
