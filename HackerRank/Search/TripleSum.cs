using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Search
{
    /// <summary>
    /// Triple sum
    /// <see href="https://www.hackerrank.com/challenges/triple-sum/"/>
    /// </summary>
    public class TripleSum
    {
        public static long Triplets(int[] a, int[] b, int[] c)
        {
            var isAEmpty = a == null || !a.Any();
            var isBEmpty = b == null || !b.Any();
            var isCEmpty = c == null || !c.Any();

            if (isAEmpty || isBEmpty || isCEmpty)
            {
                return 0;
            }

            Array.Sort(a);
            Array.Sort(b);
            Array.Sort(c);

            var bMax = b.Last();
            a = a.Where(x => x <= bMax).Distinct().ToArray();
            c = c.Where(x => x <= bMax).Distinct().ToArray();
            b = b.Distinct().ToArray();

            long tripletsCount = 0;

            foreach (var bElement in b)
            {
                const int elementNotFoundFlag = -1;
                var aElementIndex = BinarySearchIndexOfElementThatLessOrEqualThanValue(a, bElement);
                if (aElementIndex == elementNotFoundFlag)
                {
                    continue;
                }

                var cElementIndex = BinarySearchIndexOfElementThatLessOrEqualThanValue(c, bElement);
                if (cElementIndex == elementNotFoundFlag)
                {
                    continue;
                }

                var elementsCountInA = aElementIndex + 1;
                var elementsCountInC = cElementIndex + 1;

                var combinationsCount = Math.BigMul(elementsCountInA, elementsCountInC);

                tripletsCount += combinationsCount;
            }

            return tripletsCount;
        }

        public static int BinarySearchIndexOfElementThatLessOrEqualThanValue(int[] sortedArray, int value)
        {
            var startIndex = 0;
            var endIndex = sortedArray.Length - 1;
            var visitedValues = new HashSet<int>();

            while (true)
            {
                var middleIndex = (startIndex + endIndex) / 2;
                var middleValue = sortedArray[middleIndex];

                if (visitedValues.Contains(middleValue))
                {
                    var result = CycleSearchLessOrEqualThanValue(sortedArray, endIndex, value);
                    return result;
                }
                else
                {
                    visitedValues.Add(middleValue);
                }

                if (middleValue > value)
                {
                    endIndex = middleIndex;
                }
                else if (middleValue < value)
                {
                    startIndex = middleIndex;
                }
                else
                {
                    var result = CycleSearchLessOrEqualThanValue(sortedArray, endIndex, value);
                    return result;
                }
            }
        }

        public static int CycleSearchLessOrEqualThanValue(int[] sortedArray, int endIndex, int value)
        {
            for (var index = endIndex; index >= 0; index--)
            {
                var suggestedValue = sortedArray[index];
                if (suggestedValue <= value)
                {
                    return index;
                };
            }

            return -1;
        }
    }
}