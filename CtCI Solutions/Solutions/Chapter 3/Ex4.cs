﻿using System;
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
                // BackOfQueue receives all queueing elements (at the back of the queue).
                // FrontOfQueue holds elements ready to be dequeued (at the front of the queue).
                // O(1) runtime
                private Stack<T> BackOfQueue = new Stack<T>();
                private Stack<T> FrontOfQueue = new Stack<T>();

                public void Enqueue(T element)
                {
                    BackOfQueue.Push(element);
                }

                // When FrontOfQueue is empty, move all elementes from BackOfQueue onto FrontOfQueue.
                // O(n) worst-case runtime (where n is the number of elements in the queue)
                public T Dequeue()
                {
                    if (FrontOfQueue.Count == 0)
                    {
                        if (BackOfQueue.Count == 0) { throw new System.InvalidOperationException("Cannot dequeue from an empty queue."); }
                        MoveBackToFront();
                    }
                    return FrontOfQueue.Pop();
                }

                // When FrontOfQueue is empty, move all elementes from BackOfQueue onto FrontOfQueue.
                // O(n) worst-case runtime (where n is the number of elements in the queue)
                public T Peek()
                {
                    if (FrontOfQueue.Count == 0)
                    {
                        if (BackOfQueue.Count == 0) { throw new System.InvalidOperationException("Cannot peek into an empty queue."); }
                        MoveBackToFront();
                    }
                    return FrontOfQueue.Peek();
                }

                // To move elements to FrontOfQueue, invert the BackOfQueue stack.
                // O(n) runtime (where n is the number of elements in BackOfQueue)
                private void MoveBackToFront()
                {
                    while (BackOfQueue.Count > 0) { FrontOfQueue.Push(BackOfQueue.Pop()); }
                }
            }
        }
    }
}
