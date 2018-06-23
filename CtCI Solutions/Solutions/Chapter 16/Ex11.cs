using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch16 // Chapter Number
    {
        public static class Ex11 // Exercise number
        {
            /* Exercise 16.11
             * 
             * Diving Board: You are building a diving board by placing a bunch of planks of wood end-to-end.
             * There are two types of planks, one of length 'shorter' and one of length 'longer'.
             * You must use exactly K planks of wood.
             * Write a method to generate all possible lengths for the diving board.
             */

            // Use basic algebra.
            // Dynamic programming unnecessary because order of the planks doesn't matter.
            // O(K) runtime, O(K) space
            public static double[] GenerateDivingBoardLengths(int numberOfPlanks, double plankLength1, double plankLength2)
            {
                // Throw exception if anything doesn't make sense.
                if (numberOfPlanks < 0) { throw new System.ArgumentOutOfRangeException("numberOfPlanks", "Number of planks must be non-negative."); }
                if (plankLength1 <= 0) { throw new System.ArgumentOutOfRangeException("shorterLength", "Plank length must be a positive value."); }
                if (plankLength2 <= 0) { throw new System.ArgumentOutOfRangeException("longerLength", "Plank length must be a positive value."); }
                if (plankLength1 == plankLength2) { throw new System.ArgumentException("Possible plank lengths must not be equal."); }

                // There are K+1 possible lengths of diving board.
                var possibleBoardLengths = new double[numberOfPlanks + 1];

                // To be nice, the possible lengths will be returned in increasing value.
                var shorter = (plankLength1 > plankLength2) ? plankLength2 : plankLength1;
                var longer = (plankLength1 > plankLength2) ? plankLength1 : plankLength2;

                // Algebra.
                for (int k = 0; k <= numberOfPlanks; k++) { possibleBoardLengths[k] = k * longer + (numberOfPlanks - k) * shorter; }

                return possibleBoardLengths;
            }

        }
    }
}
