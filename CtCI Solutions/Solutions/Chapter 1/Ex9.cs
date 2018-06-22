using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch1 // Chapter Number
    {
        public static class Ex9 // Exercise number
        {
            /* Exercise 1.9
             * 
             * String Rotation: Assume you have a method 'isSubstring' which checks if one word is a substring of another.
             * Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one call to 'isSubstring'
             * (e.g., "waterbottle" is a rotation of "erbottlewat").
             */

            // Assume no null strings.
            // O(n * O(isSubstring)) runtime, o(n) space
            public static bool IsRotation(string str1, string str2)
            {
                // If the strings aren't the same length, they cannot be rotations of each other.
                if (str1.Length != str2.Length) { return false; }

                // 'Contains' is the C# version of 'isSubstring'.
                return (str1 + str1).Contains(str2);
            }
        }
    }
}
