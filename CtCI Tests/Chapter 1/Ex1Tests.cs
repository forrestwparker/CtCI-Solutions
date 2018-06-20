using System;
using CtCI_Solutions.Solutions;
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
            public void Method1NullString()
            {
                string testString = null;
                const bool expectedResult = true;
                var actualResult = Ch1.Ex1.ContainsUniqueChars(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method1EmptyString()
            {
                var testString = "";
                const bool expectedResult = true;
                var actualResult = Ch1.Ex1.ContainsUniqueChars(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method1LongString()
            {
                var testString = new String('A', 100000);
                const bool expectedResult = false;
                var actualResult = Ch1.Ex1.ContainsUniqueChars(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method1GoodString()
            {
                var testString = "ASDFGHJKLQWERTYUIOPZXCVBNMasdfghjklqwertyuiopzxcvbnm\\<>?,./;':\"{}|1234567890!@#$%^&*()-=_+`~ \n";
                const bool expectedResult = true;
                var actualResult = Ch1.Ex1.ContainsUniqueChars(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method1BadString()
            {
                var testString = "asdfghjklqwertyuiopzxcvbnmASDFGHJKLQ WERTYUIOPZXCVBNMu";
                const bool expectedResult = false;
                var actualResult = Ch1.Ex1.ContainsUniqueChars(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method2NullString()
            {
                string testString = null;
                const bool expectedResult = true;
                var actualResult = Ch1.Ex1.ContainsUniqueChars_NoExtraDataStructures(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method2EmptyString()
            {
                var testString = "";
                const bool expectedResult = true;
                var actualResult = Ch1.Ex1.ContainsUniqueChars_NoExtraDataStructures(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method2LongString()
            {
                var testString = new String('A', 100000);
                const bool expectedResult = false;
                var actualResult = Ch1.Ex1.ContainsUniqueChars_NoExtraDataStructures(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method2GoodString()
            {
                var testString = "ASDFGHJKLQWERTYUIOPZXCVBNMasdfghjklqwertyuiopzxcvbnm\\<>?,./;':\"{}|1234567890!@#$%^&*()-=_+`~ \n";
                const bool expectedResult = true;
                var actualResult = Ch1.Ex1.ContainsUniqueChars_NoExtraDataStructures(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void Method2BadString()
            {
                var testString = "asdfghjklqwertyuiopzxcvbnmASDFGHJKLQ WERTYUIOPZXCVBNMu";
                const bool expectedResult = false;
                var actualResult = Ch1.Ex1.ContainsUniqueChars_NoExtraDataStructures(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
