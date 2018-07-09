using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch17 // Chapter Number
    {
        public static class Ex1 // Exercise number
        {
            /* Exercise 17.1
             * 
             * Add Without Plus: Write a function that adds two numbers.
             * You should not use + or any arithmetic operators.
             */

            // Assuming int32 arguments.
            // Assuming sum will not overflow/underflow.
            // Uses bitwise operations.
            // O(1) runtime, O(1) space
            public static int Add(int a, int b)
            {
                var initialSum = a ^ b;
                var initialCarryovers = (a & b) << 1;
                var secondarySum = initialSum ^ initialCarryovers;
                var secondaryCarryover = (initialSum & initialCarryovers) << 1;
                return secondarySum | secondaryCarryover;
            }
        }
    }
}
