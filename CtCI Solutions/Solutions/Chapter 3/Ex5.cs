using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch3 // Chapter Number
    {
        public static class Ex5 // Exercise number
        {
            /* Exercise 3.5
             * 
             * Sort Stack: Write a program to sort a stack such that the smallest items are on the top.
             * You can use an additional temporary stack, but you may not copy the elements into any
             * other data structure (such as an array).
             * The stack supports the following operations: 'push', 'pop', 'peek', and 'isEmpty'.
             */

            // Assume int data in the stack.
            // O(n log n) runtime, O(n) space
            public static void SortStack(Stack<int> stack)
            {
                if (stack == null) { throw new System.ArgumentNullException(); }
                var tempStack = new Stack<int>();

                // For each item in stack, insert it into tempStack at the appropriate place 
                while (stack.Count > 0)
                {
                    var currentItem = stack.Pop();

                    // Transfer items from tempStack to stack until top of tempStack is less than or equal to currentItem.
                    // Count the number of items transferred this way with transferCount.
                    var transferCount = 0;
                    while (tempStack.Count > 0 && tempStack.Peek() > currentItem)
                    {
                        stack.Push(tempStack.Pop());
                        transferCount++;
                    }

                    // Push currentItem on tempStack, then transfer the other previously moved items back on top.
                    tempStack.Push(currentItem);
                    for(; transferCount > 0; transferCount--) { tempStack.Push(stack.Pop()); }
                }
                
                // Invert tempStack back onto stack.
                while (tempStack.Count > 0) { stack.Push(tempStack.Pop()); }
            }
        }
    }
}
