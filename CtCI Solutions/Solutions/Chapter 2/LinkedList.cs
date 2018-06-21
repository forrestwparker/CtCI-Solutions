using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch2 // Chapter number
    {
        public class LinkedList
        {
            public class Node
            {
                public Node Next;
                public int data;

                public void RemoveNext()
                {
                    if (Next != null) { Next = Next.Next; }
                }
            }
        }
    }
}
