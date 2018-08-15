using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Algorithms
{
    public static partial class Sorts
    {
        // Implements radix sort on an array of n (binary) integers.
        // Always O(n) runtime
        // Always O(n) space
        // Sorting is stable
        public static void RadixSort(int[] array)
        {
            if (array == null) { throw new ArgumentNullException(); }
            if (array.Length > 1)
            {
                var negPosMaxValues = ArrayMaxNegPosAbs(array);
                var negMax = negPosMaxValues.Item1;
                var posMax = negPosMaxValues.Item2;
                var lastNegativeIndex = (negMax == 0) ? -1 : PartitionNegatives(array);
                if (lastNegativeIndex > 0)
                {
                    var maxDigit = Log2(negMax);
                    for (int i = 0; i <= maxDigit; i++) { CountingSort(array, 1, 0, lastNegativeIndex, x => (Math.Abs(x) >> i) & 1, true); }
                }
                if (lastNegativeIndex < array.Length - 2)
                {
                    var maxDigit = Log2(posMax);
                    for (int i = 0; i <= maxDigit; i++) { CountingSort(array, 1, lastNegativeIndex + 1, array.Length - 1, x => (x >> i) & 1, false); }
                }
            }
        }

        private static void Swap(Object[] array, int index1, int index2)
        {
            Object temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        private static Tuple<int, int> ArrayMaxNegPosAbs(int[] array)
        {
            var negMax = 0;
            var posMax = 0;
            foreach (var value in array)
            {
                negMax = Math.Abs(Math.Min(-negMax, value));
                posMax = Math.Max(posMax, Math.Abs(value));
            }
            return new Tuple<int, int>(negMax, posMax);
        }

        private static int Log2(int value)
        {
            if (value <= 0) { throw new ArgumentOutOfRangeException("value must be positive"); }
            var count = -1;
            do
            {
                count++;
                value >>= 1;
            } while (value != 0);
            return count;
        }
    }
}
