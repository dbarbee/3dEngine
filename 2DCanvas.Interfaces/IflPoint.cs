using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas.Interfaces
{
    public interface IflPoint
    {
        double X { get; set; }
        double Y { get; set; }

        IflPoint Translate(IflPoint delta);

        IflPoint Scale(IflPoint scale);

        IflPoint Scale(double sx, double sy);

        IflPoint Rotate(double degrees);

        IflPoint RotateRad(double radians);     
    }
}
