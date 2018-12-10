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
    public class LineUnitTests
    {
        [TestMethod()]
        public void LineTest()
        {
            Line line01 = new Line(new Point(-1, -1, -1), new Point(1, 1, 1));

            Assert.IsNotNull(line01);
        }

        [TestMethod()]
        public void IntersectTest()
        {
            Line line01 = new Line(new Point(-1, -1, -1), new Point(1, 1, 1));
            Line line01p = new Line(new Point(0, -1, -1), new Point(2, 1, 1));
            Line line02 = new Line(new Point(0, -1, -1), new Point(0, 1, 1));

            Point expected = new Point(0, 0, 0);

            Point actual = line01.Intersect(line02);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
            actual = line02.Intersect(line01);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);

            //parallel lines don't intersect
            actual = line01p.Intersect(line01);
            Assert.IsNull(actual);
            actual = line01.Intersect(line01p);
            Assert.IsNull(actual);

            Line line03 = new Line(new Point(10, -10, 10), new Point(10, 10, 10));
            actual = line01.Intersect(line03);
            Assert.IsNull(actual);
            actual = line03.Intersect(line01);
            Assert.IsNull(actual);

            Line line04 = new Line(new Point(10, 10, 10), new Point(20, 20, 20));
            actual = line01.Intersect(line04);
            Assert.IsNull(actual);
            actual = line04.Intersect(line01);
            Assert.IsNull(actual);

            Line line10 = new Line(new Point(1, 1, 1), new Point(-1, -1, -1));
            Line line11 = new Line(new Point(0, 1, 1), new Point(0, -1, -1));

            // line01 and line10 are colinear
            actual = line01.Intersect(line10);
            Assert.IsNull(actual);
            actual = line10.Intersect(line01);
            Assert.IsNull(actual);

            actual = line10.Intersect(line11);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
            actual = line11.Intersect(line10);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);

            actual = line01.Intersect(line11);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
            actual = line11.Intersect(line01);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);

            Line line05 = new Line(new Point(0, 0, 1), new Point(0, 0, 10));
            actual = line01.Intersect(line05);
            Assert.IsNull(actual);
            actual = line05.Intersect(line01);
            Assert.IsNull(actual);

            Line line06 = new Line(new Point(0, 0, 10), new Point(0, 0, 1));
            actual = line01.Intersect(line06);
            Assert.IsNull(actual);
            actual = line06.Intersect(line01);

            actual = line10.Intersect(line05);
            Assert.IsNull(actual);
            actual = line05.Intersect(line10);
            Assert.IsNull(actual);

            actual = line10.Intersect(line06);
            Assert.IsNull(actual);
            actual = line06.Intersect(line10);
            Assert.IsNull(actual);

            List<Line> Diagnals= new List<Line>();
            int idx1 = 0;
            int idx2 = 0;
            //Diagnals on 3 dimensions
            Diagnals.Add(new Line(new Point(-1, -1, -1), new Point(1, 1, 1)));
            Diagnals.Add(new Line(new Point(-1, -1, 1), new Point(1, 1, -1)));
            Diagnals.Add(new Line(new Point(-1, 1, -1), new Point(1, -1, 1)));
            Diagnals.Add(new Line(new Point(-1, 1, 1), new Point(1, -1, -1)));
            Diagnals.Add(new Line(new Point(1, -1, -1), new Point(-1, 1, 1)));
            Diagnals.Add(new Line(new Point(1, -1, 1), new Point(-1, 1, -1)));
            Diagnals.Add(new Line(new Point(1, 1, -1), new Point(-1, -1, 1)));
            Diagnals.Add(new Line(new Point(1, 1, 1), new Point(-1, -1, -1)));
            // Diagonals on 2 dimensions
            Diagnals.Add(new Line(new Point(-1, -1, 0), new Point(1, 1, 0)));
            Diagnals.Add(new Line(new Point(-1, 1, 0), new Point(1, -1, 0)));
            Diagnals.Add(new Line(new Point(1, -1, 0), new Point(-1, 1, 0)));
            Diagnals.Add(new Line(new Point(1, 1, 0), new Point(-1, -1, 0)));
            Diagnals.Add(new Line(new Point(-1, 0, -1), new Point(1, 0, 1)));
            Diagnals.Add(new Line(new Point(-1, 0, 1), new Point(1, 0, -1)));
            Diagnals.Add(new Line(new Point(1, 0, -1), new Point(-1, 0, 1)));
            Diagnals.Add(new Line(new Point(1, 0, 1), new Point(-1, 0, -1)));
            Diagnals.Add(new Line(new Point(0, -1, -1), new Point(0, 1, 1)));
            Diagnals.Add(new Line(new Point(0, -1, 1), new Point(0, 1, -1)));
            Diagnals.Add(new Line(new Point(0, 1, -1), new Point(0, -1, 1)));
            Diagnals.Add(new Line(new Point(0, 1, 1), new Point(0, -1, -1)));
            // Diagonals on 1 dimension
            Diagnals.Add(new Line(new Point(1, 0, 0), new Point(-1, 0, 0)));
            Diagnals.Add(new Line(new Point(0, 1, 0), new Point(0, -1, 0)));
            Diagnals.Add(new Line(new Point(0, 0, 1), new Point(0, 0, -1)));
            Diagnals.Add(new Line(new Point(-1, 0, 0), new Point(1, 0, 0)));
            Diagnals.Add(new Line(new Point(0, -1, 0), new Point(0, 1, 0)));
            Diagnals.Add(new Line(new Point(0, 0, -1), new Point(0, 0, 1)));

            for (idx1 = 0; idx1 < Diagnals.Count; idx1++)
            {
                for (idx2 = 0; idx2 < Diagnals.Count; idx2++)
                {
                    if (idx1 != idx2)
                    {
                        actual = Diagnals[idx1].Intersect(Diagnals[idx2]);
                        if (Diagnals[idx1].AreCollinear(Diagnals[idx2]))
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
                            Assert.AreEqual(expected, actual);
                        }
                    }
                }
            }

            List<Line> Rays = new List<Line>();
            idx1 = 0;
            idx2 = 0;
            Rays.Add(new Line(new Point(-2, -2, -2), new Point(-4, -4, -4)));
            Rays.Add(new Line(new Point(-2, -2, 2), new Point(-4, -4, 4)));
            Rays.Add(new Line(new Point(-2, 2, -2), new Point(-4, 4, -4)));
            Rays.Add(new Line(new Point(-2, 2, 2), new Point(-4, 4, 4)));
            Rays.Add(new Line(new Point(2, -2, -2), new Point(4, -4, -4)));
            Rays.Add(new Line(new Point(2, -2, 2), new Point(4, -4, 4)));
            Rays.Add(new Line(new Point(2, 2, -2), new Point(4, 4, -4)));
            Rays.Add(new Line(new Point(2, 2, 2), new Point(4, 4, 4)));

            Rays.Add(new Line(new Point(-2, -2, 0), new Point(-4, -4, 0)));
            Rays.Add(new Line(new Point(-2, 2, 0), new Point(-4, 4, 0)));
            Rays.Add(new Line(new Point(2, -2, 0), new Point(4, -4, 0)));
            Rays.Add(new Line(new Point(2, 2, 0), new Point(4, 4, 0)));
            Rays.Add(new Line(new Point(-2, 0, -2), new Point(-4, 0, -4)));
            Rays.Add(new Line(new Point(-2, 0, 2), new Point(-4, 0, 4)));
            Rays.Add(new Line(new Point(2, 0, -2), new Point(4, 0, -4)));
            Rays.Add(new Line(new Point(2, 0, 2), new Point(4, 0, 4)));
            Rays.Add(new Line(new Point(0, -2, -2), new Point(0, -4, -4)));
            Rays.Add(new Line(new Point(0, -2, 2), new Point(0, -4, 4)));
            Rays.Add(new Line(new Point(0, 2, -2), new Point(0, 4, -4)));
            Rays.Add(new Line(new Point(0, 2, 2), new Point(0, 4, 4)));

            Rays.Add(new Line(new Point(-2, 0, 0), new Point(-4, 0, 0)));
            Rays.Add(new Line(new Point(0, -2, 0), new Point(0, -4, 0)));
            Rays.Add(new Line(new Point(0, 0, -2), new Point(0, 0, -4)));
            Rays.Add(new Line(new Point(2, 0, 0), new Point(4, 0, 0)));
            Rays.Add(new Line(new Point(0, 2, 0), new Point(0, 4, 0)));
            Rays.Add(new Line(new Point(0, 0, 2), new Point(0, 0, 4)));

            int cntRays = Rays.Count;
            for (idx2 = 0; idx2 < cntRays; idx2++)
            {
                Rays.Add(Rays[idx2].Reverse());
            }

            for (idx1 = 0; idx1 < Rays.Count; idx1++)
            {
                for (idx2 = 0; idx2 < Rays.Count; idx2++)
                {
                    if (idx1 != idx2)
                    {
                        actual = Rays[idx1].Intersect(Rays[idx2]);
                        if (actual != null)
                        {
                            System.Diagnostics.Debugger.Break();
                        }
                        Assert.IsNull(actual);
                    }
                }
            }

            for (idx1 = 0; idx1 < Diagnals.Count; idx1++)
            {
                for (idx2 = 0; idx2 < cntRays; idx2++)
                {
                    actual = Diagnals[idx1].Intersect(Rays[idx2]);
                    if (actual != null)
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                    Assert.IsNull(actual);

                    actual = Rays[idx2].Intersect(Diagnals[idx1]);
                    if (actual != null)
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                    Assert.IsNull(actual);
                }
            }
        }

        //[TestMethod()]
        //public void Intersect2Test()
        //{
        //    Line line01 = new Line(new Point(-1, -1, -1), new Point(1, 1, 1));
        //    Line line02 = new Line(new Point(0, -1, -1), new Point(0, 1, 1));

        //    Point expected = new Point(0, 0, 0);

        //    Point actual = line01.Intersect2(line02);
        //    Assert.IsNotNull(actual);
        //    Assert.AreEqual(expected, actual);
        //    actual = line02.Intersect2(line01);
        //    Assert.IsNotNull(actual);
        //    Assert.AreEqual(expected, actual);

        //    Line line03 = new Line(new Point(10, -10, 10), new Point(10, 10, 10));
        //    actual = line01.Intersect2(line03);
        //    Assert.IsNull(actual);
        //    actual = line03.Intersect2(line01);
        //    Assert.IsNull(actual);

        //    Line line04 = new Line(new Point(10, 10, 10), new Point(20, 20, 20));
        //    actual = line01.Intersect2(line04);
        //    Assert.IsNull(actual);
        //    actual = line04.Intersect2(line01);
        //    Assert.IsNull(actual);

        //    Line line10 = new Line(new Point(1, 1, 1), new Point(-1, -1, -1));
        //    Line line11 = new Line(new Point(0, 1, 1), new Point(0, -1, -1));

        //    // line01 and line10 are colinear
        //    actual = line01.Intersect2(line10);
        //    Assert.IsNull(actual);
        //    actual = line10.Intersect2(line01);
        //    Assert.IsNull(actual);

        //    actual = line10.Intersect2(line11);
        //    Assert.IsNotNull(actual);
        //    Assert.AreEqual(expected, actual);
        //    actual = line11.Intersect2(line10);
        //    Assert.IsNotNull(actual);
        //    Assert.AreEqual(expected, actual);

        //    actual = line01.Intersect2(line11);
        //    Assert.IsNotNull(actual);
        //    Assert.AreEqual(expected, actual);
        //    actual = line11.Intersect2(line01);
        //    Assert.IsNotNull(actual);
        //    Assert.AreEqual(expected, actual);

        //    Line line05 = new Line(new Point(0, 0, 1), new Point(0, 0, 10));
        //    actual = line01.Intersect2(line05);
        //    Assert.IsNull(actual);
        //    actual = line05.Intersect2(line01);
        //    Assert.IsNull(actual);

        //    Line line06 = new Line(new Point(0, 0, 10), new Point(0, 0, 1));
        //    actual = line01.Intersect2(line06);
        //    Assert.IsNull(actual);
        //    actual = line06.Intersect2(line01);

        //    actual = line10.Intersect2(line05);
        //    Assert.IsNull(actual);
        //    actual = line05.Intersect2(line10);
        //    Assert.IsNull(actual);

        //    actual = line10.Intersect2(line06);
        //    Assert.IsNull(actual);
        //    actual = line06.Intersect2(line10);
        //    Assert.IsNull(actual);

        //    List<Line> Diagnals= new List<Line>();
        //    int idx1 = 0;
        //    int idx2 = 0;
        //    //Diagnals on 3 dimensions
        //    Diagnals.Add(new Line(new Point(-1, -1, -1), new Point(1, 1, 1)));
        //    Diagnals.Add(new Line(new Point(-1, -1, 1), new Point(1, 1, -1)));
        //    Diagnals.Add(new Line(new Point(-1, 1, -1), new Point(1, -1, 1)));
        //    Diagnals.Add(new Line(new Point(-1, 1, 1), new Point(1, -1, -1)));
        //    Diagnals.Add(new Line(new Point(1, -1, -1), new Point(-1, 1, 1)));
        //    Diagnals.Add(new Line(new Point(1, -1, 1), new Point(-1, 1, -1)));
        //    Diagnals.Add(new Line(new Point(1, 1, -1), new Point(-1, -1, 1)));
        //    Diagnals.Add(new Line(new Point(1, 1, 1), new Point(-1, -1, -1)));
        //    // Diagonals on 2 dimensions
        //    Diagnals.Add(new Line(new Point(-1, -1, 0), new Point(1, 1, 0)));
        //    Diagnals.Add(new Line(new Point(-1, 1, 0), new Point(1, -1, 0)));
        //    Diagnals.Add(new Line(new Point(1, -1, 0), new Point(-1, 1, 0)));
        //    Diagnals.Add(new Line(new Point(1, 1, 0), new Point(-1, -1, 0)));
        //    Diagnals.Add(new Line(new Point(-1, 0, -1), new Point(1, 0, 1)));
        //    Diagnals.Add(new Line(new Point(-1, 0, 1), new Point(1, 0, -1)));
        //    Diagnals.Add(new Line(new Point(1, 0, -1), new Point(-1, 0, 1)));
        //    Diagnals.Add(new Line(new Point(1, 0, 1), new Point(-1, 0, -1)));
        //    Diagnals.Add(new Line(new Point(0, -1, -1), new Point(0, 1, 1)));
        //    Diagnals.Add(new Line(new Point(0, -1, 1), new Point(0, 1, -1)));
        //    Diagnals.Add(new Line(new Point(0, 1, -1), new Point(0, -1, 1)));
        //    Diagnals.Add(new Line(new Point(0, 1, 1), new Point(0, -1, -1)));
        //    // Diagonals on 1 dimension
        //    Diagnals.Add(new Line(new Point(1, 0, 0), new Point(-1, 0, 0)));
        //    Diagnals.Add(new Line(new Point(0, 1, 0), new Point(0, -1, 0)));
        //    Diagnals.Add(new Line(new Point(0, 0, 1), new Point(0, 0, -1)));
        //    Diagnals.Add(new Line(new Point(-1, 0, 0), new Point(1, 0, 0)));
        //    Diagnals.Add(new Line(new Point(0, -1, 0), new Point(0, 1, 0)));
        //    Diagnals.Add(new Line(new Point(0, 0, -1), new Point(0, 0, 1)));

        //    for (idx1 = 0; idx1 < Diagnals.Count; idx1++)
        //    {
        //        for (idx2 = 0; idx2 < Diagnals.Count; idx2++)
        //        {
        //            if (idx1 != idx2)
        //            {
        //                actual = Diagnals[idx1].Intersect2(Diagnals[idx2]);
        //                if (Diagnals[idx1].AreCollinear(Diagnals[idx2]))
        //                {
        //                    if (actual != null)
        //                    {
        //                        System.Diagnostics.Debugger.Break();
        //                    }
        //                    Assert.IsNull(actual);
        //                }
        //                else
        //                {
        //                    if (actual == null)
        //                    {
        //                        System.Diagnostics.Debugger.Break();
        //                    }
        //                    Assert.IsNotNull(actual);
        //                    Assert.AreEqual(expected, actual);
        //                }
        //            }
        //        }
        //    }

        //    List<Line> Rays = new List<Line>();
        //    idx1 = 0;
        //    idx2 = 0;
        //    Rays.Add(new Line(new Point(-2, -2, -2), new Point(-4, -4, -4)));
        //    Rays.Add(new Line(new Point(-2, -2, 2), new Point(-4, -4, 4)));
        //    Rays.Add(new Line(new Point(-2, 2, -2), new Point(-4, 4, -4)));
        //    Rays.Add(new Line(new Point(-2, 2, 2), new Point(-4, 4, 4)));
        //    Rays.Add(new Line(new Point(2, -2, -2), new Point(4, -4, -4)));
        //    Rays.Add(new Line(new Point(2, -2, 2), new Point(4, -4, 4)));
        //    Rays.Add(new Line(new Point(2, 2, -2), new Point(4, 4, -4)));
        //    Rays.Add(new Line(new Point(2, 2, 2), new Point(4, 4, 4)));

        //    Rays.Add(new Line(new Point(-2, -2, 0), new Point(-4, -4, 0)));
        //    Rays.Add(new Line(new Point(-2, 2, 0), new Point(-4, 4, 0)));
        //    Rays.Add(new Line(new Point(2, -2, 0), new Point(4, -4, 0)));
        //    Rays.Add(new Line(new Point(2, 2, 0), new Point(4, 4, 0)));
        //    Rays.Add(new Line(new Point(-2, 0, -2), new Point(-4, 0, -4)));
        //    Rays.Add(new Line(new Point(-2, 0, 2), new Point(-4, 0, 4)));
        //    Rays.Add(new Line(new Point(2, 0, -2), new Point(4, 0, -4)));
        //    Rays.Add(new Line(new Point(2, 0, 2), new Point(4, 0, 4)));
        //    Rays.Add(new Line(new Point(0, -2, -2), new Point(0, -4, -4)));
        //    Rays.Add(new Line(new Point(0, -2, 2), new Point(0, -4, 4)));
        //    Rays.Add(new Line(new Point(0, 2, -2), new Point(0, 4, -4)));
        //    Rays.Add(new Line(new Point(0, 2, 2), new Point(0, 4, 4)));

        //    Rays.Add(new Line(new Point(-2, 0, 0), new Point(-4, 0, 0)));
        //    Rays.Add(new Line(new Point(0, -2, 0), new Point(0, -4, 0)));
        //    Rays.Add(new Line(new Point(0, 0, -2), new Point(0, 0, -4)));
        //    Rays.Add(new Line(new Point(2, 0, 0), new Point(4, 0, 0)));
        //    Rays.Add(new Line(new Point(0, 2, 0), new Point(0, 4, 0)));
        //    Rays.Add(new Line(new Point(0, 0, 2), new Point(0, 0, 4)));

        //    int cntRays = Rays.Count;
        //    for (idx2 = 0; idx2 < cntRays; idx2++)
        //    {
        //        Rays.Add(Rays[idx2].Reverse());
        //    }

        //    for (idx1 = 0; idx1 < Rays.Count; idx1++)
        //    {
        //        for (idx2 = 0; idx2 < Rays.Count; idx2++)
        //        {
        //            if (idx1 != idx2)
        //            {
        //                actual = Rays[idx1].Intersect2(Rays[idx2]);
        //                if (actual != null)
        //                {
        //                    System.Diagnostics.Debugger.Break();
        //                }
        //                Assert.IsNull(actual);
        //            }
        //        }
        //    }

        //    for (idx1 = 0; idx1 < Diagnals.Count; idx1++)
        //    {
        //        for (idx2 = 0; idx2 < cntRays; idx2++)
        //        {
        //            actual = Diagnals[idx1].Intersect2(Rays[idx2]);
        //            if (actual != null)
        //            {
        //                System.Diagnostics.Debugger.Break();
        //            }
        //            Assert.IsNull(actual);

        //            actual = Rays[idx2].Intersect(Diagnals[idx1]);
        //            if (actual != null)
        //            {
        //                System.Diagnostics.Debugger.Break();
        //            }
        //            Assert.IsNull(actual);
        //        }
        //    }
        //}

        [TestMethod()]
        public void AreCollinearTest()
        {
            Line line01 = new Line(new Point(-1, -1, -1), new Point(1, 1, 1));
            Line line02 = new Line(new Point(2, 2, 2), new Point(4, 4, 4));
            Line line03 = new Line(new Point(0, 0, 0), new Point(2, 4, 8));
            Line line04 = new Line(new Point(2, 4, 8), new Point(3, 6, 12));
            Line line10 = new Line(new Point(1, 1, 1), new Point(-1, -1, -1));

            Assert.IsTrue(line01.AreCollinear(line01));

            Assert.IsTrue(line01.AreCollinear(line10));
            Assert.IsTrue(line10.AreCollinear(line01));

            Assert.IsTrue(line01.AreCollinear(line02));
            Assert.IsTrue(line02.AreCollinear(line01));

            Assert.IsTrue(line03.AreCollinear(line04));
            Assert.IsTrue(line04.AreCollinear(line03));

            Assert.IsFalse(line01.AreCollinear(line03));
            Assert.IsFalse(line03.AreCollinear(line01));
        }
    }
}