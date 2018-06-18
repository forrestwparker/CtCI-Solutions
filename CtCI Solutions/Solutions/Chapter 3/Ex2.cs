using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch3 // Chapter Number
    {
        public static class Ex2 // Exercise number
        {
            /* Exercise 3.2
             * 
             * Stack Min: How would you design a stack which, in addition to 'push' and 'pop',
             * has a function 'min' which returns the minimum element?
             * 'Push', 'pop', and 'min' should all operate in O(1) time.
             */

            // Assuming this stack can be used exclusively for int values.
            // MyStack.Pop will throw an error if empty.
            public class MyStack
            {
                // Stack holds the stack.
                // MinStack holds copies of the minimum elements in Stack (by order of appearance).
                private Stack<int> Stack = new Stack<int>();
                private Stack<int> MinStack = new Stack<int>();

                // value is pushed on MinStack if it is less than or equal to the current minimum of Stack.
                public void Push(int value)
                {
                    if (MinStack.Count == 0 || value <= MinStack.Peek()) { MinStack.Push(value); }
                    Stack.Push(value);
                }

                // The top of MinStack is popped off if it is equal to the value popped off of Stack
                // (i.e., when the minimum value of Stack is being removed).
                public int Pop()
                {
                    if (Stack.Count == 0) { } // Throw error
                    var topOfStack = Stack.Pop();
                    if (topOfStack == MinStack.Peek()) { MinStack.Pop(); }
                    return topOfStack;
                }

                // The top element of MinStack is always the minimum value of Stack.
                public int Min()
                {
                    if (MinStack.Count == 0) { } // Throw error
                    return MinStack.Peek();
                }
            }
        }
    }
}
