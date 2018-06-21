using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch2 // Chapter Number
    {
        public static class Ex4 // Exercise number
        {
            /* Exercise 2.4
             * 
             * Partition: Write code to partition a linked list around a value x,
             * such that all nodes less than x come before all nodes greater than x.
             * If x is contained within the list, the values of x only need to be after
             * the elements less than x (see below).
             * The partition element x can appear anywhere in the "right partition;"
             * it does not need to appear between the left and right partitions.
             */
             
            // Create a new linked list with head node newHead and tail node newTail.
            // O(n) runtime, O(1) space
            public static LinkedList.Node PartitionAround(LinkedList.Node head, int value)
            {
                if (head == null) { throw new System.ArgumentNullException("head"); }
                var newHead = head;
                var newTail = head;
                var currentNode = head.Next;
                head.Next = null;
                while (currentNode != null)
                {
                    var nextNode = currentNode.Next;
                    if (currentNode.data < value)
                    {
                        currentNode.Next = newHead;
                        newHead = currentNode;
                    }
                    else
                    {
                        currentNode.Next = null;
                        newTail.Next = currentNode;
                        newTail = currentNode;
                    }
                    currentNode = nextNode;
                }
                return newHead;
            }
        }
    }
}
