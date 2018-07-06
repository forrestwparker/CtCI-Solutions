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
        public static class Ex11 // Exercise number
        {
            /* Exercise 4.11
             * 
             * Random Node: You are implementing a binary tree class from scratch which, in addition to
             * 'insert', 'find', and 'delete', has a method 'getRandomNode()' which returns a random node
             * from the tree.
             * All nodes should be equally likely to be chosen. Design and implement an algorithm for 'getRandomNode',
             * and explain how you would implement the rest of the methods.
             */

            //
            //
            public class BinaryTree<T>
            {
                

                private class Node
                {
                    public Node Parent;
                    public Node LeftChild;
                    public Node RightChild;
                    public T Data;
                    public int LeftCount { get; private set; }
                    public int RightCount { get; private set; }
                }
            }
        }
    }
}
