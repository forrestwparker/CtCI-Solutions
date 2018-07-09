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
        public static class Ex6 // Exercise number
        {
            /* Exercise 4.6
             * 
             * Successor: Write an algorithm to find the "next" node (i.e., in-order successor)
             * of a given node in a binary search tree.
             * You may assume that each node has a link to its parent.
             */

            // O(n) worst runtime, O(1) space
            public static BinaryTreeNode<T> NextInTree<T>(BinaryTreeNode<T> node)
            {
                if (node == null) { throw new ArgumentNullException("node"); }

                if (node.RightChild == null)
                {
                    // node has a right child.
                    // Return leftmost node of right subtree.
                    var nextNode = node.RightChild;
                    while (nextNode.LeftChild != null) { nextNode = nextNode.LeftChild; }
                    return nextNode;
                }
                else
                {
                    // node has no right child.
                    // Return first ancestor which is its parent's left child.
                    // If parent is null before such an ancestor is found, node was last node of the tree.
                    var child = node;
                    var parent = node.Parent;

                    while (parent != null && parent.LeftChild != child)
                    {
                        child = parent;
                        parent = child.Parent;
                    }
                    return parent;
                }
            }
        }
    }
}
