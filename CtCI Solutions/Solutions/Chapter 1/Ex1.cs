using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions.Chapter_1
{
    static partial class Solution
    {
        /* Exercise 1
         * 
         * Is Unique: Implement an algorithm to determine if a string has all unique characters.
         * What if you cannot use additional data structures?
         */

        // Part 1
        // Assumes source contains unicode 16-bit characters. (Matches char type in C#.)
        // Assumes no null strings as input.
        // Returns true on empty strings (since no characters exist).
        // Arguably O(1) runtime (although O(n) for small n), O(n) space
        static bool ContainsUniqueChars(string source)
        {
            // If source contains more characters than the distinct allowable characters (65536), return false.
            if (source.Length > 65536) { return false; }

            // Flags to indicate if a character has occurred in source.
            var characterIsInSource = new BitArray(65536);

            // Check if each character in source has been encountered before. If so, return false. Else, flag its occurrance.
            foreach (var character in source)
            {
                var charValue = (int)Char.GetNumericValue(character);
                if (characterIsInSource[charValue] == true)
                {
                    return false;
                }
                characterIsInSource[charValue] = true;
            }

            // Every character is unique.
            return true;
        }

        // Part 2
        // Arguably O(1) runtime (although O(n^2) for small n), O(1) space
        static bool ContainsUniqueChars_NoExtraDataStructures(string source)
        {
            // If source contains more characters than the distinct allowable characters (65536), return false.
            if (source.Length > 65536) { return false; }

            // Compare every pair of characters in the string. If any are equal, return false.
            for (int i = 0; i < source.Length - 1; i++)
            {
                for (int j = i + 1; j < source.Length; j++)
                {
                    if (source[i] == source[j]) { return false; }
                }
            }

            // Every character is unique.
            return true;
        }
    }
}
