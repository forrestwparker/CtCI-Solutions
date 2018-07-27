using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Algorithms
{
    public static partial class Sorts
    {
        // Implements QuickSort on an array of integers
        // Best: O(n) runtime
        // Worst: O(n^2) runtime
        // Average: O(n log n) runtime
        // ??? space
        // Sorting is stable

        // Pivot function. Default to average of first and last value of array range.
        private static Func<int[], int, int, int> GetPivot = (x, y, z) => x[y + (z - y) / 2];

        public static void QuickSort(int[] array)
        {
            if (array == null) { throw new ArgumentNullException(); }
            if (array.Length > 1)
            {
                QuickSort(array, 0, array.Length - 1);
            }
        }

        private static void QuickSort(int[] array, int lowIndex, int highIndex)
        {
            // Partition array by swapping elements around some chosen index so
            // lower elements are to the left and higher elements are to the right.
            var index = Partition(array, lowIndex, highIndex);

            // Sort the left if it exists and contains more than one element.
            if (lowIndex < index - 1) { QuickSort(array, lowIndex, index - 1); }

            // Sort the right if it contains more than one element.
            if (index < highIndex) { QuickSort(array, index, highIndex); }
        }

        private static int Partition(int[] array, int lowIndex, int highIndex)
        {
            var pivot = GetPivot(array, lowIndex, highIndex);
            while (lowIndex <= highIndex)
            {
                // Find next element from left larger than pivot.
                while (array[lowIndex] < pivot) { lowIndex++; }

                // Find next element from right smaller than pivot.
                while (array[highIndex] > pivot) { highIndex--; }

                // If elements are not places correctly relative to each other, swap them.
                if (lowIndex <= highIndex)
                {
                    Swap(array, lowIndex, highIndex);
                    lowIndex++;
                    highIndex--;
                }
            }

            // lowIndex points to first element from left larger than pivot.
            return lowIndex;
        }

        private static void Swap(int[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
