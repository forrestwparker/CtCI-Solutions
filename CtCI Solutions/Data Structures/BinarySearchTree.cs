using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Data_Structures
{
    public class BinarySearchTree<T> where T: IComparable<T>
    {
        private BSTNode Root;

        public bool IsInBST(T data)
        {
            return (Search(data) != null) ? true : false;
        }

        private BSTNode Search(T data)
        {
            var node = Root;
            while (node != null && data.CompareTo(node.Data) != 0)
            {
                node = (data.CompareTo(node.Data) < 0) ? node.LeftChild : node.RightChild;
            }
            return node;
        }

        public T Minimum()
        {
            var node = Minimum(Root);
            if (node != null) { return node.Data; }
            else { throw new Exception(); }
        }

        private BSTNode Minimum(BSTNode node)
        {
            if (node != null)
            {
                while (node.LeftChild != null) { node = node.LeftChild; }
            }
            return node;
        }

        public T Maximum()
        {
            var node = Maximum(Root);
            if (node != null) { return node.Data; }
            else { throw new Exception(); }
        }

        private BSTNode Maximum(BSTNode node)
        {
            if (node != null)
            {
                while (node.RightChild != null) { node = node.RightChild; }
            }
            return node;
        }

        public T Predecessor(T data)
        {
            var node = Search(data);
            if (node == null) { throw new Exception("data not found in BST"); }
            var pred = Predecessor(node);
            if (pred == null) { throw new Exception("data is minimum"); }
            return pred.Data;
        }

        private BSTNode Predecessor(BSTNode node)
        {
            if (node == null) { return node; }
            if (node.LeftChild != null) { return Maximum(node.LeftChild); }
            var parent = node.Parent;
            while (parent != null && node == parent.LeftChild)
            {
                node = parent;
                parent = node.Parent;
            }
            return parent;
        }

        public T Successor(T data)
        {
            var node = Search(data);
            if (node == null) { throw new Exception("data not found in BST"); }
            var pred = Predecessor(node);
            if (pred == null) { throw new Exception("data is maximum"); }
            return pred.Data;
        }

        private BSTNode Successor(BSTNode node)
        {
            if (node == null) { return node; }
            if (node.RightChild != null) { return Minimum(node.RightChild); }
            var parent = node.Parent;
            while (parent != null && node == parent.RightChild)
            {
                node = parent;
                parent = node.Parent;
            }
            return parent;
        }

        public void Insert(T data)
        {
            BSTNode y = null;
            var x = Root;
            while (x != null)
            {
                y = x;
                var comparisonValue = data.CompareTo(x.Data);
                if (comparisonValue == 0) { throw new Exception("data already in BST"); }
                x = (comparisonValue < 0) ? x.LeftChild : x.RightChild;
            }
            var node = new BSTNode(data);
            node.Parent = y;
            if (y == null) { Root = node; }
            else if (data.CompareTo(y.Data) < 0) { y.LeftChild = node; }
            else { y.RightChild = node; }
        }

        public void Delete(T data)
        {
            var node = Search(data);
            if (node != null)
            {
                if (node.LeftChild == null) { Transplant(node, node.RightChild); }
                else if (node.RightChild == null) { Transplant(node, node.LeftChild); }
                else
                {
                    var successor = Minimum(node.RightChild);
                    if (successor.Parent != node)
                    {
                        Transplant(successor, successor.RightChild);
                        successor.RightChild = node.RightChild;
                        successor.RightChild.Parent = successor;
                    }
                    Transplant(node, successor);
                    successor.LeftChild = node.LeftChild;
                    successor.LeftChild.Parent = successor;
                }
            }
        }

        private void Transplant(BSTNode oldNode, BSTNode newNode)
        {
            if (oldNode == null) { throw new Exception("oldNode must not be null"); }
            if (oldNode.Parent == null) { Root = newNode; }
            else if (oldNode == oldNode.Parent.LeftChild) { oldNode.Parent.LeftChild = newNode; }
            else { oldNode.Parent.RightChild = newNode; }
            if (newNode != null) { newNode.Parent = oldNode.Parent; }
        }

        protected class BTNode<U>
        {
            public U Parent;
            public U LeftChild;
            public U RightChild;
            public T Data;

            public BTNode(T data)
            {
                Data = data;
            }
        }

        private class BSTNode: BTNode<BSTNode>
        {
            public BSTNode(T data): base(data) { }
        }
    }
}
