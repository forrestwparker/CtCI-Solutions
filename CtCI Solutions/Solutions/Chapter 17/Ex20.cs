using CtCI_Solutions.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch17 // Chapter Number
    {
        public static class Ex20 // Exercise number
        {
            /* Exercise 17.20
             * 
             * Continuous Median: Numbers are randomly generated and passed to a method.
             * Write a program to find and maintain the median value as new values are generated.
             */

            // Assuming int32 values.
            public class ContinuousMedian
            {
                private Heap<double> LowerHeap = new Heap<double>((x, y) => x > y);
                private Heap<double> UpperHeap = new Heap<double>((x, y) => x < y);
                public int Count
                {
                    get { return LowerHeap.Count + UpperHeap.Count; }
                }
                public bool IsEmpty
                {
                    get { return LowerHeap.IsEmpty && UpperHeap.IsEmpty; }
                }
                
                public void Insert(double k)
                {
                    if (Count == 0) { LowerHeap.Add(k); }
                    else
                    {
                        if (k < LowerHeap.Peek()) { LowerHeap.Add(k); }
                        else if (UpperHeap.IsEmpty || k > UpperHeap.Peek()) { UpperHeap.Add(k); }
                        else
                        {
                            var heap = (LowerHeap.Count <= UpperHeap.Count) ? LowerHeap : UpperHeap;
                            heap.Add(k);
                        }
                        BalanceHeaps();
                    }
                }

                public double Median()
                {
                    if (IsEmpty) { throw new Exception("No numbers present"); }
                    if (LowerHeap.Count > UpperHeap.Count) { return LowerHeap.Peek(); }
                    if (LowerHeap.Count < UpperHeap.Count) { return UpperHeap.Peek(); }
                    return (UpperHeap.Peek() + LowerHeap.Peek()) / 2;
                }

                private void BalanceHeaps()
                {
                    var small = (LowerHeap.Count < UpperHeap.Count) ? LowerHeap : UpperHeap;
                    var big = (LowerHeap.Count < UpperHeap.Count) ? UpperHeap : LowerHeap;
                    while (Math.Abs(small.Count - big.Count) > 1) { small.Add(big.Extract()); }
                }
            }
            
        }
    }
}
