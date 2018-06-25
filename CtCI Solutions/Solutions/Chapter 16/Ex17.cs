using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch16 // Chapter Number
    {
        public static class Ex17 // Exercise number
        {
            /* Exercise 16.17
             * 
             * Contiguous Sequence: You are given an array of integers (both positive and negative).
             * Find the contiguous sequence with the largest sum.
             * Return the sum.
             * 
             * EXAMPLE
             * 
             * Input: 2, -8, 3, -2, 4, -10
             * Output: 5 (i.e., {3, -2, 4})
             */

            // Initialize sum and maxSum to 0.
            // Add each element of array to sum.
            // If sum exceeds maxSum, replace maxSum.
            // Otherwise, if sum is ever negative, reset sum.
            // O(n) runtime, O(1) space
            public static int LargestSum(int[] array)
            {
                if (array == null) { throw new System.ArgumentNullException(); }
                var sum = 0;
                var maxSum = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                    else if (sum < 0)
                    {
                        sum = 0;
                    }
                }
                return maxSum;
            }

        }
    }
}
