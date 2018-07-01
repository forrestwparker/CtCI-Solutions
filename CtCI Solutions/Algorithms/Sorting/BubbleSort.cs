using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Algorithms
{
    public static class Sorts
    {
        public static void BubbleSort(int[] array)
        {
            if (array == null) { throw new ArgumentNullException(); }
            if (array.Length > 1)
            {
                bool didSwap;
                do
                {
                    didSwap = false;
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        if (array[i] > array[i + 1])
                        {
                            var temp = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = temp;
                            didSwap = true;
                        }
                    }
                } while (didSwap);
            }
        }
    }
}
