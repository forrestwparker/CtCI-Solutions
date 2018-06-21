using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch2 // Chapter Number
    {
        public static class Ex2 // Exercise number
        {
            /* Exercise 2.2
             * 
             * Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list.
             */

            // Assumes last node is "0th to last."
            // O(n) runtime, O(1) space
            public static LinkedList.Node KToLast(LinkedList.Node head, int K)
            {
                if (head == null) { throw new System.ArgumentNullException("head"); }
                var node = head;
                for (int i = 0; i < K; i++)
                {
                    if (node.Next == null)
                    {
                        throw new System.InvalidOperationException(
                            String.Format("LinkedList does not contain at least {0} nodes", K + 1)
                        );
                    }
                    node = node.Next;
                }
                var backNode = head;
                while (node.Next != null)
                {
                    backNode = backNode.Next;
                    node = node.Next;
                }
                return backNode;
            }
        }
    }
}
