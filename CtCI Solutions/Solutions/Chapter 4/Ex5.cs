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
        public static class Ex5 // Exercise number
        {
            /* Exercise 4.5
             * 
             * Validate BST: Implement a function to check if a binary tree is a binary search tree.
             */

            // O(n) runtime, O(log n) space
            public static bool ValidateBST(BinaryTreeNode<int> node)
            {
                if (node == null) { throw new ArgumentNullException(); }
                return IsBST(node, null, null);
            }

            private static bool IsBST(BinaryTreeNode<int> node, int? minBound, int? maxBound)
            {
                if (node == null) { return true; }

                if ((minBound != null && node.Data <= minBound)
                    || ( maxBound != null && node.Data > maxBound)) { return false; }

                if (!IsBST(node.LeftChild, minBound, node.Data) || !IsBST(node.RightChild, node.Data + 1, maxBound)) { return false; }

                return true;
            }
        }
    }
}
