using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch8 // Chapter number
    {
        public static class Ex1 // Exercise number
        {
            /* Exercise 8.1
             * 
             * Triple Step: A child is running up a staircase with n steps and can hop either 1 step,
             * 2 steps, or 3 steps at a time.
             * Implement a method to count how many possible ways the child can run up the stairs.
             */

            // O(n) runtime, O(1) space
            public static int ClimbingCount(int numberOfStairs)
            {
                if (numberOfStairs <= 0) { throw new System.ArgumentOutOfRangeException("numberOfStairs", "must be positive"); }
                var ccArray = new int[] { 0, 0, 1 };
                for (int i = 1; i <= numberOfStairs; i++)
                {
                    var ccnew = ccArray.Sum();
                    Array.Copy(ccArray, 1, ccArray, 0, 2);
                    ccArray[2] = ccnew;
                }
                return ccArray[2];
            }
        }
    }
}
