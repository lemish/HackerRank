using System.Linq;

namespace HackerRank.WarmUpChallenges
{
    /// <summary>
    /// Sock Merchant
    /// <see href="https://www.hackerrank.com/challenges/sock-merchant/"/>
    /// </summary>
    public class SockMerchant
    {
        public static int GetCountOfPairs(int n, int[] ar)
        {
            var isArrayEmpty = ar == null || !ar.Any();
            if (isArrayEmpty)
            {
                return 0;
            }

            var groupedSocks = ar.GroupBy(x => x);
            var socksByPairs = groupedSocks.Select(x => new { PairsCount = x.Count() / 2 });
            var sumOfSocks = socksByPairs.Sum(x => x.PairsCount);

            return sumOfSocks;
        }
    }
}
