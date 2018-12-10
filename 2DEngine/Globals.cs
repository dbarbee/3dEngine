using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._2DEngine
{
    public class Globals
    {
        public static IClassFactory Classfactory { get; set; }

        public static IflPoint[] Translate(IflPoint[] points, IflPoint delta)
        {
            IflPoint[] value = new IflPoint[points.Length];
            for (int idx = 0; idx < points.Length; idx++)
            {
                value[idx] = points[idx].Translate(delta);
            }
            return value;
        }

        public static IflPoint[] Scale(IflPoint[] points, IflPoint scale)
        {
            IflPoint[] value = new IflPoint[points.Length];
            for (int idx = 0; idx < points.Length; idx++)
            {
                value[idx] = points[idx].Scale(scale);
            }
            return value;
        }

        public static IflPoint[] Scale(IflPoint[] points, double sx, double sy)
        {
            IflPoint[] value = new IflPoint[points.Length];
            for (int idx = 0; idx < points.Length; idx++)
            {
                value[idx] = points[idx].Scale(sx, sy);
            }
            return value;
        }

        public static IflPoint[] Rotate(IflPoint[] points, double degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            return RotateRad(points, radians);
        }

        public static IflPoint[] RotateRad(IflPoint[] points, double radians)
        {
            IflPoint[] value = new IflPoint[points.Length];
            for (int idx = 0; idx < points.Length; idx++)
            {
                value[idx] = points[idx].RotateRad(radians);
            }
            return value;
        }

    }
}
