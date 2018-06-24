using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch16 // Chapter Number
    {
        public static class Ex6 // Exercise number
        {
            /* Exercise 16.6
             * 
             * Smallest Difference: Given two arrays of integers, comput the pair of values
             * (one value in each array) with the smallest (non-negative) difference.
             * Return the difference.
             * 
             * EXAMPLE
             * 
             * Input: {1, 3, 15, 11, 2}, {23, 127, 235, 19, 8}
             * Output: 3. That is, the pair (11,8).
             */

            // Sort the arrays, then compare element by element.
            // In comparison, record the difference (if smaller than all previous).
            // Assume no differences of values in A, B will exceed int.MaxValue.
            // Advance pointer of lower value.
            // O(|A| log |A| + |B| log |B|) runtime, O(1) space
            // (Runtime caused by sorting)
            public static int SmallestDifference(int[] A, int[] B)
            {
                // Exceptions
                if (A == null) { throw new System.ArgumentNullException("A"); }
                if (B == null) { throw new System.ArgumentNullException("B"); }
                if (A.Length == 0) { throw new System.ArgumentException("Array must contain at least one integer", "A"); }
                if (B.Length == 0) { throw new System.ArgumentException("Array must contain at least one integer", "B"); }

                Array.Sort(A);
                Array.Sort(B);

                var pointerA = 0;
                var pointerB = 0;
                int minDiff = int.MaxValue;
                while (pointerA < A.Length && pointerB < B.Length)
                {
                    minDiff = Math.Min(minDiff, Math.Abs(A[pointerA] - B[pointerB]));
                    if (A[pointerA] < B[pointerB]) { pointerA++; }
                    else { pointerB++; }
                }
                return minDiff;
            }
        }
    }
}
