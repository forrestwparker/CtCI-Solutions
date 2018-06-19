using System;
using CtCI_Solutions.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CtCI_Tests
{
    public partial class Chapter1Tests // Chapter number
    {
        [TestClass]
        public class Ex4Tests // Exercise number
        {
            [TestMethod]
            public void EmptyString()
            {
                var testString = "";
                const bool expectedResult = true;
                var actualResult = Ch1.Ex4.IsPalindromePermutation(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void OnlySpaces()
            {
                var testString = "     ";
                const bool expectedResult = true;
                var actualResult = Ch1.Ex4.IsPalindromePermutation(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void NotPalindromePermutation()
            {
                var testString = "Aclo Tact";
                const bool expectedResult = false;
                var actualResult = Ch1.Ex4.IsPalindromePermutation(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void IsPalindromePermutation()
            {
                var testString = "Aco Tact";
                const bool expectedResult = true;
                var actualResult = Ch1.Ex4.IsPalindromePermutation(testString);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
