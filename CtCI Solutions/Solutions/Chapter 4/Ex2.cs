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
        public static class Ex2 // Exercise number
        {
            /* Exercise 4.2
             * 
             * Minimal Tree: Given a sorted (increasing order) array with unique integer elements,
             * write an algorithm to create a binary search tree with minimal height.
             */

            // O(n) runtime, O(n) space
            public static BinaryTreeNode<int> MakeBinaryTree(int[] array)
            {
                if (array == null) { throw new ArgumentNullException(); }
                if (array.Length == 0) { throw new ArgumentOutOfRangeException(); }
                return MakeBinaryTree(array, 0, array.Length - 1);
            }

            private static BinaryTreeNode<int> MakeBinaryTree(int[] array, int startIndex, int stopIndex)
            {
                if (startIndex == stopIndex) { return new BinaryTreeNode<int>(array[startIndex]); }

                // Add one to interval radius calculation to pass extra node to left child.
                var midIndex = startIndex + ((1 + stopIndex - startIndex) / 2);
                var node = new BinaryTreeNode<int>(array[midIndex]);
                node.LeftChild = MakeBinaryTree(array, startIndex, midIndex - 1);
                if (midIndex != stopIndex) { node.RightChild = MakeBinaryTree(array, midIndex + 1, stopIndex); }
                return node;
            }
        }
    }
}
