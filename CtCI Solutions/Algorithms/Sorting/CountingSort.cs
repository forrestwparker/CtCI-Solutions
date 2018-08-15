using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Algorithms
{
    public static partial class Sorts
    {
        // Implements counting sort on an array of n nonnegative integers
        // Requires known range of k possible values.
        // If k = O(n):
        //   O(n) runtime
        //   O(n) space
        // Sorting is stable
        public static void CountingSort(int[] array, int maxValue)
        {
            if (array == null) { throw new ArgumentNullException(); }
            if (array.Length > 1)
            {
                var counts = new int[maxValue + 1];
                var aux = new int[array.Length];
                foreach (var value in array)
                {
                    counts[value]++;
                }
                for (int i = 1; i <= maxValue; i++)
                {
                    counts[i] += counts[i - 1];
                }
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    var value = array[i];
                    aux[counts[value] - 1] = value;
                    counts[value]--;
                }
                Array.Copy(aux, array, array.Length);
            }
        }
    }
}
