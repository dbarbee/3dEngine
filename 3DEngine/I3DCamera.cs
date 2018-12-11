using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._3DEngine
{
    public interface I3DCamera
    {
        void DrawPoint(Point p);
        void DrawLine(Line l);
        void DrawSurface(Surface s);
    }
}
