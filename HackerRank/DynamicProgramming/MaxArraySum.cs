using System;

namespace HackerRank.DynamicProgramming
{
    /// <summary>
    /// Max Array Sum
    /// <see href="https://www.hackerrank.com/challenges/max-array-sum/"/>
    /// </summary>
    public class MaxArraySum
    {
        public static int MaxSubsetSum(int[] arr)
        {
            var isArrayEmpty = arr == null || arr.Length == 0;
            if (isArrayEmpty)
            {
                return 0;
            }

            var isArrayContainsOneElement = arr.Length == 1;
            if (isArrayContainsOneElement)
            {
                return arr[0];
            }

            var max = Math.Max(arr[0], arr[1]);
            arr[1] = max;

            for (var index = 2; index < arr.Length; index++)
            {
                var previousNonAdjacentElement = arr[index - 2];
                var currentElement = arr[index];

                var sumOfCurrentAndPrevious = previousNonAdjacentElement + currentElement;

                // If sum of current and previous elements greater than max
                max = Math.Max(sumOfCurrentAndPrevious, max);

                // If current element greater than sum of previous elements
                max = Math.Max(currentElement, max);

                arr[index] = max;
            }

            return max;
        }
    }
}
