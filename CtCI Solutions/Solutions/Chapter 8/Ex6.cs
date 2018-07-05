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
        public static class Ex6 // Exercise number
        {
            /* Exercise 8.6
             * 
             * Towers of Hanoi: In the classic problem of the Towers of Hanoi,
             * you have 3 towers and N disks of different sizes which can slide onto any tower.
             * The puzzle starts with disks sorted in ascending order of size from top to bottom
             * (i.e., each disk sits on top of an even larger one).
             * You have the following constraints:
             * 
             * (1) Only one disk can be moved at a time.
             * (2) A disk is slid off the top of one tower onto another tower.
             * (3) A disk cannot be placed on top of a smaller disk.
             * 
             * Write a program to move the disks from the first tower to the last using stacks.
             */

            // Prints the directions, as desired.
            public static void TowersOfHanoi(int N)
            {
                if (N < 1) { throw new ArgumentOutOfRangeException("N", "must be positive"); }
                var enu = Enumerable.Range(1, N+1).Reverse();
                var source = new Tower("A", enu);
                var temp = new Tower("B");
                var destination = new Tower("C");
                TowersOfHanoi(N, source, temp, destination);
            }

            private static void TowersOfHanoi(int N, Tower source, Tower temp, Tower destination)
            {
                if (N != 1) { TowersOfHanoi(N - 1, source, destination, temp); }
                var disk = source.Pop();
                destination.Push(disk);
                Console.WriteLine("Move disk {0} from Tower {1} to Tower {2}", disk, source.Name, destination.Name);
                if (N != 1) { TowersOfHanoi(N - 1, temp, source, destination); }
            }

            // Ignoring possible errors
            private class Tower
            {
                private Stack<int> InternalStack;
                public string Name { get; private set; }

                public Tower(string name)
                {
                    Name = name;
                    InternalStack = new Stack<int>();
                }

                public Tower(string name, IEnumerable<int> fillstack)
                {
                    Name = name;
                    InternalStack = new Stack<int>(fillstack);
                }

                public void Push(int item)
                {
                    InternalStack.Push(item);
                }

                public int Pop()
                {
                    return InternalStack.Pop();
                }
            }
        }
    }
}
