using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._3DEngine;

namespace dbarbee.GraphicsEngine._3DView
{
    /// <summary>
    /// A collection of 3d objects that make up a scene
    /// </summary>
    class Scene
    {
        SortedList<double, I3DObject> DrawList;
    }
}
