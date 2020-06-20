using System;
using System.Linq;

namespace HackerRank.Search
{
    /// <summary>
    /// Minimum Time Required
    /// <see href="https://www.hackerrank.com/challenges/minimum-time-required/"/>
    /// </summary>
    public class MinimumTimeRequired
    {
        public static long MinimumTime(long[] machines, long goal)
        {
            var isArrayEmpty = machines == null || !machines.Any();
            if (isArrayEmpty)
            {
                return 0;
            }

            Array.Sort(machines);

            var minimumDaysToReachGoal = machines.First();
            var maximumDaysToReachGoal = machines.Last() * goal;

            var result = FindMinimumTime(machines, goal, minimumDaysToReachGoal, maximumDaysToReachGoal);
            return result;
        }

        private static long FindMinimumTime(long[] machines, long productionGoal, long minDaysToGoal, long maxDaysToGoal)
        {
            if (machines.Length == 1)
            {
                return maxDaysToGoal;
            }

            if (minDaysToGoal == maxDaysToGoal)
            {
                return minDaysToGoal;
            }

            var averageDaysCount = (minDaysToGoal + maxDaysToGoal) / 2;
            var currentValueOfProduction = machines.Aggregate(0,
                (long productionsCount, long machinePower) => productionsCount += averageDaysCount / machinePower);

            if (currentValueOfProduction >= productionGoal)
            {
                return FindMinimumTime(machines, productionGoal, minDaysToGoal, averageDaysCount);
            }
            else
            {
                return FindMinimumTime(machines, productionGoal, averageDaysCount + 1, maxDaysToGoal);
            }
        }
    }
}