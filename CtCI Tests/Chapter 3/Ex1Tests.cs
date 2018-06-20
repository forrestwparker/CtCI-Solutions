using System;
using CtCI_Solutions.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CtCI_Tests
{
    public partial class Chapter3Tests // Chapter number
    {
        [TestClass]
        public class Ex1Tests // Exercise number
        {
            // test stack counts
            // test independent stack pops
            // test pop of empty array
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
