using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public interface ICanvas
    {
        Size szViewport { get; set; }
        Pen CurrentPen { get; set; }
        Brush CurrentBrush { get; set; }


        // Lines

        // Draw an individual line 
        void DrawLine(Point p1, Point p2);
        void DrawLine(flPoint p1, flPoint p2);
        void DrawLine(Line l);

        // Draw a series of connected line segments
        void DrawPolyLine(Point[] points);
        void DrawPolyLine(flPoint[] points);

        // Draw a list of individually defined lines
        void DrawLines(Line[] lines);

        // Shapes
        // Draw a Polygon, a closed series (Last point in series connects 
        //  back to the first) of lines defined by a list of points
        void DrawPolygon(Point[] points, bool fill = false);

        void DrawPolygon(flPoint[] points, bool fill = false);

        // Draw a circle
        void DrawCircle(flPoint c, double r, bool fill = false);
    }
}
