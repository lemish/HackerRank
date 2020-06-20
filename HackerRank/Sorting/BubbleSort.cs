using System;
using System.Linq;

namespace HackerRank.Sorting
{
    /// <summary>
    /// Sorting: Bubble Sort
    /// <see href="https://www.hackerrank.com/challenges/ctci-bubble-sort/"/>
    /// </summary>
    public class BubbleSort
    {
        public static void CountSwaps(int[] array)
        {
            var isArrayEmpty = array == null || !array.Any();
            if (isArrayEmpty)
            {
                return;
            }

            var swapsCount = 0;

            for (var i = 0; i < array.Length; i++)
            {
                for (var index = 0; index < array.Length - 1; index++)
                {
                    var nextIndex = index + 1;

                    if (array[index] > array[nextIndex])
                    {
                        Swap(array, index, nextIndex);
                        swapsCount++;
                    }
                }
            }

            Console.WriteLine($"Array is sorted in {swapsCount} swaps.");
            Console.WriteLine($"First Element: {array.FirstOrDefault()}");
            Console.WriteLine($"Last Element: {array.LastOrDefault()}");
        }

        private static void Swap(int[] array, int aIndex, int bIndex)
        {
            var temporary = array[aIndex];
            array[aIndex] = array[bIndex];
            array[bIndex] = temporary;
        }
    }
}
