using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch16 // Chapter Number
    {
        public static class Ex25 // Exercise number
        {
            /* Exercise 16.25
             * 
             * LRU Cache: Design and build a "least recently used" cache, which evicts the least recently used item.
             * The cache should map from keys to values (allowing you to insert and retrieve a value associated with
             * a particular key) and be initialized with a max size.
             * When it is full, it should evict the least recently used item.
             */

            public class LRUCache<T, U>
            {
                public int Capacity { get; private set; }
                private Dictionary<T, Node> NodeDictionary;
                private Node Head = null;
                private Node Tail = null;
                private int Count = 0;

                public LRUCache(int capacity)
                {
                    Capacity = capacity;
                    NodeDictionary = new Dictionary<T, Node>(Capacity);
                }

                // Set Key and Value.
                public void SetKeyAndValue(T key, U value)
                {
                    Node node;
                    try
                    {
                        node = NodeDictionary[key];
                        Remove(node);
                        Count--;
                    }
                    catch { node = new Node(); }
                    node.Value = value;
                    InsertAtFront(node);
                    Count++;
                }

                // Read Value.
                public U GetValue(T key)
                {
                    Node node;
                    try { node = NodeDictionary[key]; }
                    catch (Exception ex) { throw new System.ArgumentException("Key does not exist.", ex); }
                    Remove(node);
                    InsertAtFront(node);
                    return node.Value;
                }

                // Delete Key and Value.
                public void Delete(T key)
                {
                    try
                    {
                        Node node = NodeDictionary[key];
                        NodeDictionary.Remove(key);
                        Remove(node);
                        Count--;
                    }
                    catch { }
                }

                // Evict least recently used key.
                private void EvictLeastRecent()
                {
                    while (Count > Capacity)
                    {
                        Delete(Tail.Key);
                    }
                }

                // Insert at front of list.
                private void InsertAtFront(Node node)
                {
                    if (Head != null)
                    {
                        Head = node;
                        Tail = node;
                    }
                    else
                    {
                        Head.Previous = node;
                        node.Next = Head;
                        Head = node;
                    }
                }

                // Remove from Linked List.
                private void Remove(Node node)
                {
                    if (node == null) { return; }
                    if (node.Previous != null) {
                        node.Previous.Next = node.Next;
                        node.Previous = null;
                    }
                    if (node.Next != null) {
                        node.Next.Previous = node.Previous;
                        node.Next = null;
                    }
                    if (Head == node) { Head = node.Next; }
                    if (Tail == node) { Tail = node.Previous; }
                }

                private class Node{
                    public Node Previous;
                    public Node Next;
                    public T Key;
                    public U Value;
                }
            }
        }
    }
}
