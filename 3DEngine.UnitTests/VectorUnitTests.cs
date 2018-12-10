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
    public class VectorUnitTests
    {
        [TestMethod()]
        public void NormalizeTest()
        {
            Vector v = new Vector(2, 4, 6);
            Vector expected = new Vector(1, 2, 3);
            Vector actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(4, 2, 6);
            expected = new Vector(2, 1, 3);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(4, 6, 2);
            expected = new Vector(2, 3, 1);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(0, 0, 0);
            expected = new Vector(0, 0, 0);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(0, 2, 6);
            expected = new Vector(0, 1, 3);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(2, 0, 6);
            expected = new Vector(1, 0, 3);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(2, 6, 0);
            expected = new Vector(1, 3, 0);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(2, 0, 0);
            expected = new Vector(1, 0, 0);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(0, 2, 0);
            expected = new Vector(0, 1, 0);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(0, 0, 2);
            expected = new Vector(0, 0, 1);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(-2, 4, 6);
            expected = new Vector(-1, 2, 3);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(-4, 2, 6);
            expected = new Vector(-2, 1, 3);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(4, -6, 2);
            expected = new Vector(2, -3, 1);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(-2, -4, -6);
            expected = new Vector(-1, -2, -3);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(-4, -2, -6);
            expected = new Vector(-2, -1, -3);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);

            v = new Vector(-4, -6, -2);
            expected = new Vector(-2, -3, -1);
            actual = v.Normalize();
            Assert.AreEqual(expected, actual);
        }
    }
}