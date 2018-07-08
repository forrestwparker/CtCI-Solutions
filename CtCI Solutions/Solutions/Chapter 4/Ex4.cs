using CtCI_Solutions.Data_Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch4 // Chapter number
    {
        public static class Ex4 // Exercise number
        {
            /* Exercise 4.4
             * 
             * Check Balanced: Implement a function to check if a binary tree is balanced.
             * For the purposes of this question, a balanced tree is defined to be a tree such that
             * the heights of the two subtrees of any node never differ by more than one.
             */

            // Uses height value of int.MinValue to denote that the tree is not balanced.
            // O(n) runtime, O(height of tree) space
            public static bool IsBalanced<T>(BinaryTreeNode<T> node)
            {
                if (node == null) { throw new ArgumentNullException(); }
                return BalancedHeightCheck<T>(node) != int.MinValue;
            }

            private static int BalancedHeightCheck<T>(BinaryTreeNode<T> node)
            {
                if (node == null) { return -1; }

                var leftHeight = BalancedHeightCheck<T>(node.LeftChild);
                if (leftHeight == int.MinValue) { return int.MinValue; }

                var rightHeight = BalancedHeightCheck<T>(node.RightChild);
                if (rightHeight == int.MinValue) { return int.MinValue; }

                var diff = leftHeight - rightHeight;

                // If the difference in heights is greater than one, the tree is not balanced.
                if (Math.Abs(diff) > 1) { return int.MinValue; }

                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }
    }
}
