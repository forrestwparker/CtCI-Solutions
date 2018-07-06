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
        public static class Ex3 // Exercise number
        {
            /* Exercise 4.3
             * 
             * List of Depths: Given a binary tree, design an algorithm which
             * creates a linked list of all the nodes at each depth
             * (e.g., if you have a tree with depth D, you'll have D linked lists).
             */

            // O(n) runtime, O(n) space
            // Can make O(1) space if allowed to reuse existing node instances to create the LinkedLists.
            public static List<LinkedList<DoubleNode<T>>> ListOfDepths<T>(DoubleNode<T> root)
            {
                if (root == null) { throw new ArgumentNullException(); }
                var nodeDepthList = new List<LinkedList<DoubleNode<T>>>();
                var nodeList = new LinkedList<DoubleNode<T>>();
                nodeList.AddLast(root);
                do
                {
                    nodeDepthList.Add(nodeList);
                    var newNodeList = new LinkedList<DoubleNode<T>>();
                    foreach (var node in nodeList)
                    {
                        if (node.Left != null) { newNodeList.AddLast(node.Left); }
                        if (node.Right != null) { newNodeList.AddLast(node.Right); }
                    }
                    nodeList = newNodeList;
                } while (nodeList.Count > 0);
                return nodeDepthList;
            }
        }
    }
}
