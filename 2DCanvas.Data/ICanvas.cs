using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas.Data
{
    public interface ICanvas
    {
        Point szViewport { get; set; }
        Point ptViewport { get; set; }
        object CurrentPen { get; set; }
        object CurrentBrush { get; set; }

        //Points

        // Lines
        // Draw an individual point on the screen as a small filled circle 
        //  with diameter of 1 logical unit
        void DrawPoint(Point p);

        // Draw an individual line 
        //void DrawLine(Point p1, Point p2);
        void DrawLine(Point p1, Point p2);
        void DrawLine(Line l);

        // Draw a series of connected line segments
        //void DrawPolyLine(Point[] points);
        void DrawPolyLine(Point[] points);

        // Draw a list of individually defined lines
        void DrawLines(Line[] lines);

        // Shapes
        // Draw a Polygon, a closed series (Last point in series connects 
        //  back to the first) of lines defined by a list of points
        //void DrawPolygon(Point[] points, bool fill = false);

        void DrawPolygon(Point[] points, bool fill = false);

        void DrawPolygon(Polygon polygon, bool fill = false);

        // Draw a circle
        void DrawCircle(Point c, double r, bool fill = false);
    }
}
