using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Data_Structures
{
    public class Node<T>
    {
        public T Data;
    }

    public class SingleNode<T>: Node<T>
    {
        public SingleNode<T> Next;
    }

    public class DoubleNode<T>: Node<T>
    {
        public DoubleNode<T> Left;
        public DoubleNode<T> Right;
    }

    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode<T> Parent;
        public BinaryTreeNode<T> LeftChild;
        public BinaryTreeNode<T> RightChild;

        public BinaryTreeNode(T data)
        {
            Data = data;
        }
    }
}
