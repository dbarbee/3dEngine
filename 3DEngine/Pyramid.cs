using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._3DEngine
{
    public class Pyramid : Solid
    {
        public Pyramid(Point center, double dx, double dy, double dz)
        {
            Point[] vertices = new Point[4];

            vertices[0] = (Point) new Point(0, 0, dz / 2).Translate(center);
            vertices[1] =  (Point)new Point( -(dx / 2), -(dy / 2), 0).Translate(center);
            vertices[2] =  (Point)new Point((dx / 2), -(dy / 2), 0).Translate(center);
            vertices[3] =  (Point)new Point(0, (dy / 2), 0).Translate(center);
            
            Surface[] surfaces = new Surface[4];
            surfaces[0] = new Surface(new Point[] { vertices[0], vertices[1], vertices[2] }, true);
            surfaces[1] = new Surface(new Point[] { vertices[0], vertices[1], vertices[3] }, true);
            surfaces[2] = new Surface(new Point[] { vertices[0], vertices[2], vertices[3] }, true);
            surfaces[3] = new Surface(new Point[] { vertices[1], vertices[2], vertices[3] }, true);

            Surfaces = surfaces;
        }
    }
}
