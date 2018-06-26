using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch17 // Chapter Number
    {
        public static class Ex2 // Exercise number
        {
            /* Exercise 17.2
             * 
             * Shuffle: Write a method to shuffle a deck of cards.
             * It must be a perfect shuffle -- in other words, each of the
             * 52! permutations of the deck has to be equally likely.
             * Assume that you are given a random number generator which is perfect.
             */

            // Using values 0-51 to represent the cards.
            public static int[] ShuffleDeck()
            {
                var deck = Enumerable.Range(0, 52).ToArray();
                var rng = new Random();
                for (int i = 0; i < 51; i++)
                {
                    var k = rng.Next(i, 52);
                    if (i != k)
                    {
                        var temp = deck[i];
                        deck[i] = deck[k];
                        deck[k] = temp;
                    }
                }
                return deck;
            }
        }
    }
}
