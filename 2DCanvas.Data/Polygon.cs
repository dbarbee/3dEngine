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

        public Color EdgeColor { get; protected set; }
        public Color FillColor { get; protected set; }
        public Polygon(Point[] points, Color edgeColor = null, Color fillColor= null)
        {
            Points = points;
            if (edgeColor == null)
            {
                EdgeColor = Color.Black;
            }
            else
            {
                EdgeColor = edgeColor;
            }
             if (fillColor == null)
            {
                FillColor = Color.TransMediumGray;
            }
            else
            {
                FillColor = fillColor;
            }
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
