using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch17 // Chapter Number
    {
        public static class Ex19 // Exercise number
        {
            /* Exercise 17.19
             * 
             * Missing Two: You are given an array with all the numbers from 1 to N appearing exactly once,
             * except for one number that is missing.
             * How can you find the missing number in O(N) time and O(1) space?
             * What if there were two numbers missing?
             */

            // Finds the full sum of 1 to N, then subtracts the sum of values in array.
            public static int FindMissingNumber(int[] array)
            {
                if (array == null) { throw new System.ArgumentNullException(); }
                if (array.Length == 0) { return 1; }
                var N = array.Length + 1;
                var sum = new BigInteger(0);
                foreach (var value in array)
                {
                    sum += value;
                }
                BigInteger fullSum = (BigInteger.Pow(N, 2) + N) / 2;
                return (int)(fullSum - sum);
            }

            // Finds the sum s and product p of the missing values by calculating the
            // sum and product of 1 to N and subtracts (resp. divides) the sum and product
            // of values in array.
            // The missing values are s/2 +- sqrt(s^2/4 - p).
            public static int[] FindMissingNumbers(int[] array)
            {
                if (array == null) { throw new System.ArgumentNullException(); }
                if (array.Length == 0) { return new int[] { 1, 2 }; }

                var N = array.Length + 2;
                var arraySum = new BigInteger(0);
                var arrayProduct = new BigInteger(1);

                foreach (var value in array)
                {
                    arraySum += value;
                    arrayProduct *= value;
                }

                // Full sum and product of integers from 1 to N.
                BigInteger fullSum = (BigInteger.Pow(N, 2) + N) / 2;
                BigInteger fullProduct = BigIntegerFactorial(N);

                // Sum and product of the missing integers from array.
                var s = (double)(fullSum - arraySum);
                var p = (double)(fullProduct / arrayProduct);

                var halfs = s / 2;

                return new int[]
                {
                    (int)(halfs - Math.Sqrt(Math.Pow(halfs, 2) / 4 - p)),
                    (int)(halfs + Math.Sqrt(Math.Pow(halfs, 2) / 4 - p))
                };
            }

            // Returns n-factorial as a BigInteger.
            private static BigInteger BigIntegerFactorial(int n)
            {
                if (n < 0) { throw new System.ArgumentException("must be nonnegative"); }
                var product = new BigInteger(1);
                for (int k = 2; k <= n; k++)
                {
                    product *= k;
                }
                return product;
            }
        }
    }
}
