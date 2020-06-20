using System;
using System.Linq;

namespace HackerRank.Sorting
{
    /// <summary>
    /// Mark and Toys
    /// <see href="https://www.hackerrank.com/challenges/mark-and-toys/"/>
    /// </summary>
    public class MarkAndToys
    {
        public static int MaximumToysByQuickSort(int[] toysPrices, int budget)
        {
            var isArrayEmpty = toysPrices == null || !toysPrices.Any();
            if (isArrayEmpty)
            {
                return 0;
            }

            var affordablePrices = toysPrices.Where(x => x < budget).ToArray();

            Array.Sort(affordablePrices);

            var toysCount = 0;
            foreach (var price in affordablePrices)
            {
                budget -= price;

                if (budget < 0)
                {
                    break;
                }

                toysCount++;
            }

            return toysCount;
        }

        public static int MaximumToysBySelectionSort(int[] toysPrices, int budget)
        {
            var toysCount = 0;
            for (var outerIndex = 0; outerIndex < toysPrices.Length - 1; outerIndex++)
            {
                var minIndex = outerIndex;
                for (var innerIndex = outerIndex + 1; innerIndex < toysPrices.Length; innerIndex++)
                {
                    if (toysPrices[innerIndex] < toysPrices[minIndex])
                    {
                        minIndex = innerIndex;
                    }
                }

                Swap(toysPrices, outerIndex, minIndex);

                budget -= toysPrices[outerIndex];
                if (budget < 0)
                {
                    break;
                }

                toysCount++;
            }

            return toysCount;
        }

        private static void Swap(int[] array, int aIndex, int bIndex)
        {
            if (aIndex == bIndex)
            {
                return;
            }

            var temporary = array[aIndex];
            array[aIndex] = array[bIndex];
            array[bIndex] = temporary;
        }
    }
}
