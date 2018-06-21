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

            // Assuming this stack will be used exclusively for int values.
            // MyStack.Pop will throw an error if the stack is empty.
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
                // Throw an exception if the stack is empty.
                public int Pop()
                {
                    int topOfStack;
                    try { topOfStack = Stack.Pop(); }
                    catch (Exception ex) { throw; }
                    if (topOfStack == MinStack.Peek()) { MinStack.Pop(); }
                    return topOfStack;
                }

                // The top element of MinStack is always the minimum value of Stack.
                // Throw an exception if the stack is empty.
                public int Min()
                {
                    if (MinStack.Count == 0)
                    {
                        throw new System.InvalidOperationException("Empty stack has no min value.");
                    }
                    return MinStack.Peek();
                }
            }
        }
    }
}
