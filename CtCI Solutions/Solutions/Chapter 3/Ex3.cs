using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch3 // Chapter Number
    {
        public static class Ex3 // Exercise number
        {
            /* Exercise 3.3
             * 
             * Stack of Plates: Imagine a (literal) stack of plates.
             * If the stack gets too high, it might topple.
             * Therefore, in real life, we would likely start a new stack when
             * the previous stack exceeds some theshold.
             * Implement a data structure 'SetOfStacks' that mimics this.
             * 'SetOfStacks' should be composed of several stacks and should create
             * a new stack once the previous one exceeds capacity.
             * 'SetOfStacks.push()' and 'SetOfStacks.pop()' should behave identically
             * to a single stack (that is, 'pop()' should return the same values as it
             * would if there were just a single stack).
             * 
             * FOLLOW UP
             * 
             * Implement a function 'popAt(int index)' which performs a pop operation on a specific sub-stack.
             */

            public class SetOfStacks<T>
            {
                private readonly List<Stack<T>> stackList = new List<Stack<T>> { };
                private readonly int stackThreshold = 5;
                public int Count { get; private set; } = 0;

                private int stackIndexOfTop = -1;

                public void Push(T item)
                {
                    if (
                        stackIndexOfTop < 0
                        || (stackList.Count > stackIndexOfTop && stackList[stackIndexOfTop].Count >= stackThreshold)
                        )
                    {
                        stackIndexOfTop++;
                    }
                    if (stackList.Count <= stackIndexOfTop) { stackList.Add(new Stack<T>()); }
                    stackList[stackIndexOfTop].Push(item);
                    Count++;
                }

                public T Pop()
                {
                    if (stackIndexOfTop < 0) { throw new System.InvalidOperationException("Cannot pop from an empty stack."); }
                    var item = stackList[stackIndexOfTop].Pop();
                    Count--;
                    SetTopOfStackIndex(stackIndexOfTop);
                    return item;
                }

                public T PopAt(int index)
                {
                    if (index > stackIndexOfTop) { throw new System.ArgumentOutOfRangeException("index", "Cannot pop from nonexistant stack."); }
                    T item;
                    try
                    {
                        item = stackList[index].Pop();
                    }
                    catch (Exception ex) { throw new System.InvalidOperationException("Cannot pop from an empty stack", ex); }
                    Count--;
                    SetTopOfStackIndex(index);
                    return item;
                }

                private void SetTopOfStackIndex(int indexPoppedFrom)
                {
                    if (indexPoppedFrom == stackIndexOfTop)
                    {
                        while (stackIndexOfTop >= 0 && stackList[stackIndexOfTop].Count == 0) { stackIndexOfTop--; }
                    }
                }
            }
        }
    }
}
