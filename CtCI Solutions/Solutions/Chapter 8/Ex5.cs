using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch8 // Chapter number
    {
        public static class Ex5 // Exercise number
        {
            /* Exercise 8.5
             * 
             * Recursive Multiply: Write a recursive function to multiply two positive integers without using the * operator (or / operator).
             * You can use addition, subtraction, and bit shifting, but you should minimize the number of those operations.
             */

            // O(log Min(a, b)) runtime, O(log Min(a,b)) space
            public static int Multiply(int a, int b)
            {
                var small = (a < b) ? a : b;
                var big = (a < b) ? b : a;
                return MultiplyExt(small, big);
            }

            private static int MultiplyExt(int small, int big)
            {
                if (small == 0) { return 0; }
                if (small == 1) { return big; }
                var halfProd = MultiplyExt(small >> 1, big);
                if (small % 2 == 0) { return halfProd + halfProd; }
                else { return halfProd + halfProd + big; }
            }
        }
    }
}
