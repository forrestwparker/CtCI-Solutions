using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch3 // Chapter Number
    {
        public static class Ex4 // Exercise number
        {
            /* Exercise 3.4
             * 
             * Queue via Stacks: Implement a 'MyQueue' class which implements a queue using two stacks.
             */

            public class MyQueue<T>
            {
                private Stack<T> BackOfQueue = new Stack<T>();
                private Stack<T> FrontOfQueue = new Stack<T>();

                public void Enqueue(T element)
                {
                    BackOfQueue.Push(element);
                }

                public T Dequeue()
                {
                    if (FrontOfQueue.Count == 0)
                    {
                        if (BackOfQueue.Count == 0) { } // Throw error
                        MoveBackToFront()
                    }
                    return FrontOfQueue.Pop();
                }

                public T Peek()
                {
                    if (FrontOfQueue.Count == 0)
                    {
                        if (BackOfQueue.Count == 0) { } // Throw error
                        MoveBackToFront();
                    }
                    return FrontOfQueue.Peek();
                }

                private void MoveBackToFront()
                {
                    while (BackOfQueue.Count > 0) { FrontOfQueue.Push(BackOfQueue.Pop()); }
                }
            }
        }
    }
}
