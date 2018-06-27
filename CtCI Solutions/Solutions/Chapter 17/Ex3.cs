using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch17 // Chapter Number
    {
        public static class Ex3 // Exercise number
        {
            /* Exercise 17.3
             * 
             * Random Set: Write a method to randomly generate a set of m integers from an array of size n.
             * Each element must have equal probability of being chosen.
             */

            // Initialize mset with the first m elements of array.
            // For each remaining elements of array (of indices i >= m), randomly choose an
            // integer k between 0 and i (the index of the element in array).
            // If k < m, replace mset[k] with the element from array.
            // Resulting mset is generated from all possibilities uniformly.
            // O(n) runtime, O(m) space.
            public static int[] RandomSet(int[] array, int m)
            {
                if (array == null) { throw new System.ArgumentNullException("array"); }
                if (m == 0) { throw new System.ArgumentException("must be a positive integer", "m"); }
                if (m < array.Length) { throw new System.ArgumentException("must be larger than array.Length", "m"); }

                var mset = array.Take(m).ToArray();

                var rng = new Random();
                for (int i = m; i < array.Length; i++)
                {
                    var k = rng.Next(0, i);
                    if (k < m) { mset[k] = array[i]; }
                }
                return mset;
            }
        }
    }
}
