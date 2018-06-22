using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch2 // Chapter Number
    {
        public static class Ex7 // Exercise number
        {
            /* Exercise 2.7
             * 
             * Intersection: Given two (singly) linked lists, determine if the two lists intersect.
             * Return the intersecting node.
             * Note that the intersection is defined based on the reference, not value.
             * That is, if the kth node of the first linked list is the exact same node (by reference)
             * as the jth node of the second linked list, then they are intersecting.
             */

            // Used in FindIntersection.
            public struct NodeCount
            {
                public LinkedList.Node Node;
                public int Count;
                public LinkedList.Node TerminalNode;
            }

            // O(|head1|+|head2|) runtime, O(1) space
            public static LinkedList.Node FindIntersection(LinkedList.Node head1, LinkedList.Node head2)
            {
                // If either head node is null, throw exception.
                if (head1 == null) { throw new System.ArgumentNullException("head1"); }
                if (head2 == null) { throw new System.ArgumentNullException("head2"); }

                // Create array of NodeCounts to organize data.
                var ncArray = new NodeCount[2]
                {
                    new NodeCount() { Node = head1 },
                    new NodeCount() { Node = head2 }
                };

                // Calculate the length and terminating node of each list.
                for (int i = 0; i < ncArray.Length; i++)
                {
                    ncArray[i].TerminalNode = ncArray[i].Node;
                    while (ncArray[i].TerminalNode.Next != null)
                    {
                        ncArray[i].Count++;
                        ncArray[i].TerminalNode = ncArray[i].TerminalNode.Next;
                    }
                }

                // If the terminating nodes of the lists are not the same node, they do not intersect.
                if (!ncArray[0].TerminalNode.Equals(ncArray[0].TerminalNode)) { return null; }

                // Sort ncArray by length of each list.
                ncArray = ncArray.OrderBy(x => x.Count).ToArray<NodeCount>();

                // Trim the start of the longer list until they are the same length.
                while (ncArray[1].Count > ncArray[0].Count)
                {
                    ncArray[1].Node = ncArray[1].Node.Next;
                    ncArray[1].Count--;
                }

                // Check node-by-node until the intersecting node is found.
                while (ncArray[0].Node.Equals(ncArray[1].Node))
                {
                    ncArray[0].Node = ncArray[0].Node.Next;
                    ncArray[1].Node = ncArray[1].Node.Next;
                }
                return ncArray[0].Node;
            }
        }
    }
}
