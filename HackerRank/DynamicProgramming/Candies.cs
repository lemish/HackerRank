using System;

namespace HackerRank.DynamicProgramming
{
    /// <summary>
    /// Candies.
    /// <see href="https://www.hackerrank.com/challenges/candies/"/>
    /// </summary>
    public class Candies
    {
        public static long CandiesCount(int n, int[] childsRating)
        {
            var isArrayEmpty = childsRating == null || childsRating.Length == 0;
            if (isArrayEmpty)
            {
                return 0;
            }

            var candiesPerChild = new int[childsRating.Length];

            const int minimumCountOfCandies = 1;
            candiesPerChild[0] = minimumCountOfCandies;

            for (var childIndex = 1; childIndex < childsRating.Length; childIndex++)
            {
                var previousIndex = childIndex - 1;
                var previousChildRating = childsRating[previousIndex];
                var currentChildRating = childsRating[childIndex];

                var isPreviousChildRatingGreaterThanCurrent = previousChildRating < currentChildRating;
                if (isPreviousChildRatingGreaterThanCurrent)
                {
                    const int additionalCountOfCandies = 1;

                    var previousChildCandies = candiesPerChild[previousIndex];
                    var currentChildCandies = previousChildCandies + additionalCountOfCandies;

                    candiesPerChild[childIndex] = currentChildCandies;
                }
                else
                {
                    candiesPerChild[childIndex] = minimumCountOfCandies;
                }
            }

            long sumOfCandies = candiesPerChild[childsRating.Length - 1];

            for (var childIndex = childsRating.Length - 2; childIndex >= 0; childIndex--)
            {
                var nextChildIndex = childIndex + 1;

                if (childsRating[childIndex] > childsRating[nextChildIndex])
                {
                    var nextChildCandies = candiesPerChild[nextChildIndex] + 1;
                    var childCandies = candiesPerChild[childIndex];

                    var maxOfChildCandies = Math.Max(nextChildCandies, childCandies);

                    candiesPerChild[childIndex] = maxOfChildCandies;
                }

                sumOfCandies += candiesPerChild[childIndex];
            }

            return sumOfCandies;
        }
    }
}
