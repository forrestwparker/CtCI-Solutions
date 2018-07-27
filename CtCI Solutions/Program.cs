using CtCI_Solutions.Data_Structures;
using CtCI_Solutions.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions
{
    class Program
    {
        static void Main(string[] args)
        {
            var rng = new Random();
            var array = new int[20];
            for (int i = 0; i < 20; i++) { array[i] = rng.Next(-10, 10); }
            Algorithms.Sorts.QuickSort(array);
            foreach(var val in array)
            {
                Console.Write("{0} ", val);
            }
            Console.WriteLine();
        }
    }
}
