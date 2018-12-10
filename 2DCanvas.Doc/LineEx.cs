using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Data;

namespace dbarbee.GraphicsEngine._2DCanvas.Doc
{
    public static class LineEx
    {
        static LineEx()
        {
            //exDrawingObject.RegisterDrawMethod(typeof(Line).Name, new exDrawingObject.DrawObjectDelegate(Draw));
        }
        public static Line Translate(this Line l, Point delta)
        {
            return new Line(l.P1.Translate(delta), l.P2.Translate(delta));
        }

        public static Line Scale(this Line l, Point scale)
        {
            return new Line(l.P1.Scale(scale), l.P2.Scale(scale));
        }

        public static Line Scale(this Line l, double sx, double sy)
        {
            return new Line(l.P1.Scale(sx, sy), l.P2.Scale(sx, sy));
        }

        public static void Draw(IDrawingObject l, Canvas c)
        {
            c.DrawLine(l as Line);
        }
    }
}
