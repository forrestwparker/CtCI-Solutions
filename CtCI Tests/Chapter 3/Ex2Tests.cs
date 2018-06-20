using System;
using System.Linq;
using CtCI_Solutions.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CtCI_Tests
{
    public partial class Chapter3Tests // Chapter number
    {
        [TestClass]
        public class Ex2Tests // Exercise number
        {
            [TestMethod]
            public void EmptyStackPop()
            {
                var myStack = new Ch3.Ex2.MyStack();
                bool isStackEmpty = false;
                try { myStack.Pop(); }
                catch { isStackEmpty = true; }
                const bool expectedResult = true;
                Assert.AreEqual(expectedResult, isStackEmpty);
            }

            [TestMethod]
            public void EmptyStackMin()
            {
                var myStack = new Ch3.Ex2.MyStack();
                bool isStackMinEmpty = false;
                try { myStack.Min(); }
                catch { isStackMinEmpty = true; }
                const bool expectedResult = true;
                Assert.AreEqual(expectedResult, isStackMinEmpty);
            }

            [TestMethod]
            public void MinTest()
            {
                var myStack = new Ch3.Ex2.MyStack();
                const int numberOfElements = 25;
                var intArray = PopulateMyStack(myStack, numberOfElements);
                var intArrayMin = intArray.OrderBy(x => x).First();
                Assert.AreEqual(intArrayMin, myStack.Min());
            }

            [TestMethod]
            public void ContainsMultipleMin()
            {
                var myStack = new Ch3.Ex2.MyStack();
                const int numberOfElements = 25;
                var intArray = PopulateMyStack(myStack, numberOfElements);
                var intArrayMin = intArray.OrderBy(x => x).First();
                myStack.Push(intArrayMin);
                Assert.AreEqual(intArrayMin, myStack.Min());
                myStack.Pop();
                Assert.AreEqual(intArrayMin, myStack.Min());
            }

            [TestMethod]
            public void CanEmptyStack()
            {
                var myStack = new Ch3.Ex2.MyStack();
                const int numberOfElements = 25;
                PopulateMyStack(myStack, numberOfElements);
                for (int i = 0; i < 25; i++) { myStack.Pop(); }
                bool isStackEmpty = false;
                try { myStack.Pop(); }
                catch { isStackEmpty = true; }
                const bool expectedResult = true;
                Assert.AreEqual(expectedResult, isStackEmpty);
            }

            [TestMethod]
            public void CanEmptyStackMin()
            {
                var myStack = new Ch3.Ex2.MyStack();
                const int numberOfElements = 25;
                PopulateMyStack(myStack, numberOfElements);
                for (int i = 0; i < numberOfElements; i++) { myStack.Pop(); }
                bool isStackMinEmpty = false;
                try { myStack.Min(); }
                catch { isStackMinEmpty = true; }
                const bool expectedResult = true;
                Assert.AreEqual(expectedResult, isStackMinEmpty);
            }

            private int[] PopulateMyStack(Ch3.Ex2.MyStack myStack, int amount)
            {
                if (amount <=0) { throw new System.ArgumentException("Parameter must be positive.", "amount"); }
                var intArray = new int[25];
                var rng = new Random();
                for (int i = 0; i < 25; i++)
                {
                    intArray[i] = rng.Next(0, 100);
                    myStack.Push(intArray[i]);
                }
                return intArray;
            }
        }
    }
}
