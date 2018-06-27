using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch17 // Chapter Number
    {
        public static class Ex9 // Exercise number
        {
            /* Exercise 17.9
             * 
             * Kth Multiple: Design an algorithm to find the kth number
             * such that the only prime factors are 3, 5, and 7.
             * Note that 3, 5 ,and 7 do not have to be factors, but it
             * should not have any other prime factors.
             * For example, the first several multiples would be (in order)
             * 1, 3, 5, 7, 9, 15, 21.
             */

            // Assume 1 is first multiple (i.e. K = 1).
            public static int KthMultiple(int K)
            {
                var q3 = new Queue<int>();
                var q5 = new Queue<int>();
                var q7 = new Queue<int>();
                q3.Enqueue(1);
                var val = 0;

                for (int i = 0; i < K; i++)
                {
                    int v3 = q3.Peek();
                    int v5 = (q5.Count > 0) ? q5.Peek() : int.MaxValue;
                    int v7 = (q7.Count > 0) ? q7.Peek() : int.MaxValue;

                    val = Math.Min(v3, Math.Min(v5, v7));
                    if (i == K-1) { return val; }

                    else if (val == v3)
                    {
                        q3.Dequeue();
                        q3.Enqueue(3 * val);
                        q5.Enqueue(5 * val);
                    }
                    else if (val == v5)
                    {
                        q5.Dequeue();
                        q5.Enqueue(5 * val);
                    }
                    else
                    {
                        q7.Dequeue();
                    }
                    q7.Enqueue(7 * val);
                }

                return val;
            }
        }
    }
}
