using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._3DEngine
{
    public interface I3DObject
    {
        Point Max { get; }
        Point Min { get; }
        Point Center { get; }

        I3DObject RotateXY(double degrees);
        I3DObject RotateXZ(double degrees);
        I3DObject RotateYZ(double degrees);

        I3DObject Scale(Vector scale);
        I3DObject Scale(double scale);
        I3DObject Translate(Vector delta);

        void Render(I3DCamera c);
    }
}
