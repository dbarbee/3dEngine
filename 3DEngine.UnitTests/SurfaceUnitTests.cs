using Microsoft.VisualStudio.TestTools.UnitTesting;
using dbarbee.GraphicsEngine._3DEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._3DEngine.UnitTests
{
    [TestClass()]
    public class SurfaceUnitTests
    {
        [TestMethod()]
        public void LineIntersectionTest()
        {
            // create a surface that is a 4x4 square around the z axis on the xy plane (z=0 for all vertices)
            Point[] Vertices_Sz0 = new Point[4];
            Vertices_Sz0[0] = new Point(2, 2, 0);
            Vertices_Sz0[1] = new Point(2, -2, 0);
            Vertices_Sz0[2] = new Point(-2, -2, 0);
            Vertices_Sz0[3] = new Point(-2, 2, 0);
            Surface Sz0 = new Surface(Vertices_Sz0, true);

            Line l01 = new Line(new Point(1, 1, 3), new Point(1, 1, -3));

            Point expected = new Point(1, 1, 0);
            Point actual = Sz0.Intersection(l01);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);

            Line l02 = new Line(new Point(1, 1, 3), new Point(-1, 1.5, -3));

            //expected = new Point(1, 1, 0);
            actual = Sz0.Intersection(l01);

            Assert.IsNotNull(actual);
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SurfaceIntersectionTest()
        {
            Point[] Vertices_Sx0 = new Point[4];
            Vertices_Sx0[0] = new Point(0, 2, 2);
            Vertices_Sx0[1] = new Point(0, 2, -2);
            Vertices_Sx0[2] = new Point(0, -2, -2);
            Vertices_Sx0[3] = new Point(0, -2, 2);
            Surface Sx0 = new Surface(Vertices_Sx0, true);

            Point[] Vertices_Sy0 = new Point[4];
            Vertices_Sy0[0] = new Point(2, 0, 2);
            Vertices_Sy0[1] = new Point(2, 0, -2);
            Vertices_Sy0[2] = new Point(-2, 0, -2);
            Vertices_Sy0[3] = new Point(-2, 0, 2);
            Surface Sy0 = new Surface(Vertices_Sy0, true);

            Point[] Vertices_Sz0 = new Point[4];
            Vertices_Sz0[0] = new Point(2, 2, 0);
            Vertices_Sz0[1] = new Point(2, -2, 0);
            Vertices_Sz0[2] = new Point(-2, -2, 0);
            Vertices_Sz0[3] = new Point(-2, 2, 0);
            Surface Sz0 = new Surface(Vertices_Sz0, true);

            Line actual = Sx0.Intersection(Sy0);
            Assert.IsNotNull(actual);
  
            Point[] Vertices_Sx5 = new Point[4];
            Vertices_Sx5[0] = new Point(5, 2, 2);
            Vertices_Sx5[1] = new Point(5, 2, -2);
            Vertices_Sx5[2] = new Point(5, -2, -2);
            Vertices_Sx5[3] = new Point(5, -2, 2);
            Surface Sx5 = new Surface(Vertices_Sx5, true);

            Point[] Vertices_Sy5 = new Point[4];
            Vertices_Sy5[0] = new Point(2, 5, 2);
            Vertices_Sy5[1] = new Point(2, 5, -2);
            Vertices_Sy5[2] = new Point(-2, 5, -2);
            Vertices_Sy5[3] = new Point(-2, 5, 2);
            Surface Sy5 = new Surface(Vertices_Sy5, true);

            Point[] Vertices_Sz5 = new Point[4];
            Vertices_Sz5[0] = new Point(2, 2, 5);
            Vertices_Sz5[1] = new Point(2, -2, 5);
            Vertices_Sz5[2] = new Point(-2, -2, 5);
            Vertices_Sz5[3] = new Point(-2, 2, 5);
            Surface Sz5 = new Surface(Vertices_Sz5, true);

            actual = Sx5.Intersection(Sy5);
            Assert.IsNotNull(actual);

            List<Surface> surfaces = new List<Surface>();
            surfaces.Add(Sx0);
            surfaces.Add(Sy0);
            surfaces.Add(Sz0);
            surfaces.Add(Sx5);
            surfaces.Add(Sy5);
            surfaces.Add(Sz5);

            for (int idx1=0;idx1<surfaces.Count;idx1++)
            {
                for (int idx2 = 0; idx2 < surfaces.Count; idx2++)
                {
                    actual = surfaces[idx1].Intersection(surfaces[idx2]);
                    if (surfaces[idx1].AreParallel(surfaces[idx2]))
                    {
                        if (actual != null)
                        {
                            System.Diagnostics.Debugger.Break();
                        }
                        Assert.IsNull(actual);
                    }
                    else
                    {
                        if (actual == null)
                        {
                            System.Diagnostics.Debugger.Break();
                        }
                        Assert.IsNotNull(actual);
                    }
                }
            }
        }
    }
}