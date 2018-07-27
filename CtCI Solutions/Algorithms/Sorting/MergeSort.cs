using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Algorithms
{
    public static partial class Sorts
    {
        // Implements MergeSort on an array of integers
        // Always O(n log n) runtime
        // Always O(n) space
        // Sorting is stable

        // If array contains more than two elements, initialize helper array and call recursive function.
        public static void MergeSort(int[] array)
        {
            if (array == null) { throw new ArgumentNullException(); }
            if (array.Length > 1)
            {
                var helper = new int[array.Length];
                MergeSort(array, helper, 0, array.Length - 1);
            }
        }

        // If lowIndex == highIndex, array index range is already sorted.
        // Otherwise, sort each half of index range, then merge.
        private static void MergeSort(int[] array, int[] helper, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var midIndex = lowIndex + (highIndex - lowIndex) / 2;
                MergeSort(array, helper, lowIndex, midIndex);
                MergeSort(array, helper, midIndex + 1, highIndex);
                Merge(array, helper, lowIndex, midIndex, highIndex);
            }
        }

        private static void Merge(int[] array, int[] helper, int lowIndex, int midIndex, int highIndex)
        {
            // Copy left range into helper at same indices
            Array.Copy(array, lowIndex, helper, lowIndex, midIndex - lowIndex + 1);

            var leftPointer = lowIndex;
            var rightPointer = midIndex + 1;
            var copyToPointer = lowIndex;

            while(leftPointer <= midIndex)
            {
                // Compare next element from both ranges
                // If right range has elements remaining and next element is larger than next left range element,
                // copy right range element to next open index in array
                while(rightPointer <= highIndex && array[rightPointer] < helper[leftPointer])
                {
                    array[copyToPointer] = array[rightPointer];
                    rightPointer++;
                    copyToPointer++;
                }

                // Next element of left range is larger
                // Copy it into array from helper
                array[copyToPointer] = helper[leftPointer];
                copyToPointer++;
                leftPointer++;
            }
            // Loop may terminate without rightPointer reaching highIndex.
            // If so, this means all of left range has been copied into place from helper array
            // and remaining elements of right range are sorted and located correctly in array already.
        }
    }
}
