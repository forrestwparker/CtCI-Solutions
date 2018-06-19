﻿using System;
using static CtCI_Solutions.Solutions.Ch1.Ex1; // Chapter number, Exercise Number
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CtCI_Tests
{
    [TestClass]
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
