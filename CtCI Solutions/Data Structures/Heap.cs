using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Data_Structures
{
    public class Heap<T>
    {
        private List<T> Tree = new List<T>();
        private readonly Func<T, T, bool> Order;

        public int Count
        {
            get { return Tree.Count; }
        }


        public void Add(T item)
        {
            if (item == null) { throw new Exception("Cannot add null to heap"); }
            Tree.Add(item);
            SiftUp();
        }

        public T Peek()
        {
            if (Count == 0) { throw new Exception("Heap is empty"); }
            return Tree.First();
        }

        public T Extract()
        {
            if (Count == 0) { throw new Exception("Heap is empty"); }
            var temp = Peek();
            Tree[0] = Tree.Last();
            Tree.RemoveAt(Count - 1);
            try { SiftDown(0); } catch { }
            return temp;
        }

        private void SiftUp()
        {
            if (Count > 1) {
                var k = Count - 1;
                var parent = Parent(k);
                while (k > 0 && Order(Tree[k], Tree[parent]))
                {
                    Swap(k, parent);
                    k = parent;
                    try { parent = Parent(k); } catch { }
                }
            }
        }

        // Called when extracting the top element from the heap.
        private void SiftDown(int k)
        {
            if (k >= Count) { throw new ArgumentOutOfRangeException(); }
            if (Count > 1)
            {
                var replaceChild = LeftChild(k);
                if (replaceChild < Count)
                {
                    var right = RightChild(k);
                    if (right < Count && Order(Tree[right], Tree[replaceChild])) { replaceChild = right; }
                    if (Order(Tree[replaceChild], Tree[k])) { Swap(k, replaceChild); }
                    SiftDown(replaceChild);
                }
            }
        }

        private void Swap(int i, int k)
        {
            if (i >= Count || k >= Count) { throw new ArgumentOutOfRangeException(); }
            var temp = Tree[i];
            Tree[i] = Tree[k];
            Tree[k] = temp;
        }

        // Child and Parent index methods
        private int Parent(int k)
        {
            if (k == 0) { throw new Exception("No parent"); }
            return (k - 1) >> 1;
        }
        private int LeftChild(int k) { return 2 * k + 1; }
        private int RightChild(int k) { return 2 * k + 2; }


        private Heap() { }

        public Heap(Func<T, T, bool> order)
        {
            Order = order;
        }

        public Heap(IEnumerable<T> ienumerable, Func<T, T, bool> order): this(order)
        {
            if (ienumerable == null) { throw new ArgumentNullException("ienumerable"); }
            if (order == null) { throw new ArgumentNullException("order"); }
            foreach (var item in ienumerable) { Add(item); }
        }

    }
}
