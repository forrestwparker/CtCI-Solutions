using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch16 // Chapter Number
    {
        public static class Ex10 // Exercise number
        {
            /* Exercise 16.10
             * 
             * Living People: Given a list of people with their birth year and death years, implement a method
             * to compute the year with the most number of people alive.
             * You may assume that all people were born between 1900 and 2000 (inclusive).
             * If a person was alive during any portion of that year, they should be included in that year's count.
             * For example, Person (birth = 1908, death = 1909) is included in the counts for both 1908 and 1909.
             */

            // O(n log n) runtime (due to sorting), O(n) space
            // Other "optimal" solutions exist which depend on range of birth and death years,
            // but may be shorter or longer than this one.
            public static int MostAlive(Person[] people)
            {
                // Exceptions
                if (people == null) { throw new System.ArgumentNullException(); }
                if (people.Length == 0) { throw new System.ArgumentException("Must have at least one person"); }

                // Sort births and deaths into own arrays.
                var births = people.Select(x => x.BirthYear).OrderBy(x => x).ToArray();
                var deaths = people.Select(x => x.DeathYear).OrderBy(x => x).ToArray();

                // Set up variables
                var birthPointer = 0;
                var deathPointer = 0;
                var aliveCount = 0;
                var max = 0;
                var maxYear = births[0];

                // Only need to iterate to end of births to find max alive year.
                while (birthPointer < births.Length)
                {
                    // Births occur before deaths in same year, so birth <= death counts for birth first.
                    if (births[birthPointer] <= deaths[deathPointer])
                    {
                        aliveCount++;
                        if (aliveCount > max)
                        {
                            max = aliveCount;
                            maxYear = births[birthPointer];
                        }
                        birthPointer++;
                    }
                    else
                    {
                        aliveCount--;
                        deathPointer++;
                    }
                }
            }

            public struct Person
            {
                public int BirthYear;
                public int DeathYear;
            }
        }
    }
}
