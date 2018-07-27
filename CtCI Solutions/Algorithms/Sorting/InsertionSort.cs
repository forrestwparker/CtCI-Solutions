using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Algorithms
{
    public static partial class Sorts
    {
        // Implements insertion sort on an array of integers
        // Best: O(n) runtime
        // Worst: O(n^2) runtime
        // Always O(1) space
        // Sorting is stable
        public static void InsertionSort(int[] array)
        {
            if (array == null) { throw new ArgumentNullException(); }
            if (array.Length > 1)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    var value = array[i];
                    var j = i - 1;
                    while (j >= 0 && array[j] > value)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    array[j + 1] = value;
                }
            }
        }
    }
}
