using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Data_Structures
{
    public class SingleNode<T>
    {
        public SingleNode<T> Next;
        public T Data;
    }

    public class DoubleNode<T>
    {
        public DoubleNode<T> Left;
        public DoubleNode<T> Right;
        public T Data;
    }
}
