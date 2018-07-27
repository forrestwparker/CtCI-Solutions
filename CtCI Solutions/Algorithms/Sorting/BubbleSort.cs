using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Algorithms
{
    public static partial class Sorts
    {
        // Implements bubblesort on an array of integers
        // Best: O(n) runtime
        // Worst: O(n^2) runtime
        // Always O(1) space
        // Sorting is stable
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
