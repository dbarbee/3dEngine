using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas;
using dbarbee.GraphicsEngine._2DCanvas.Data;

namespace dbarbee.GraphicsEngine._2DCanvas.Doc
{

    // Isosceles Triangle
    public class Triangle : CenteredPolygon
    {
        public Triangle(Point center, Point[] corners, bool fill = false, double orientation = 0)
        {
            Center = center;
            Fill = fill;
            Orientation = orientation;
            Points = new Point[3];

            double minX = double.MaxValue;
            double maxX = double.MinValue;
            double minY = double.MaxValue;
            double maxY = double.MinValue;

            for (int idx = 0; idx < 3; idx++)
            {
                Points[idx] = corners[idx];

                if (Points[idx].X > maxX) maxX = Points[idx].X;
                if (Points[idx].X < minX) minX = Points[idx].X;
                if (Points[idx].Y > maxY) maxY = Points[idx].Y;
                if (Points[idx].Y < minY) minY = Points[idx].Y;
            }
            Size = new Point((maxX - minX / 2), (maxY - minY / 2));
        }
    }
    // Isosceles Triangle
    public class IsoscelesTriangle : CenteredPolygon
    {
        public IsoscelesTriangle(Point center, Point size, bool fill = false, double orientation = 0)
        {
            Center = center;
            Size = size;
            Fill = fill;
            Orientation = orientation;
            Points = new Point[3];

            Points[0] = new Point(-size.X / 2, -size.Y / 2);
            Points[1] = new Point(size.X / 2, -size.Y / 2);
            Points[2] = new Point(0, size.Y / 2);
        }
    }

    // Equilateral Triangle
    public class EquilateralTriangle : CenteredPolygon
    {
        public float Radius;
        public EquilateralTriangle(Point center, float radius, bool fill = false, double orientation = 0)
        {
            Radius = radius;
            Center = center;
            Fill = fill;
            Orientation = orientation;
            Points = new Point[3];

            double dx = Math.Sin(Math.PI / 3) * radius;

            Points[0] = new Point(-dx, -radius / 2);
            Points[1] = new Point(dx, -radius / 2);
            Points[2] = new Point(0, radius);

            double minX = double.MaxValue;
            double maxX = double.MinValue;
            double minY = double.MaxValue;
            double maxY = double.MinValue;

            for (int idx = 0; idx < 3; idx++)
            {
                if (Points[idx].X > maxX) maxX = Points[idx].X;
                if (Points[idx].X < minX) minX = Points[idx].X;
                if (Points[idx].Y > maxY) maxY = Points[idx].Y;
                if (Points[idx].Y < minY) minY = Points[idx].Y;
            }
            Size = new Point((maxX - minX / 2), (maxY - minY / 2));
        }
    }
    // Right Triangle
    public class RightTriangle : CenteredPolygon
    {
        public RightTriangle(Point center, Point size, bool fill = false, double orientation = 0)
        {
            Center = center;
            Size = size;
            Fill = fill;
            Orientation = orientation;
            Points = new Point[3];

            Points[0] = new Point(-size.X / 2, -size.Y / 2);
            Points[1] = new Point(size.X / 2, -size.Y / 2);
            Points[2] = new Point(-size.X / 2, size.Y / 2);
        }
    }

}
