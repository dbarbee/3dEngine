﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbarbee.GraphicsEngine._2DCanvas;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public class RegularPolygon : CenteredPolygon
    {
        double Radius;

        public RegularPolygon(IflPoint center, int numSides, double radius, bool fill = false, double orientation = 0)
        {
            Center = center;
            Radius = radius;
            Fill = fill;
            Orientation = orientation;
            Points = new IflPoint[numSides];

            double deltaAngle = 2.0 * Math.PI / numSides;
            double minX = double.MaxValue;
            double maxX = double.MinValue;
            double minY = double.MaxValue;
            double maxY = double.MinValue;

            for (int idx = 0; idx < numSides; idx++)
            {
                double angle = idx * deltaAngle;

                Points[idx] = Globals.Classfactory.NewflPoint(radius * Math.Sin(angle), radius * Math.Cos(angle));

                if (Points[idx].X > maxX) maxX = Points[idx].X;
                if (Points[idx].X < minX) minX = Points[idx].X;
                if (Points[idx].Y > maxY) maxY = Points[idx].Y;
                if (Points[idx].Y < minY) minY = Points[idx].Y;
            }

            Size = Globals.Classfactory.NewflPoint((maxX - minX / 2), (maxY - minY / 2));
        }
    }
}