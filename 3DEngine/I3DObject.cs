using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._3DEngine
{
    public interface I3DObject : IDrawingObject
    {
        Point Max { get; }
        Point Min { get; }
        Point Center { get; }
    }
}
