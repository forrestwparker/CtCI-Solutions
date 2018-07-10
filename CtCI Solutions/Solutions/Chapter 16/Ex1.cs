using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch16 // Chapter Number
    {
        public static class Ex1 // Exercise number
        {
            /* Exercise 16.1
             * 
             * Number Swapper: Write a function to swap a number in place
             * (that is, without temporary variables).
             */

            public struct NumberSwapper
            {
                public int a;
                public int b;

                public void Swap()
                {
                    if (Math.Sign(a) == Math.Sign(b))
                    {
                        a = b - a;
                        b = b - a;
                        a = a + b;
                    }
                    else
                    {
                        a = a + b;
                        b = a - b;
                        a = a - b;
                    }
                }

                // Alternative method which requires no check for overflow
                public void Swap2()
                {
                    a = a ^ b;
                    b = a ^ b;
                    a = a ^ b;
                }
            }
        }
    }
}
