using System;
using CtCI_Solutions.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CtCI_Tests
{
    public partial class Chapter16Tests // Chapter number
    {
        [TestClass]
        public class Ex1Tests // Exercise number
        {
            [TestMethod]
            public void SwapSimpleTest()
            {
                var ns = new Ch16.Ex1.NumberSwapper()
                {
                    a = 10,
                    b = 100
                };
                ns.Swap();
                Assert.AreEqual(100, ns.a);
                Assert.AreEqual(10, ns.b);
            }

            [TestMethod]
            public void SwapExtremeTestA()
            {
                var ns = new Ch16.Ex1.NumberSwapper()
                {
                    a = int.MaxValue,
                    b = int.MinValue
                };
                ns.Swap();
                Assert.AreEqual(int.MinValue, ns.a);
                Assert.AreEqual(int.MaxValue, ns.b);
            }

            [TestMethod]
            public void SwapExtremeTestB()
            {
                var ns = new Ch16.Ex1.NumberSwapper()
                {
                    a = int.MinValue,
                    b = int.MaxValue
                };
                ns.Swap();
                Assert.AreEqual(int.MaxValue, ns.a);
                Assert.AreEqual(int.MinValue, ns.b);
            }
        }
    }
}
