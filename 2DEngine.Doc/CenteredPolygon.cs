using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Data;

namespace dbarbee.GraphicsEngine._2DCanvas.Doc
{
    public class CenteredPolygon : IDrawingObject
    {
        protected Point Center;
        protected double Orientation;
        protected bool Fill;
        public Point Size;

        protected Point[] Points;

        public CenteredPolygon(Point[] points, bool fill = false)
        {
            Points = points;
            Fill = fill;
        }

        protected CenteredPolygon()
        {
            Points = null;
        }

        public void Draw(ICanvas c)
        {
            c.DrawPolygon(PointEx.Translate(PointEx.Rotate(Points, Orientation),Center));
        }
    }
}
