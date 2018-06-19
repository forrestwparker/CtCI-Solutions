using System;
using CtCI_Solutions.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CtCI_Tests
{
    public partial class Chapter1Tests // Chapter number
    {
        [TestClass]
        public class Ex3Tests // Exercise number
        {
            [TestMethod]
            public void EmptyArray()
            {
                var testArray = new char[0];
                Ch1.Ex3.ReplaceSpaces(testArray, 0);
                Assert.AreEqual(0, testArray.Length);
            }

            [TestMethod]
            public void OnlyTwoSpaces()
            {
                var testArray = "      ".ToCharArray();
                Ch1.Ex3.ReplaceSpaces(testArray, 2);
                Assert.AreEqual("%20%20", new String(testArray));
            }

            [TestMethod]
            public void GenericString()
            {
                var testArray = "The quick brown fox jumped over the lazy dog.                ".ToCharArray();
                Ch1.Ex3.ReplaceSpaces(testArray, testArray.Length - 16);
                Assert.AreEqual("The%20quick%20brown%20fox%20jumped%20over%20the%20lazy%20dog.", new String(testArray));
            }
        }
    }
}
