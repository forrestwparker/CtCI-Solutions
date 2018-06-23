using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch16 // Chapter Number
    {
        public static class Ex23 // Exercise number
        {
            /* Exercise 16.23
             * 
             * Rand7 from Rand5: Implement a method 'rand7()' given 'rand5()'.
             * That is, given a method that generates a random number between 0 and 4 (inclusive),
             * write a method that generates a random number between 0 and 6 (inclusive).
             */

            // Indeterminate runtime, O(1) space
            public static int Rand7()
            {
                int placeholder;
                do { placeholder = 5 * Rand5() + Rand5(); } while (placeholder > 21);
                return placeholder % 7;
            }

            // Simulates Rand5.
            // rng assigned the first time Rand5 is called.
            private static Random rng = null;
            private static int Rand5()
            {
                if (rng == null) { rng = new Random(); }
                return rng.Next(0, 5);
            }
        }
    }
}
