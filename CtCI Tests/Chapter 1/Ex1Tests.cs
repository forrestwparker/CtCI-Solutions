using System;
using static CtCI_Solutions.Solutions.Ch1.Ex1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CtCI_Tests
{
    [TestClass]
    public partial class Chapter1Tests
    {
        [TestClass]
        public class Ex1Tests
        {
            [TestMethod]
            public void Method1EmptyString()
            {
                var testString = "";
                const bool expectedResult = true;
                var actualResult = ContainsUniqueChars(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method1LongString()
            {
                var testString = new String('A', 100000);
                const bool expectedResult = false;
                var actualResult = ContainsUniqueChars(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method1GoodString()
            {
                var testString = "ASDFGHJKLQWERTYUIOPZXCVBNMasdfghjklqwertyuiopzxcvbnm\\<>?,./;':\"{}|1234567890!@#$%^&*()-=_+`~ \n";
                const bool expectedResult = true;
                var actualResult = ContainsUniqueChars(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method1BadString()
            {
                var testString = "asdfghjklqwertyuiopzxcvbnmASDFGHJKLQ WERTYUIOPZXCVBNMu";
                const bool expectedResult = false;
                var actualResult = ContainsUniqueChars(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method2EmptyString()
            {
                var testString = "";
                const bool expectedResult = true;
                var actualResult = ContainsUniqueChars_NoExtraDataStructures(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method2LongString()
            {
                var testString = new String('A', 100000);
                const bool expectedResult = false;
                var actualResult = ContainsUniqueChars_NoExtraDataStructures(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method2GoodString()
            {
                var testString = "ASDFGHJKLQWERTYUIOPZXCVBNMasdfghjklqwertyuiopzxcvbnm\\<>?,./;':\"{}|1234567890!@#$%^&*()-=_+`~ \n";
                const bool expectedResult = true;
                var actualResult = ContainsUniqueChars_NoExtraDataStructures(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method2BadString()
            {
                var testString = "asdfghjklqwertyuiopzxcvbnmASDFGHJKLQ WERTYUIOPZXCVBNMu";
                const bool expectedResult = false;
                var actualResult = ContainsUniqueChars_NoExtraDataStructures(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
