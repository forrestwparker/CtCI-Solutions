using System;
using CtCI_Solutions.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CtCI_Tests
{
    public partial class Chapter1Tests // Chapter number
    {
        [TestClass]
        public class Ex2Tests // Exercise number
        {
            [TestMethod]
            public void FirstStringNull()
            {
                var str = "askgjhlk";
                var isNullString = false;
                try { Ch1.Ex2.ArePermutations(null, str); }
                catch { isNullString = true; }
                const bool expectedResult = true;
                Assert.AreEqual(expectedResult, isNullString);
            }

            [TestMethod]
            public void SecondStringNull()
            {
                var str = "asjdkglahsd";
                var isNullString = false;
                try { Ch1.Ex2.ArePermutations(str, null); }
                catch { isNullString = true; }
                const bool expectedResult = true;
                Assert.AreEqual(expectedResult, isNullString);
            }

            [TestMethod]
            public void EmptyStrings()
            {
                var str = "";
                const bool expectedResult = true;
                var actualResult = Ch1.Ex2.ArePermutations(str, str);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void FirstStringEmpty()
            {
                var str1 = "";
                var str2 = "asdf";
                const bool expectedResult = false;
                var actualResult = Ch1.Ex2.ArePermutations(str1, str2);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void SecondStringEmpty()
            {
                var str1 = "asdf";
                var str2 = "";
                const bool expectedResult = false;
                var actualResult = Ch1.Ex2.ArePermutations(str1, str2);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void ShortAndLongStrings()
            {
                var str1 = "AHGJDjhkajsh4eugib8427regnasd";
                var str2 = "asdf";
                const bool expectedResult = false;
                var actualResult = Ch1.Ex2.ArePermutations(str1, str2);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void NotPermutations()
            {
                var str1 = "Taco Cat";
                var str2 = "TaCo Cat";
                const bool expectedResult = false;
                var actualResult = Ch1.Ex2.ArePermutations(str1, str2);
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void ArePermutations()
            {
                var str1 = "Taco Cat";
                var str2 = "Cat Taco";
                const bool expectedResult = true;
                var actualResult = Ch1.Ex2.ArePermutations(str1, str2);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
