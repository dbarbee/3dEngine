using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas.Data
{
    public interface IDrawingObject
    {
        void Draw(ICanvas c);
    }
}
