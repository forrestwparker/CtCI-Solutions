using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch3 // Chapter Number
    {
        public static class Ex1 // Exercise number
        {
            /* Exercise 3.1
             * 
             * Three in One: Describe how you could use a single array to implement three stacks.
             */


            // Allows null objects to be pushed to the stack.
            // TriStack takes O(Max(|A|, |B|, |C|) space, where A, B, C are the three stacks.
            // 'Push' has O(1) amortized runtime. Runs longer when stackArray doesn't have enough room to add an item.
            // 'Pop', and 'Count' all O(1) runtime
            public class TriStack<T>
            {
                private T[] stackArray = new T[0];
                private readonly int[] stackTopAdjustedIndices = { -1, -1, -1 };

                public void Push(T item, int stackNumber)
                {
                    if (stackNumber < 0 || stackNumber > 2) { throw new System.ArgumentException("Stacknumber must be between 0 and 2."); }
                    stackTopAdjustedIndices[stackNumber]++;
                    var trueIndex = 3 * stackTopAdjustedIndices[stackNumber] + stackNumber;
                    if (trueIndex >= stackArray.Length) { DoubleSizeOfStackArray(); }
                    stackArray[trueIndex] = item;
                }

                public T Pop(int stackNumber)
                {
                    if (stackNumber < 0 || stackNumber > 2) { throw new System.ArgumentException("Stacknumber must be between 0 and 2."); }
                    if (stackTopAdjustedIndices[stackNumber] < 0) { throw new System.InvalidOperationException("Cannot Pop from an empty stack."); }
                    var trueIndex = 3 * stackTopAdjustedIndices[stackNumber] + stackNumber;
                    var item = stackArray[trueIndex];
                    stackArray[trueIndex] = default(T);
                    stackTopAdjustedIndices[stackNumber]--;
                    return item;
                }

                public int Count(int stackNumber)
                {
                    if (stackNumber < 0 || stackNumber > 2) { throw new System.ArgumentException("Stacknumber must be between 0 and 2."); }
                    return stackTopAdjustedIndices[stackNumber] + 1;
                }

                private void DoubleSizeOfStackArray()
                {
                    var newArray = new T[stackArray.Length];
                    stackArray.Concat(newArray);
                }
            }
        }
    }
}
