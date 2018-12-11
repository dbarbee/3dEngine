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
        public static Line Translate(this Line l, Point delta)
        {
            return new Line((Point)l.P1.Translate(delta), (Point)l.P2.Translate(delta));
        }

        public static Line Scale(this Line l, Point scale)
        {
            return new Line(l.P1.Scale(scale), l.P2.Scale(scale));
        }

        public static Line Scale(this Line l, double sx, double sy)
        {
            return new Line(l.P1.Scale(sx, sy), l.P2.Scale(sx, sy));
        }

        public static Line[] Translate(Line[] lines, Point delta)
        {
            Line[] val = new Line[lines.Length];
            for (int idx = 0; idx<lines.Length; idx++)
            {
                val[idx]= lines[idx].Translate(delta);
            }
            return val;
        }

        public static Line[] Scale(Line[] lines, Point scale)
        {
            Line[] val = new Line[lines.Length];
            for (int idx = 0; idx < lines.Length; idx++)
            {
                val[idx] = lines[idx].Scale(scale);
            }
            return val;
        }

        public static Line[] Scale(Line[] lines, double sx, double sy)
        {
            Line[] val = new Line[lines.Length];
            for (int idx = 0; idx < lines.Length; idx++)
            {
                val[idx] = lines[idx].Scale(sx,sy);
            }
            return val;
        }

    }
}
