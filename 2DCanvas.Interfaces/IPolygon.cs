﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas.Interfaces
{
    public interface IPolygon : IDrawingObject
    {
         IflPoint[] Points { get; }
    }
}
