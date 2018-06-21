using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch2 // Chapter Number
    {
        public static class Ex3 // Exercise number
        {
            /* Exercise <number>
             * 
             * Delete Middle Node: Implement an algorithm to delete a node in the middle
             * (i.e., any node but the first and last node, not necessarily the exact middle)
             * of a singly linked list, given only access to that node.
             * 
             * EXAMPLE
             * 
             * Input:   the node c from the linked list a -> b -> c -> d -> e -> f
             * Result:  nothing is returned, but the new linked list looks like a -> b -> d -> e -> f
             */

            // O(1) runtime, O(1) space
            public static void DeleteMiddleNode(LinkedList.Node node)
            {
                if (node.Next == null) { throw new System.ArgumentException("Cannot delete terminal node."); }
                node.data = node.Next.data;
                node.DeleteNext();
            }
        }
    }
}
