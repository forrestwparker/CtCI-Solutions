using CtCI_Solutions.Data_Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch4 // Chapter number
    {
        public static class Ex7 // Exercise number
        {
            /* Exercise 4.7
             * 
             * Build Order: You are given a list of projects and a list of dependencies
             * (which is a list of pairs of projects, where the second project is dependent
             * on the first project).
             * All of a project's dependencies must be built before the project is.
             * Find a build order that will allow the projects to be built.
             * If there is no valid build order, return an error.
             */

            // Assume no null arrays
            // Assume dependencies only contains valid projects
            // O(|projects| + |dependencies|) runtime, O(|projects| + |dependencies|) space
            public static char[] BuildOrder(char[] projects, Tuple<char,char>[] dependencies)
            {
                // Create set of projects and dependencies
                var remainingProjects = new HashSet<char>(projects);
                var remainingDependencies = new HashSet<Tuple<char, char>>(dependencies);

                // Create set of projects that are not dependent on any others
                var availableProjects = new HashSet<char>(remainingProjects);
                foreach (var dependency in dependencies)
                {
                    availableProjects.Remove(dependency.Item2);
                }

                // Remove all availableProjects from remainingProjects
                remainingProjects.ExceptWith(availableProjects);

                // Create dependency count dictionary
                var dependencyCount = new Dictionary<char, int>(remainingProjects.Count);
                foreach (var dependency in remainingDependencies)
                {
                    if (dependencyCount.ContainsKey(dependency.Item2)) { dependencyCount[dependency.Item2]++; }
                    else { dependencyCount[dependency.Item2] = 1; }
                }

                // Initialize build order array
                var buildOrderIndex = 0;
                var buildOrder = new char[projects.Length];

                while (availableProjects.Count != 0)
                {
                    var project = availableProjects.First();
                    availableProjects.Remove(project);
                    buildOrder[buildOrderIndex] = project;
                    buildOrderIndex++;

                    foreach (var dependency in remainingDependencies.ToArray())
                    {
                        if (dependency.Item1 == project)
                        {
                            var otherProject = dependency.Item2;
                            dependencyCount[otherProject]--;
                            if (dependencyCount[otherProject] == 0)
                            {
                                remainingProjects.Remove(otherProject);
                                availableProjects.Add(otherProject);
                                dependencyCount.Remove(otherProject);
                            }
                            remainingDependencies.Remove(dependency);
                        }
                    }
                }

                // If all projects have been placed in the build order, return the build order.
                // Otherwise, throw an exception.
                if (buildOrderIndex == buildOrder.Length) { return buildOrder; }
                else { throw new InvalidOperationException(); }
            }
        }
    }
}
