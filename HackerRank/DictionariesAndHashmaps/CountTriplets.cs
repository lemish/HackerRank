using System.Collections.Generic;

namespace HackerRank.DictionariesAndHashmaps
{
    /// <summary>
    /// Count Triplets
    /// <see href="https://www.hackerrank.com/challenges/count-triplets-1/"/>
    /// </summary>
    public class CountTriplets
    {
        public static long countTriplets(List<long> arr, long ratio)
        {
            var isArrayEmpty = arr == null || arr.Count == 0;
            if (isArrayEmpty)
            {
                return 0;
            }

            long numberOfTriplets = 0;

            var right = new Dictionary<long, long>();
            var left = new Dictionary<long, long>();

            foreach (var arrayNumber in arr)
            {
                if (!right.ContainsKey(arrayNumber))
                {
                    right.Add(arrayNumber, 1);
                    left.Add(arrayNumber, 0);
                }
                else
                {
                    right[arrayNumber] += 1;
                }
            }

            foreach (var arrayNumber in arr)
            {
                right[arrayNumber] -= 1;

                if (arrayNumber % ratio == 0)
                {
                    var number1 = arrayNumber / ratio;
                    var number3 = arrayNumber * ratio;

                    if (left.ContainsKey(number1) && right.ContainsKey(number3))
                    {
                        var leftNumber1 = left[number1];
                        var leftNumber3 = right[number3];
                        var multiplationResult = leftNumber1 * leftNumber3;

                        numberOfTriplets += multiplationResult;
                    }
                }

                left[arrayNumber] += 1;
            }


            return numberOfTriplets;
        }
    }
}
