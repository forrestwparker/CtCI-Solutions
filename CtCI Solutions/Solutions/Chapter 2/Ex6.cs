using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch2 // Chapter Number
    {
        public static class Ex6 // Exercise number
        {
            /* Exercise 2.6
             * 
             * Palindrome: Implement a function to check if a linked list is a palindrome.
             */

            // Verion 1
            // O(n) runtime, O(n) space
            public static bool IsPalindrome(LinkedList.Node head)
            {
                if (head == null) { throw new System.ArgumentNullException("head"); }

                // If head is the only node, the linked list is a palindrome.
                if (head.Next == null) { return true; }

                // Move through the linked list with walker and runner.
                // walker moves at one node per cycle, runner at two per cycle.
                // Each time runner can take a second step in a cycle (i.e. an even number of nodes), push walker to stack.
                var walker = head;
                var runner = head.Next;
                var stack = new Stack<LinkedList.Node>();
                stack.Push(walker);
                while (runner.Next != null)
                {
                    runner = runner.Next;
                    walker = walker.Next;
                    if (runner.Next != null)
                    {
                        runner = runner.Next;
                        stack.Push(walker);
                    }
                }

                // walker.Next is the first node in the second half of the linked list.
                // If the linked list has odd length, walker is on the median node (by index, not value).
                // Increment walker through list, compare data to popped data from stack.
                do
                {
                    walker = walker.Next;
                    if (walker.data != stack.Pop().data) { return false; }
                } while (walker.Next != null);
                return true;
            }

            // Version 2
            // O(n^2) runtime, O(1) space
            public static bool IsPalindrome_NoBuffer(LinkedList.Node head)
            {
                if (head == null) { throw new System.ArgumentNullException("head"); }

                // If head is the only node, the linked list is a palindrome.
                if (head.Next == null) { return true; }
                
                // Move through the linked list with walker and runner beginning on the 2nd node.
                // Each time runner steps to an odd indexed node, walker takes a step.
                // Each time runner steps to an even indexed node, count is incremented.
                var count = 0;
                var walker = head.Next;
                var runner = head.Next;
                while (runner.Next != null)
                {
                    runner = runner.Next;
                    walker = walker.Next;
                    if (runner.Next != null)
                    {
                        count++;
                        runner = runner.Next;
                    }
                }
                
                // walker is on the first node in the second half of the linked list.
                // If the linked list has odd length, walker is at the node after the median (by index, not value).
                // count gives the number of nodes after walker to the end of the list.
                // backNode and forwardNode compare data in the nodes from the first half to the second half of the linked list.
                var backNode = head;
                do
                {
                    var forwardNode = walker;
                    for (int i = 0; i < count; i++)
                    {
                        forwardNode = forwardNode.Next;
                    }
                    if (forwardNode.data != backNode.data)
                    {
                        return false;
                    }
                    count--;
                    backNode = backNode.Next;
                } while (count > 0);
                return true;
            }
        }
    }
}
