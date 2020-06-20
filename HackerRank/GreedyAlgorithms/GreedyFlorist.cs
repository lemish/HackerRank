using System;
using System.Linq;

namespace HackerRank.GreedyAlgorithms
{
    /// <summary>
    /// Greedy Florist
    /// <see href="https://www.hackerrank.com/challenges/greedy-florist/"/>
    /// </summary>
    public class GreedyFlorist
    {
        public static int GetMinimumCost(int numberOfFriends, int[] originalPricesOfFlowers)
        {
            var isArrayEmpty = originalPricesOfFlowers == null || !originalPricesOfFlowers.Any();
            if (isArrayEmpty)
            {
                return 0;
            }

            var sortedPricesOfFlowers = GetSortedArray(originalPricesOfFlowers);

            var minimumCostOfAllFlowers = 0;
            var countOfPurchases = 0;
            const int originalCharge = 1;

            foreach (var originalPrice in sortedPricesOfFlowers)
            {
                var friendExtraCharge = originalCharge + countOfPurchases / numberOfFriends;
                var currentPriceForFriend = originalPrice * friendExtraCharge;

                minimumCostOfAllFlowers += currentPriceForFriend;
                countOfPurchases++;
            }

            return minimumCostOfAllFlowers;
        }

        private static int[] GetSortedArray(int[] array)
        {
            var sortedArray = (int[])array.Clone();
            Array.Sort(sortedArray);
            sortedArray = sortedArray.Reverse().ToArray();

            return sortedArray;
        }
    }
}
