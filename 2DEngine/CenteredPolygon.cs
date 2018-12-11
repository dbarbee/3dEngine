using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public class CenteredPolygon : IDrawingObject
    {
        protected IflPoint Center;
        protected double Orientation;
        protected bool Fill;
        public IflPoint Size;

        protected IflPoint[] Points;

        public CenteredPolygon(IflPoint[] points, bool fill = false)
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
            g.DrawPolygon(Globals.Translate(Globals.Rotate(Points, Orientation),Center));
        }
    }
}
