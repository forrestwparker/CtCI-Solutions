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

            // Alternate solution which should run faster than previous one by
            // making BigInteger class unnecessary.
            // Uses copied code from Ex 17.4 (which inspired this solution).
            public static int FindMissingNumber2(int[] array)
            {
                if (array == null) { throw new ArgumentNullException(); }

                var n = array.Length + 1;
                var maxBinaryDigit = (int)Math.Log(n, 2);
                var missingNumber = 0;

                for (int digitPlace = 0; digitPlace <= maxBinaryDigit; digitPlace++)
                {
                    missingNumber |= GetParityBit(n, digitPlace) << digitPlace;
                }

                foreach (var value in array) { missingNumber ^= value; }
                return missingNumber;
            }

            private static int GetParityBit(int n, int digitPlace)
            {
                if (n < 0) { throw new ArgumentOutOfRangeException("n", "must be nonnegative"); }
                if (digitPlace < 0 || digitPlace > 31) { throw new ArgumentOutOfRangeException("digitPlace", "must be an integer between 0 and 31, inclusive"); }

                if (digitPlace == 0)
                {
                    // For units digit, if n % 4 == 1 or 2, return 1.
                    // Else, return 0.
                    var nMod4 = n % 4;
                    if (nMod4 == 1 || nMod4 == 2) { return 1; }
                    else { return 0; }
                }

                // If digitPlace != 0 and n is even.
                else if (n % 2 == 0)
                {
                    // Fast power of 2.
                    var PowerOf2 = 1 << digitPlace;
                    var nModP2plus1 = n % (PowerOf2 << 1);
                    // If nModP2plus1 >= PowerOf2, return 1.
                    // Else, return 0.
                    return nModP2plus1 / PowerOf2;
                }

                // In all other cases, return 0.
                else
                {
                    return 0;
                }
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
