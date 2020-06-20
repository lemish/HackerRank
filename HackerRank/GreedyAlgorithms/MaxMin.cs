using System;

namespace HackerRank.GreedyAlgorithms
{
    /// <summary>
    /// Max Min
    /// <see href="https://www.hackerrank.com/challenges/angry-children/"/>
    /// </summary>
    public class MaxMin
    {
        public static int GetDifferenceBetweenMaxAndMin(int numberOfElementsInSubarray, int[] array)
        {
            var isArrayEmpty = array == null || array.Length == 0;
            if (isArrayEmpty)
            {
                return 0;
            }

            var sortedArray = GetSortedArray(array);

            var globalMinimumElement = int.MaxValue;
            for (var i = 0; i <= array.Length - numberOfElementsInSubarray; i++)
            {
                var min = sortedArray[i];
                var max = sortedArray[i + numberOfElementsInSubarray - 1];

                var difference = max - min;
                if (difference < globalMinimumElement)
                {
                    globalMinimumElement = difference;
                }
            }

            return globalMinimumElement;
        }

        private static int[] GetSortedArray(int[] array)
        {
            var sortedArray = (int[])array.Clone();
            Array.Sort(sortedArray);

            return sortedArray;
        }
    }
}
