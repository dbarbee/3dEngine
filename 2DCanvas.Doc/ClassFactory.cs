using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public class ClassFactory : IClassFactory
    {
        private static IClassFactory _instance = new ClassFactory();
        public static IClassFactory Instance { get { return _instance; } }

        public Point NewflPoint()
        {
            return new flPoint();
        }

        public Point NewflPoint(double x, double y)
        {
            return new flPoint(x,y);
        }

        public ILine NewLine()
        {
            return new Line();
        }

        public ILine NewLine(Point p1, Point p2)
        {
            return new Line(p1,p2);
        }

        public IPolygon NewPolygon(Point[] points, bool fill = false)
        {
            return new Polygon(points, fill);
        }
    }
}
