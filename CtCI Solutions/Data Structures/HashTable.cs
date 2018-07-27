using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Data_Structures
{
    // Implementation of a hashtable only using arrays
    class HashTable<K, V>
    {
        private HashNode[] KeyValueNodes;
        public int Count { get; private set; }

        private class HashNode
        {
            public HashNode Next;
            public K Key;
            public V Value;
        }
    }
}
