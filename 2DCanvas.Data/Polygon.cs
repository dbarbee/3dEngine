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

        public UInt32? EdgeColor { get; protected set; }
        public UInt32? FillColor { get; protected set; }

        public Polygon(Point[] points, UInt32? edgeColor = 0xFFFFFFFF, UInt32? fillColor = 0X00000000)
        {
            Points = points;
            EdgeColor = edgeColor;
            FillColor = fillColor;// 0x7F7F7F7F;
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
