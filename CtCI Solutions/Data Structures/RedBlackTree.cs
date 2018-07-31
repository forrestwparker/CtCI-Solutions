using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Data_Structures
{
    public class RBTree<T> where T : IComparable<T>
    {
        private RBNode Root;
        private readonly RBNode NullNode;

        public RBTree()
        {
            NullNode = RBTree<T>.NewNullNode();
            Root = NullNode;
        }

        private static RBNode NewNullNode()
        {
            var node = new RBNode(default(T));
            node.ColorBlack();
            return node;
        }

        private RBNode NewRBNode(T data)
        {
            var node = new RBNode(data);
            node.Parent = NullNode;
            node.LeftChild = NullNode;
            node.RightChild = NullNode;
            node.ColorRed();
            return node;
        }

        public bool IsInRBTree(T data)
        {
            return (Search(data) != NullNode) ? true : false;
        }

        private RBNode Search(T data)
        {
            var node = Root;
            while (node != NullNode && data.CompareTo(node.Data) != 0)
            {
                node = (data.CompareTo(node.Data) < 0) ? node.LeftChild : node.RightChild;
            }
            return node;
        }

        public T Minimum()
        {
            var node = Minimum(Root);
            if (node != NullNode) { return node.Data; }
            else { throw new Exception(); }
        }

        private RBNode Minimum(RBNode node)
        {
            if (node != NullNode)
            {
                while (node.LeftChild != NullNode) { node = node.LeftChild; }
            }
            return node;
        }

        public T Maximum()
        {
            var node = Maximum(Root);
            if (node != NullNode) { return node.Data; }
            else { throw new Exception(); }
        }

        private RBNode Maximum(RBNode node)
        {
            if (node != NullNode)
            {
                while (node.RightChild != NullNode) { node = node.RightChild; }
            }
            return node;
        }

        public T Predecessor(T data)
        {
            var node = Search(data);
            if (node == NullNode) { throw new Exception("data not found in RBTree"); }
            var pred = Predecessor(node);
            if (pred == NullNode) { throw new Exception("data is minimum"); }
            return pred.Data;
        }

        private RBNode Predecessor(RBNode node)
        {
            if (node == NullNode) { return node; }
            if (node.LeftChild != NullNode) { return Maximum(node.LeftChild); }
            var parent = node.Parent;
            while (parent != NullNode && node == parent.LeftChild)
            {
                node = parent;
                parent = node.Parent;
            }
            return parent;
        }

        public T Successor(T data)
        {
            var node = Search(data);
            if (node == NullNode) { throw new Exception("data not found in RBTree"); }
            var pred = Predecessor(node);
            if (pred == NullNode) { throw new Exception("data is maximum"); }
            return pred.Data;
        }

        private RBNode Successor(RBNode node)
        {
            if (node == NullNode) { return node; }
            if (node.RightChild != NullNode) { return Minimum(node.RightChild); }
            var parent = node.Parent;
            while (parent != NullNode && node == parent.RightChild)
            {
                node = parent;
                parent = node.Parent;
            }
            return parent;
        }

        public void Insert(T data)
        {
            RBNode y = NullNode;
            var x = Root;
            while (x != NullNode)
            {
                y = x;
                var comparisonValue = data.CompareTo(x.Data);
                if (comparisonValue == 0) { throw new Exception("data already in RBTree"); }
                x = (comparisonValue < 0) ? x.LeftChild : x.RightChild;
            }
            var node = NewRBNode(data);
            node.Parent = y;
            if (y == NullNode) { Root = node; }
            else if (data.CompareTo(y.Data) < 0) { y.LeftChild = node; }
            else { y.RightChild = node; }
            InsertFix(node);
        }

        private void InsertFix(RBNode node)
        {
            while (node.Parent.IsRed)
            {
                if (node.Parent == node.Parent.Parent.LeftChild)
                {
                    var uncle = node.Parent.Parent.RightChild;
                    if (uncle.IsRed)
                    {
                        node.Parent.ColorBlack();
                        uncle.ColorBlack();
                        node = node.Parent.Parent;
                        node.ColorRed();
                    }
                    else
                    {
                        if (node == node.Parent.RightChild)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }
                        node.Parent.ColorBlack();
                        node.Parent.Parent.ColorRed();
                        RotateRight(node.Parent.Parent);
                    }
                }
                else // Repeat for RightChild case
                {
                    var uncle = node.Parent.Parent.LeftChild;
                    if (uncle.IsRed)
                    {
                        node.Parent.ColorBlack();
                        uncle.ColorBlack();
                        node = node.Parent.Parent;
                        node.ColorRed();
                    }
                    else
                    {
                        if (node == node.Parent.LeftChild)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }
                        node.Parent.ColorBlack();
                        node.Parent.Parent.ColorRed();
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }

            // Color the root black
            Root.ColorBlack();
        }

        public void Delete(T data)
        {
            var node = Search(data);
            if (node != NullNode)
            {
                var holeNode = node;
                var holeNodeIsBlack = holeNode.IsBlack;
                RBNode movedNode;
                if (node.LeftChild == NullNode)
                {
                    movedNode = node.RightChild;
                    Transplant(node, movedNode);
                }
                else if (node.RightChild == NullNode)
                {
                    movedNode = node.LeftChild;
                    Transplant(node, movedNode);
                }
                else
                {
                    holeNode = Minimum(node.RightChild);
                    holeNodeIsBlack = holeNode.IsBlack;
                    movedNode = holeNode.RightChild;
                    if (holeNode == node.RightChild) { holeNode.Parent = node; }
                    else
                    {
                        Transplant(holeNode, movedNode);
                        holeNode.RightChild = node.RightChild;
                        holeNode.RightChild.Parent = holeNode;
                    }
                    Transplant(node, holeNode);
                    holeNode.LeftChild = node.LeftChild;
                    holeNode.LeftChild.Parent = holeNode;
                    if (node.IsBlack) { holeNode.ColorBlack(); }
                    else { holeNode.ColorRed(); }
                }
                if (holeNodeIsBlack) { DeleteFix(movedNode); }
            }
        }

        private void DeleteFix(RBNode node)
        {
            while (node != Root && node.IsBlack)
            {
                if (node == node.Parent.LeftChild)
                {
                    var sibling = node.Parent.RightChild;
                    if (sibling.IsRed)
                    {
                        sibling.ColorBlack();
                        node.Parent.ColorRed();
                        RotateLeft(node.Parent);
                        sibling = node.Parent.RightChild;
                    }
                    if (sibling.LeftChild.IsBlack && sibling.RightChild.IsBlack)
                    {
                        sibling.ColorRed();
                        node = node.Parent;
                    }
                    else
                    {
                        if (sibling.RightChild.IsBlack)
                        {
                            sibling.ColorRed();
                            sibling.LeftChild.ColorBlack();
                            RotateRight(sibling);
                            sibling = node.Parent.RightChild;
                        }
                        sibling.RightChild.ColorBlack();
                        if (node.Parent.IsBlack) { sibling.ColorBlack(); }
                        else { sibling.ColorRed(); }
                        node.Parent.ColorBlack();
                        RotateLeft(node.Parent);
                        node = Root;
                    }
                }
                else // Repeat for RightChild case
                {
                    var sibling = node.Parent.LeftChild;
                    if (sibling.IsRed)
                    {
                        sibling.ColorBlack();
                        node.Parent.ColorRed();
                        RotateRight(node.Parent);
                        sibling = node.Parent.LeftChild;
                    }
                    if (sibling.RightChild.IsBlack && sibling.LeftChild.IsBlack)
                    {
                        sibling.ColorRed();
                        node = node.Parent;
                    }
                    else
                    {
                        if (sibling.LeftChild.IsBlack)
                        {
                            sibling.ColorRed();
                            sibling.RightChild.ColorBlack();
                            RotateLeft(sibling);
                            sibling = node.Parent.LeftChild;
                        }
                        sibling.LeftChild.ColorBlack();
                        if (node.Parent.IsBlack) { sibling.ColorBlack(); }
                        else { sibling.ColorRed(); }
                        node.Parent.ColorBlack();
                        RotateRight(node.Parent);
                        node = Root;
                    }
                }
            }
            node.ColorBlack();
        }

        private void RotateLeft(RBNode pivotNode)
        {
            // If pivotNode or pivotNode.RightChild == NullNode, RotateLeft cannot occur.
            if (pivotNode == NullNode) { throw new Exception("Cannot rotate NullNode"); }
            if (pivotNode.RightChild == NullNode) { throw new Exception("Cannot rotate left if RightChild is NullNode"); }

            var replacementNode = pivotNode.RightChild;

            // Set pivotNode.RightChild (to replacementNode.LeftChild) and set the child's Parent to pivotNode
            pivotNode.RightChild = replacementNode.LeftChild;
            if (pivotNode.RightChild != NullNode) { pivotNode.RightChild.Parent = pivotNode; }

            // Set replacementNode.Parent (to pivotNode.Parent) and set its Parent's appropriate child to replacementNode
            replacementNode.Parent = pivotNode.Parent;
            if (replacementNode.Parent == NullNode) { Root = replacementNode; }
            else if (replacementNode.Parent.LeftChild == pivotNode) { replacementNode.Parent.LeftChild = replacementNode; }
            else { replacementNode.Parent.RightChild = replacementNode; }

            // Set replacementNode.LeftChild (to pivotNode) and pivotNode.Parent (to replacementNode)
            replacementNode.LeftChild = pivotNode;
            pivotNode.Parent = replacementNode;

            // All other node connections remain the same
        }

        private void RotateRight(RBNode pivotNode)
        {
            // If pivotNode or pivotNode.LeftChild == NullNode, RotateRight cannot occur.
            if (pivotNode == NullNode) { throw new Exception("Cannot rotate NullNode"); }
            if (pivotNode.LeftChild == NullNode) { throw new Exception("Cannot rotate right if LeftChild is NullNode"); }

            var replacementNode = pivotNode.LeftChild;

            // Set pivotNode.LeftChild (to replacementNode.RightChild) and set the child's Parent to pivotNode
            pivotNode.LeftChild = replacementNode.RightChild;
            if (pivotNode.LeftChild != NullNode) { pivotNode.LeftChild.Parent = pivotNode; }

            // Set replacementNode.Parent (to pivotNode.Parent) and set its Parent's appropriate child to replacementNode
            replacementNode.Parent = pivotNode.Parent;
            if (replacementNode.Parent == NullNode) { Root = replacementNode; }
            else if (replacementNode.Parent.LeftChild == pivotNode) { replacementNode.Parent.LeftChild = replacementNode; }
            else { replacementNode.Parent.RightChild = replacementNode; }

            // Set replacementNode.RightChild (to pivotNode) and pivotNode.Parent (to replacementNode)
            replacementNode.RightChild = pivotNode;
            pivotNode.Parent = replacementNode;

            // All other node connections remain the same
        }

        private void Transplant(RBNode oldNode, RBNode newNode)
        {
            if (oldNode == NullNode) { throw new Exception("oldNode must not be null"); }
            if (oldNode.Parent == NullNode) { Root = newNode; }
            else if (oldNode == oldNode.Parent.LeftChild) { oldNode.Parent.LeftChild = newNode; }
            else { oldNode.Parent.RightChild = newNode; }
            newNode.Parent = oldNode.Parent;
        }

        private class RBNode
        {
            public RBNode Parent;
            public RBNode LeftChild;
            public RBNode RightChild;
            public T Data;

            private Color NodeColor = RBNode.Color.red;
            public bool IsBlack { get { return NodeColor == Color.black; } }
            public bool IsRed { get { return NodeColor == Color.red; } }

            public void ColorBlack() { NodeColor = Color.black; }
            public void ColorRed() { NodeColor = Color.red; }

            public RBNode(T data)
            {
                Data = data;
            }

            private enum Color
            {
                red, black
            }
        }
    }
}
