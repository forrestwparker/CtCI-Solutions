﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch1 // Chapter Number
    {
        public static class Ex2 // Exercise number
        {
            /* Exercise 1.2
             * 
             * Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.
             */

            // Assumes source contains unicode 16-bit characters. (Matches char type in C#.)
            // O(|str1|) == O(|str2|) runtime (although O(1) if |str1| != |str2|), O(|str1|) == O(|str2|) space
            public static bool ArePermutations(string str1, string str2)
            {
                // If either string is null, throw exception.
                if (str1 == null) { throw new System.ArgumentNullException("str1"); }
                if (str2 == null) { throw new System.ArgumentNullException("str2"); }

                // If the strings are different lengths, they cannot be permutations.
                if (str1.Length != str2.Length) { return false; }

                var charCount = new Dictionary<char, int>();

                // Count the occurrances of each character in str1.
                foreach (var character in str1)
                {
                    if (charCount.ContainsKey(character)) { charCount[character]++; }
                    else { charCount.Add(character, 1); }
                }

                // Check that str2 contains exactly the same number of each character as str1.
                foreach (var character in str2)
                {
                    if (!charCount.ContainsKey(character) || charCount[character] == 0) { return false; }
                    charCount[character]--;
                }

                // str2 is a permutation of str1.
                return true;
            }
        }
    }
}
