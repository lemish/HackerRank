using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Search
{
    /// <summary>
    /// Pairs
    /// <see href="https://www.hackerrank.com/challenges/pairs/"/>
    /// </summary>
    public class Pairs
    {
        public static int GetPairs(int differenceValue, int[] numbers)
        {
            var isArrayEmpty = numbers == null || !numbers.Any();
            if (isArrayEmpty)
            {
                return 0;
            }

            var numberSet = new HashSet<int>(numbers);
            var usedSets = new Dictionary<int, HashSet<int>>();

            foreach (var number in numberSet)
            {
                var firstTargetNumber = number - differenceValue;
                var secondTargetNumber = number + differenceValue;

                var targetValues = new int[] { firstTargetNumber, secondTargetNumber };

                foreach (var targetValue in targetValues)
                {
                    var isTargetValueExists = numberSet.Contains(targetValue);
                    if (!isTargetValueExists)
                    {
                        continue;
                    }

                    usedSets.TryGetValue(targetValue, out var usedNumbers);

                    var containsDuplicates = usedNumbers != null && usedNumbers.Contains(number);
                    if (containsDuplicates)
                    {
                        continue;
                    }

                    if (usedSets.ContainsKey(number))
                    {
                        usedSets[number].Add(targetValue);
                    }
                    else
                    {
                        usedSets.Add(number, new HashSet<int> { targetValue });
                    }
                }
            }

            var result = usedSets.Sum(x => x.Value.Count);
            return result;
        }
    }
}
