using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch16 // Chapter Number
    {
        public static class Ex16 // Exercise number
        {
            /* Exercise 16.16
             * 
             * Sub Sort: Given an array of integers, write a method to find indices m and n such that
             * if you sorted elements m through n, the entire array would be sorted.
             * Minimize n - m (that is, find the smallest such sequence).
             * 
             * EXAMPLE
             * 
             * Input: 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19
             * Output: (3, 9)
             */

            public static int[] MiddleSortIndices(int[] array)
            {
                if (array == null) { throw new System.ArgumentNullException(); }
                if (array.Length < 2) { throw new System.ArgumentException("must have at least two elements"); }

                var leftEndIndex = leftEndIndex(array);
                var rightEndIndex = rightEndIndex(array);
            }
        }
    }
}
