using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch17 // Chapter Number
    {
        public static class Ex5 // Exercise number
        {
            /* Exercise 17.5
             * 
             * Letters and Numbers: Given an array filled with letters and numbers,
             * find the longest subarray with an equal number of letters and numbers.
             */

            // Keep running difference in character type count.
            // For each new value of countDiff, record the index in firstUniqueSumIndex dictionary.
            // For each non-new value of countDiff, check if the difference in indices to first countDiff occurrance
            // is greater than the current maxium difference attained.
            // If so, record new values.
            // Return the indices of max balanced subarray, or throw exception if none exists.
            // O(n) runtime, O(n) space.
            public static int[] LongestBalancedSubarray(char[] array)
            {
                if (array == null) { throw new System.ArgumentNullException("array"); }
                if (array.Length == 0) { throw new System.ArgumentException("must contain elements", "array"); }

                var firstCharIsNumber = char.IsDigit(array[0]);
                var countDiff = 0;
                MaxBalancedSubarrayValues valueCollection = null;
                var firstUniqueSumIndex = new Dictionary<int, int>();

                for (int i = 0; i < array.Length; i++)
                {
                    if (firstCharIsNumber == char.IsDigit(array[i])) { countDiff++; }
                    else { countDiff--; }
                    if (firstUniqueSumIndex.ContainsKey(countDiff))
                    {
                        if (valueCollection == null)
                        {
                            valueCollection = new MaxBalancedSubarrayValues
                            {
                                LowIndex = firstUniqueSumIndex[countDiff],
                                HighIndex = i
                            };
                        }
                        else
                        {
                            var diff = i - firstUniqueSumIndex[countDiff];
                            if (diff > valueCollection.Length)
                            {
                                valueCollection.LowIndex = firstUniqueSumIndex[countDiff];
                                valueCollection.HighIndex = i;
                            }
                        }
                    }
                    else { firstUniqueSumIndex.Add(countDiff, i); }
                }

                if (valueCollection != null)
                {
                    return new int[]
                    {
                        valueCollection.LowIndex,
                        valueCollection.HighIndex
                    };
                }
                else { throw new System.InvalidOperationException("No balanced subarray exists"); }
            }

            private class MaxBalancedSubarrayValues
            {
                public int LowIndex;
                public int HighIndex;
                public int Length
                {
                    get { return HighIndex - LowIndex; }
                }
            }
        }
    }
}
