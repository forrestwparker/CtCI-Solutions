using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch17 // Chapter Number
    {
        public static class Ex4 // Exercise number
        {
            /* Exercise 17.4
             * 
             * Missing Number: An array A contains all the integers from 0 to n,
             * except for one number which is missing.
             * The elements of A are represented in binary,
             * and the only operation we can use to access them is
             * "fetch the jth bit of A[i]," which takes constant time.
             * Write code to find the missing integer.
             * Can you do it in O(n) time?
             */

            // O(n) runtime, O(1) space.
            public static int MissingNumber(int[] inputArray)
            {
                if (inputArray == null) { throw new ArgumentNullException(); }

                // Embeds inputArray in BinaryArray to allow only reading of individual bits
                var array = new BinaryArray(inputArray);

                var n = array.Length;
                var maxBinaryDigit = (int)Math.Log(n, 2);
                var missingNumber = 0;
                for (int digit = 0; digit <= maxBinaryDigit; digit++)
                {
                    var bit = GetParityBit(n, digit);
                    for (int index = 0; index < array.Length; index++) { bit ^= array.GetBit(index, digit); }
                    missingNumber |= bit << digit;
                }
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

            private class BinaryArray
            {
                private int[] Array;
                public int Length { get { return Array.Length; } }

                public BinaryArray(int[] array)
                {
                    Array = array;
                }

                public int GetBit(int index, int bit)
                {
                    if (index >= Array.Length) { throw new ArgumentOutOfRangeException("index", "Must be between 0 and the length of the array"); }
                    if (bit < 0 || bit >= 32) { throw new ArgumentOutOfRangeException("bit", "Must be an integer between 0 and 31"); }

                    return (Array[index] & (1 << bit)) >> bit;
                }
            }
        }
    }
}
