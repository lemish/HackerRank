using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.GreedyAlgorithms
{
    /// <summary>
    /// Minimum Absolute Difference in an Array
    /// <see href="https://www.hackerrank.com/challenges/minimum-absolute-difference-in-an-array/"/>
    /// </summary>
    public class MinimumAbsoluteDifference
    {
        public static int GetMinimumAbsoluteDifference(int[] array)
        {
            var isArrayEmpty = array == null || !array.Any();
            if (isArrayEmpty)
            {
                return 0;
            }

            Array.Sort(array);

            var set = new SortedSet<int>();

            for (var index = 0; index + 1 < array.Length; index++)
            {
                var difference = array[index] - array[index + 1];
                var absoulteDifference = Math.Abs(difference);

                set.Add(absoulteDifference);
            }

            var absoluteMin = set.Min();
            return absoluteMin;
        }
    }
}
