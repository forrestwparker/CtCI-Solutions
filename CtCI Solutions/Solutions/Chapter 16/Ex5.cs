using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch16 // Chapter Number
    {
        public static class Ex5 // Exercise number
        {
            /* Exercise 16.5
             * 
             * Factorial Zeros: Write an algorithm which computes the number of trailing zeros in n factorial.
             */
            
            // Count the total number of factors of five for all integers between 1 and n.
            // Do this by repeatedly dividing n by five, truncate the quotient, and add to count.
            // O(log n) runtime, O(1) space
            public static int ZerosInFactorial(int n)
            {
                if (n < 0) { throw new System.ArgumentOutOfRangeException("n", "Factorial is defined for non-negative numbers"); }
                if (n < 5) { return 0; }
                int count = 0;
                do
                {
                    n = n / 5;
                    count += n;
                } while (n >= 5);
                return count;
            }
        }
    }
}
