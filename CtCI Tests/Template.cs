using System;
using CtCI_Solutions.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CtCI_Tests
{
    public partial class Chapter1Tests // Chapter number
    {
        [TestClass]
        public class Ex1Tests // Exercise number
        {
            [TestMethod]
            public void Method1EmptyString()
            {
                var testString = "";
                const bool expectedResult = true;
                var actualResult = ContainsUniqueChars(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
