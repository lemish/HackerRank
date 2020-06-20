using System;

namespace HackerRank.Sorting
{
    /// <summary>
    /// Merge Sort: Counting Inversions.
    /// <see href="https://www.hackerrank.com/challenges/ctci-merge-sort/"/>
    /// </summary>
    public class MergeSort
    {
        public static long CountInversions(int[] array)
        {
            var isArrayEmpty = array == null || array.Length == 0;
            if (isArrayEmpty)
            {
                return 0;
            }

            var middleIndex = array.Length >> 1;
            var leftPartOfArray = new int[middleIndex];
            Array.Copy(array, 0, leftPartOfArray, 0, middleIndex);

            var rightPartOfArray = new int[array.Length - middleIndex];

            var range = array.Length - middleIndex;
            Array.Copy(array, middleIndex, rightPartOfArray, 0, range);

            var inversionsCount = CountInversions(leftPartOfArray) + CountInversions(rightPartOfArray);

            var leftIndex = 0;
            var rightIndex = 0;

            for (var i = 0; i < array.Length; i++)
            {
                if (leftIndex < middleIndex &&
                    (rightIndex >= range || leftPartOfArray[leftIndex] <= rightPartOfArray[rightIndex]))
                {
                    array[i] = leftPartOfArray[leftIndex++];
                    inversionsCount += rightIndex;
                }
                else if (rightIndex < range)
                {
                    array[i] = rightPartOfArray[rightIndex++];
                }
            }

            return inversionsCount;
        }
    }
}
