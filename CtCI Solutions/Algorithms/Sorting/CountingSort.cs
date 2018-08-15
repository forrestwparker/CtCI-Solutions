using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Algorithms
{
    public static partial class Sorts
    {
        // Implements counting sort on an array of n integers
        // Requires known range of k possible values.
        // If k = O(n):
        //   O(n) runtime
        //   O(n) space
        // Sorting is stable
        public static void CountingSort(int[] array, int maxDigitValue)
        {
            if (array == null) { throw new ArgumentNullException(); }
            if (maxDigitValue < 0) { throw new ArgumentOutOfRangeException(); }
            if (array.Length > 1)
            {
                var lastNegativeIndex = PartitionNegatives(array);
                if (lastNegativeIndex > 0)
                {
                    CountingSort(array, maxDigitValue, 0, lastNegativeIndex, x => Math.Abs(x), true);
                }
                if (lastNegativeIndex < array.Length - 2)
                {
                    CountingSort(array, maxDigitValue, lastNegativeIndex + 1, array.Length - 1, x => x, false);
                }
            }
        }
        
        private static void CountingSort(int[] array, int maxDigitValue, int startIndex, int endIndex, Func<int, int> valueReader, bool reverseOrder)
        {
            if (array == null) { throw new ArgumentNullException(); }
            if (maxDigitValue < 0) { throw new ArgumentOutOfRangeException(); }
            if (startIndex < 0) { throw new ArgumentOutOfRangeException(); }
            if (startIndex > endIndex) { throw new ArgumentOutOfRangeException(); }
            if (endIndex > array.Length - 1) { throw new ArgumentOutOfRangeException(); }
            if (valueReader == null) { throw new ArgumentNullException(); }
            if (startIndex < endIndex)
            {
                var adjValueReader = (reverseOrder) ? x => maxDigitValue - valueReader(x) : valueReader;
                var counts = new int[maxDigitValue + 1];
                var aux = new int[endIndex - startIndex + 1];
                for (int i = startIndex; i <= endIndex; i++)
                {
                    var transValue = adjValueReader(array[i]);
                    if (transValue < 0) { throw new Exception("valueReader returned negative value"); }
                    if (transValue > maxDigitValue) { throw new Exception("valueReader returned value exceeding maxValue"); }
                    counts[transValue]++;
                }
                for (int i = 1; i <= maxDigitValue; i++)
                {
                    counts[i] += counts[i - 1];
                }
                for (int i = endIndex; i >= startIndex; i--)
                {
                    var value = array[i];
                    var transValue = adjValueReader(value);
                    aux[counts[transValue] - 1] = value;
                    counts[transValue]--;
                }
                Array.Copy(aux, 0, array, startIndex, aux.Length);
            }
        }

        // Returns last index containing a negative value, or -1 if array contains no negative values
        public static int PartitionNegatives(int[] array)
        {
            if (array == null) { throw new ArgumentNullException(); }
            if (array.Length == 0) { return -1; }
            else
            {
                var negativeIndex = -1;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < 0)
                    {
                        negativeIndex++;
                        Swap(array, negativeIndex, i);
                    }
                }
                return negativeIndex;
            }
        }
    }
}
