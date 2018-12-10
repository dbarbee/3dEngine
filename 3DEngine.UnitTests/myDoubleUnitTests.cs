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
    public class myDoubleUnitTests
    {
            myDouble x1 = new myDouble(1.0);
            myDouble x2 = new myDouble(2.0);

            myDouble y1 = new myDouble(1.0);
            myDouble y2 = new myDouble(2.0);

            myDouble n1 = null;
            myDouble n2 = null;

            myDouble x1a = new myDouble(1.0 - myDouble.Epsilon);
            myDouble x1b = new myDouble(1.0 + myDouble.Epsilon);
            myDouble x1c = new myDouble(1.0 - myDouble.Epsilon/2);
            myDouble x1d = new myDouble(1.0 + myDouble.Epsilon/2);
            myDouble x1e = new myDouble(1.0 - 2*myDouble.Epsilon);
            myDouble x1f = new myDouble(1.0 + 2*myDouble.Epsilon);

        myDouble xn1 = new myDouble(-1.0);
        myDouble xn2 = new myDouble(-2.0);

        [TestMethod()]
        public void myDoubleTest()
        {
            myDouble expected = 1;

            myDouble actual = new myDouble(1.0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Assert.IsTrue(x1.Equals(x1));
            Assert.IsTrue(x2.Equals(x2));
            Assert.IsTrue(x1.Equals(y1));
            Assert.IsTrue(x2.Equals(y2));
            Assert.IsTrue(y1.Equals(x1));
            Assert.IsTrue(y2.Equals(x2));

            Assert.IsFalse(x1.Equals(y2));
            Assert.IsFalse(x2.Equals(y1));
            Assert.IsFalse(y1.Equals(x2));
            Assert.IsFalse(y2.Equals(x1));

            Assert.IsFalse(x1.Equals(n1));
            Assert.IsFalse(y2.Equals(n2));

            //Assert.IsFalse(x1.Equals(x1a));
            //Assert.IsFalse(x1.Equals(x1b));
            Assert.IsTrue(x1.Equals(x1c));
            Assert.IsTrue(x1.Equals(x1d));
            Assert.IsFalse(x1.Equals(x1e));
            Assert.IsFalse(x1.Equals(x1f));
        }

        [TestMethod()]
        public void MathOperatersTest()
        {
            Assert.AreEqual(x1 + y1, x2);
            Assert.AreEqual(x2 - y1, x1);
            Assert.AreEqual(y2 * y1, y2);
            Assert.AreEqual(y2 / x1, y2);
            Assert.AreEqual(y2 / x2, x1);
        }

        [TestMethod()]
        public void EqualityOperatersTest()
        {
            Assert.IsTrue(x1 == y1);
            Assert.IsTrue(x1 != y2);
            Assert.IsTrue(x1 < y2);
            Assert.IsTrue(x2 > y1);
            Assert.IsTrue(x1 <= y2);
            Assert.IsTrue(x2 >= y1);
            Assert.IsTrue(x1 <= y1);
            Assert.IsTrue(x2 >= y2);

            Assert.IsFalse(x1 == y2);
            Assert.IsFalse(x1 != y1);
            Assert.IsFalse(x1 < y1);
            Assert.IsFalse(x2 > y2);
            Assert.IsFalse(x2 <= y1);
            Assert.IsFalse(x1 >= y2);

            Assert.IsTrue(x1 != x1e);
            Assert.IsTrue(x1 == x1d);
            Assert.IsFalse(x1 == x1e);
            Assert.IsFalse(x1 != x1d);
            Assert.IsTrue(x1 > x1e);
            Assert.IsFalse(x1 > x1d);
            Assert.IsTrue(x1 < x1f);
            Assert.IsFalse(x1 < x1c);
        }
        //[TestMethod()]
        //public void GetHashCodeTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ToStringTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void EqZeroTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void NeqZeroTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void LimitTest()
        {
            myDouble limit1 = new myDouble(2, 1);
            Assert.IsTrue(limit1.Equals(x1));

            myDouble limitn1 = new myDouble(-2, 1);
            Assert.IsTrue(limitn1.Equals(xn1));

            myDouble limit11 = new myDouble(2, 1,-1);
            Assert.IsTrue(limit1.Equals(x1));

            myDouble limitn11 = new myDouble(-2, 1,-1);
            Assert.IsTrue(limitn1.Equals(xn1));

            myDouble limit1a = new myDouble(2);
            limit1a.UpperLimit = 1;
            Assert.IsTrue(limit1a.Equals(x1));

            myDouble limitn1a = new myDouble(-2);
            limitn1a.LowerLimit = -1;
            Assert.IsTrue(limitn1a.Equals(xn1));
        }
    }
}