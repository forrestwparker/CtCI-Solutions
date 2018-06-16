using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch1
    {
        public static class Ex4
        {
            /* Exercise 1.4
             * 
             * Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
             * A palindrome is a word or phrase that is the same forwards and backwards.
             * A permutation is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words.
             * 
             * EXAMPLE
             * 
             * Input:   Tact Coa
             * Output:  True (permutations: "taco cat", "atco cta", etc.)
             */

            // Assumes the string contains only spaces and letters of the English alphabet, either upper or lower case.
            // Assumes no null strings as input.
            // Returns true on empty strings (since no characters exist).
            // O(n) runtime, O(1) space
            public static bool IsPalindromePermutation(string str)
            {
                // We only require 26 bits (one for each letter of the English alphabet).
                // Each bit is set to zero initially.
                var charParityVector = new BitVector32(0);

                // Masks used to access individual bits in charParityVector
                var vectorMasks = new Int32[26];
                vectorMasks[0] = BitVector32.CreateMask();
                for (int i = 1; i < 26; i++)
                {
                    vectorMasks[i] = BitVector32.CreateMask(vectorMasks[i - 1]);
                }

                // For every non-space character, assign a unique bit in charParityVector.
                // For a palindrome, we simply check that at most one character occurs an odd number of times in str.
                // str.ToLower() is called to make our parity check case-insensitive.
                foreach (var character in str.ToLower())
                {
                    if (character != ' ')
                    {
                        var adjustedCharValue = ((int)character) % 26;
                        var charValueVectorMask = vectorMasks[adjustedCharValue];
                        charParityVector[charValueVectorMask] = (charParityVector[charValueVectorMask] == false) ? true : false;
                    }
                }

                // Any character with odd parity sets it's corresponding bit in charParityVector to 1.
                // To check that at most one 1 occurs, subtract 1 from the vector (as an int), then bitwise & with its original value.
                // If the result is zero, then at most one bit was set to 1.
                return (charParityVector.Data & (charParityVector.Data - 1)) == 0;
            }
        }
    }
}
