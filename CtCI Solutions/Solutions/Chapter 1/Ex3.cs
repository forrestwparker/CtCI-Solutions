using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch1 // Chapter Number
    {
        public static class Ex3 // Exercise number
        {
            /* Exercise 1.3
             * 
             * URLify: Write a method to replace all spaces in a string with '%20'.
             * You may assume that the string has sufficient space at the end to hold the additional characters,
             * and that you are given the "true" length of the string.
             * (Note: If implementing in Java, please use a character array so that you can perform this operation in place.)
             * 
             * EXAMPLE
             * 
             * Input:   "Mr John Smith    ", 13
             * Output:  "Mr%20John%20Smith"
             */

            // Using char[] as strings in C# are immutable.
            // O(n) runtime, O(1) space
            public static void ReplaceSpaces(char[] array, int trueLength)
            {
                // Count the number of spaces in the "true" part of the string.
                var spaceCount = 0;
                for (int i = 0; i < trueLength; i++)
                {
                    if (array[i] == ' ') { spaceCount++; }
                }

                var pointer = trueLength;

                // The length of the expanded string is trueLength + 2 * spaceCount.
                // Copy characters from the end of the "true" part of the string to the end of the expanded string.
                // If a character is a space, overwrite that index and the two after with "%20", then decrement spaceCount by one.
                while (spaceCount > 0)
                {
                    pointer--;
                    if (array[pointer] != ' ') { array[pointer + 2 * spaceCount] = array[pointer]; }
                    else
                    {
                        array[pointer] = '%';
                        array[pointer + 1] = '2';
                        array[pointer + 2] = '0';
                        spaceCount--;
                    }
                }
            }
        }
    }
}
