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

        //Object List
        void ClearObjects();
        void AddObject(IDrawingObject o);
        void AddObject(string key,IDrawingObject o);

        //Points

        // Draw an individual point on the screen as a small filled circle 
        //  with diameter of 1 logical unit
        void DrawPoint(Point p);

        // Lines

        // Draw an individual line 
        //void DrawLine(Point p1, Point p2);
        void DrawLine(Point p1, Point p2, UInt32? c = null);
        void DrawLine(Line l);

        // Draw a series of connected line segments
        //void DrawPolyLine(Point[] points);
        void DrawPolyLine(Point[] points, UInt32? c = null);

        // Draw a list of individually defined lines
        void DrawLines(Line[] lines);

        // Shapes
        // Draw a Polygon, a closed series (Last point in series connects 
        //  back to the first) of lines defined by a list of points
        //void DrawPolygon(Point[] points, bool fill = false);

        void DrawPolygon(Point[] points, UInt32? edgeColor = 0xFFFFFFFF, UInt32? fillColor = 0xFF7F7F7F);

        void DrawPolygon(Polygon polygon);

        // Draw a circle
        void DrawCircle(Point c, double r, UInt32? edgeColor = 0xFFFFFFFF, UInt32? fillColor = 0xFF7F7F7F);
        void DrawCircle(Circle c);
    }
}
