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
        public static class Ex4 // Exercise number
        {
            /* Exercise 8.4
             * 
             * Power Set: Write a method to return all subsets of a set.
             */

            // O(n*2^n) runtime, O(n*2^n) space (No better bounds possible)
            public static HashSet<HashSet<T>> Powerset<T>(HashSet<T> set)
            {
                if (set == null) { throw new ArgumentNullException(); }
                var powerset = new HashSet<HashSet<T>>();
                powerset.Add(new HashSet<T>());
                foreach (var element in set)
                {
                    var pstemp = new HashSet<HashSet<T>>(powerset);
                    foreach (var subset in pstemp)
                    {
                        var temp = new HashSet<T>(subset);
                        temp.Add(element);
                        powerset.Add(temp);
                    }
                }
                return powerset;
            }
        }
    }
}
