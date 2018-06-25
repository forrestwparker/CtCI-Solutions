using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch16 // Chapter Number
    {
        public static class Ex21 // Exercise number
        {
            /* Exercise 16.21
             * 
             * Sum Swap: Given two arrays of integers, find a pair of values (one value from each array)
             * that you can swap to give the two arrays the same sum.
             * 
             * EXAMPLE
             * 
             * Input: {4, 1, 2, 1, 1, 2} and {3, 6, 3, 3}
             * Output: {1, 3}
             */

            // Target sum is half the total sum of the two arrays combined.
            // Put values in one array in hashset, then check if paired value exists in hashset for each element of the other array.
            // Return found pair, or throw exception if none exists.
            // O(|A| + |B|) runtime, O(min(|A|,|B|)) space
            public static int[] SumSwap(int[] array1, int[] array2)
            {
                if (array1 == null) { throw new System.ArgumentNullException("array1"); }
                if (array2 == null) { throw new System.ArgumentNullException("array2"); }
                if (array1.Length == 0) { throw new System.InvalidOperationException("array1 contains no elements"); }
                if (array2.Length == 0) { throw new System.InvalidOperationException("array2 contains no elements"); }

                var array1sum = array1.Aggregate((sum, next) => sum + next);
                var array2sum = array2.Aggregate((sum, next) => sum + next);
                if ((array1sum + array2sum) % 2 != 0) { throw new System.InvalidOperationException("Total sum must be even"); }
                var targetSum = (array1sum + array2sum) / 2;

                var smallArray = (array1.Length < array2.Length) ? array1 : array2;
                var bigArray = (array1.Length < array2.Length) ? array2 : array1;
                var hashset = new HashSet<int>();

                foreach (var value in smallArray) { hashset.Add(value); }
                foreach (var value in bigArray)
                {
                    if (hashset.Contains(targetSum-value)) { return new int[] { value, targetSum - value}; }
                }
                throw new System.InvalidOperationException("No pair exists");
            }
        }
    }
}
