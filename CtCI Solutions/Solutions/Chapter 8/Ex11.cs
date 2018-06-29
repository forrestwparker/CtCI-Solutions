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
        public static class Ex11 // Exercise number
        {
            /* Exercise 8.11
             * 
             * Coins: Given an infinite number of quarters (25 cents), dimes (10 cents), nickels (5 cents), and pennies (1 cent),
             * write code to calculate the number of ways of representing n cents.
             */

            // Written more generally to allow to any collection of distinct positive denominations.
            public static int Change(int amount, int[] denoms)
            {
                // If no denominations given, throw error.
                if (denoms == null) { throw new ArgumentNullException("denoms"); }
                if (denoms.Length == 0) { throw new ArgumentException("must contain at least one denomination", "denoms"); }
                foreach (var denom in denoms)
                {
                    if (denom <= 0) { throw new System.ArgumentOutOfRangeException("denoms", "all denoms must be positive"); }
                }
                var denomSet = new HashSet<int>(denoms);
                if (denomSet.Count != denoms.Length) { throw new ArgumentException("must contain distinct values","denoms"); }
                if (amount < 0) { throw new System.ArgumentException("amount", "must be nonnegative"); }

                // mem structure: mem[amount][index] == # ways (if calculated)
                var mem = new Dictionary<int, Dictionary<int, int>>();
                return Change(amount, denoms, 0, mem);
            }

            private static int Change(int amount, int[] denoms, int index, Dictionary<int, Dictionary<int, int>> mem)
            {
                // If the number of ways to is in mem, return that value.
                if (mem.ContainsKey(amount) && mem[amount].ContainsKey(index)) { return mem[amount][index]; }

                // If index points to the end of denoms, determine if amount is divisible by denoms[index].
                // If so, return 1. Else, return 0.
                if (index == denoms.Length - 1)
                {
                    // Initialize dictionary for mem[amount] if not already present.
                    if (!mem.ContainsKey(amount)) { mem[amount] = new Dictionary<int, int>(); }
                    var ways = (amount % denoms[index] == 0) ? 1 : 0;
                    mem[amount][index] = ways;
                    return ways;
                }

                // Otherwise, determine the number of ways to make change for amount using each
                // the possible number of coins with values in denoms of indices >= index
                else
                {
                    var ways = 0;
                    for (int k = 0; k <= amount / denoms[index]; k++)
                    {
                        ways += Change(amount - k * denoms[index], denoms, index + 1, mem);
                    }
                    mem[amount][index] = ways;
                    return ways;
                }
            }
        }
    }
}
