using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas.Interfaces
{
    public interface ICanvas
    {
        IClassFactory ClassFactory { get; }

        IflPoint szViewport { get; set; }
        IflPoint ptViewport { get; set; }
        object CurrentPen { get; set; }
        object CurrentBrush { get; set; }

        //Points

        // Lines
        // Draw an individual point on the screen as a small filled circle 
        //  with diameter of 1 logical unit
        void DrawPoint(IflPoint p);

        // Draw an individual line 
        //void DrawLine(Point p1, Point p2);
        void DrawLine(IflPoint p1, IflPoint p2);
        void DrawLine(ILine l);

        // Draw a series of connected line segments
        //void DrawPolyLine(Point[] points);
        void DrawPolyLine(IflPoint[] points);

        // Draw a list of individually defined lines
        void DrawLines(ILine[] lines);

        // Shapes
        // Draw a Polygon, a closed series (Last point in series connects 
        //  back to the first) of lines defined by a list of points
        //void DrawPolygon(Point[] points, bool fill = false);

        void DrawPolygon(IflPoint[] points, bool fill = false);

        void DrawPolygon(IPolygon polygon, bool fill = false);

        // Draw a circle
        void DrawCircle(IflPoint c, double r, bool fill = false);
    }
}
