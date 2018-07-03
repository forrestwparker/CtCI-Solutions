using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Algorithms
{
    public static partial class Sorts
    {
        // Implements MergeSort
        // Always O(n log n) runtime
        public static int[] MergeSort(int[] array)
        {
            if (array == null) { throw new ArgumentNullException(); }
            if (array.Length == 0) { throw new ArgumentOutOfRangeException(); }
            if (array.Length == 1) { return array; }
            var len1 = array.Length / 2;
            var len2 = array.Length - len1;
            var array1 = new int[len1];
            var array2 = new int[len2];
            Array.Copy(array, array1, len1);
            Array.Copy(array, len1, array2, 0, len2);
            return Merge(MergeSort(array1), MergeSort(array2));
        }

        private static int[] Merge(int[] array1, int[] array2)
        {
            int[] array = new int[array1.Length + array2.Length];
            var minlast = (array1.Last() <= array2.Last()) ? array1 : array2;
            var maxlast = (array1.Last() <= array2.Last()) ? array2 : array1;
            var maxIndex = 0;
            var mainIndex = 0;
            for (int i = 0; i < minlast.Length; i++)
            {
                while (maxlast[maxIndex] < minlast[i])
                {
                    array[mainIndex] = maxlast[maxIndex];
                    mainIndex++;
                    maxIndex++;
                }
                array[mainIndex] = minlast[i];
                mainIndex++;
            }
            Array.Copy(maxlast, maxIndex, array, mainIndex, maxlast.Length - maxIndex);
            return array;
        }
    }
}
