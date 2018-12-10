using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas.Interfaces
{
    public interface IClassFactory
    {
        //IClassFactory Instance { get; }

        IflPoint NewflPoint();

        IflPoint NewflPoint(double x, double y);

        ILine NewLine();

        ILine NewLine(IflPoint p1, IflPoint p2);

        IPolygon NewPolygon(IflPoint[] points, bool fill = false);
    }
}
