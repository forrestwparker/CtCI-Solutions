using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch17 // Chapter Number
    {
        public static class Ex21 // Exercise number
        {
            /* Exercise 17.21
             * 
             * Volume of Histogram: Imagine a histogram (bar graph).
             * Design an algorithm to comput the volume of water it could hold
             * if someone poured water across the top.
             * You can assume that each histogram bar has width 1.
             * 
             * EXAMPLE
             * 
             * Input:   {0, 0, 4, 0, 0, 6, 0, 0, 3, 0, 5, 0, 1, 0, 0, 0}
             * Output:  26
             */

            // Moving pointers from both sides towards center.
            // Choose pointer to smaller height.
            // Add volumes at each step until pointer hits next bar of height
            // greater than or equal to previously hit highest bar.
            // Repeat moving pointer at smaller height until
            // both pointers meet at highest bar in histogram.
            // O(n) runtime, O(1) space
            public static int Volume(int[] histogram)
            {
                // Exceptions and base cases.
                if (histogram == null) { throw new ArgumentNullException(); }
                if (histogram.Length < 2) { return 0; }
                
                // Initialize needed variables
                var volume = 0;
                var leftIndex = 0;
                var leftHeight = histogram[leftIndex];
                var rightIndex = histogram.Length - 1;
                var rightHeight = histogram[rightIndex];
                
                // Calculate volume
                while (leftIndex != rightIndex)
                {
                    if (leftHeight <= rightHeight) { volume += AddVolume(histogram, ref leftIndex, ref leftHeight, 1); }
                    else { volume += AddVolume(histogram, ref rightIndex, ref rightHeight, -1); }
                }

                return volume;
            }

            private static int AddVolume(int[] histogram, ref int index, ref int height, int direction)
            {
                var volume = 0;
                index += direction;
                while (histogram[index] < height)
                {
                    volume += height - histogram[index];
                    index += direction;
                }
                height = histogram[index];
                return volume;
            }
        }
    }
}
