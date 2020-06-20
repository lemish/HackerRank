using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Arrays
{
    /// <summary>
    /// Minimum Swaps 2
    /// <see href="https://www.hackerrank.com/challenges/minimum-swaps-2/"/>
    /// </summary>
    public class MinimumSwaps2
    {
        public static int MinimumSwaps(int[] array)
        {
            if (array == null || !array.Any())
            {
                return 0;
            }

            var dictionary = array.Select((number, index) => new { number, index })
                                  .ToDictionary(x => x.number, x => x.index);

            var swapsCount = 0;
            for (var index = 0; index < array.Length; index++)
            {
                var expectedValue = index + 1;
                if (expectedValue == array[index])
                {
                    continue;
                }

                var indexOfExpectedValue = dictionary[expectedValue];
                Swap(array, dictionary, indexOfExpectedValue, index);
                swapsCount++;
            }

            return swapsCount;
        }

        static void Swap(int[] array, Dictionary<int, int> dictionary, int expectedIndex, int currentIndex)
        {
            var temp = array[expectedIndex];
            array[expectedIndex] = array[currentIndex];
            array[currentIndex] = temp;

            dictionary[array[expectedIndex]] = expectedIndex;
            dictionary[array[currentIndex]] = currentIndex;
        }
    }
}
