using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch2 // Chapter number
    {
        public static class Ex1 // Exercise number
        {
            /* Exercise 2.1
             * 
             * Remove Dups: Write code to remove duplicates from an unsorted linked list.
             * 
             * FOLLOW UP
             * 
             * How would you solve this problem if a temporary buffer is not allowed?
             */

            // Part 1
            // Assumes each node contains int data.
            // O(n) runtime, O(n) space
            public static void RemoveDuplicates(LinkedList.Node head)
            {
                if (head == null) { throw new System.ArgumentNullException("head"); }
                var dupList = new List<int> { head.data };
                var node = head;
                while (node.Next != null)
                {
                    if (dupList.Contains(node.Next.data)) { node.DeleteNext(); }
                    else
                    {
                        node = node.Next;
                        dupList.Add(node.data);
                    }
                }
            }

            // Part 2
            // Assumes each node contains int data.
            // O(n^2) runtime, O(1) space
            public static void RemoveDuplicates_NoBuffer(LinkedList.Node head)
            {
                if (head == null) { throw new System.ArgumentNullException("head"); }
                var node = head;
                while (node.Next != null)
                {
                    var runner = node;
                    while (runner.Next != null)
                    {
                        if (node.data == runner.Next.data) { runner.DeleteNext(); }
                        else { runner = runner.Next; }
                    }
                    node = node.Next;
                }
            }
        }
    }
}
