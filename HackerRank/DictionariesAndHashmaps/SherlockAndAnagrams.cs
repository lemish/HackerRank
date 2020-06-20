using System.Collections.Generic;
using System.Linq;

namespace HackerRank.DictionariesAndHashmaps
{
    /// <summary>
    /// Sherlock and Anagrams
    /// <see href="https://www.hackerrank.com/challenges/sherlock-and-anagrams/"/>
    /// </summary>
    public class SherlockAndAnagrams
    {
        public static int CheckSherlockAndAnagrams(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var anagramGroups = GetGroupedAnagramsFromText(s);

            var combinationsPerAnagram = GetNumberOfCombinationsForAnagrams(anagramGroups);

            return combinationsPerAnagram;
        }

        private static List<AnagramGroup> GetGroupedAnagramsFromText(string s)
        {
            var allSubstrings = new Dictionary<string, List<string>>();

            for (var substringLength = 1; substringLength < s.Length; substringLength++)
            {
                for (var substringStartIndex = 0; substringStartIndex + substringLength <= s.Length; substringStartIndex++)
                {
                    var originalSubstring = s.Substring(substringStartIndex, substringLength);
                    var orderedSymbols = originalSubstring.OrderBy(x => x);
                    var universalSubstring = string.Concat(orderedSymbols);

                    var isContains = allSubstrings.ContainsKey(universalSubstring);
                    if (isContains)
                    {
                        allSubstrings[universalSubstring].Add(originalSubstring);
                    }
                    else
                    {
                        allSubstrings.Add(universalSubstring, new List<string> { originalSubstring });
                    }
                }
            }

            var anagrams = allSubstrings.Where(x => x.Value.Count > 1)
                                        .Select(x => new AnagramGroup { Anagrams = x.Value })
                                        .ToList();
            return anagrams;
        }

        private static int GetNumberOfCombinationsForAnagrams(List<AnagramGroup> anagramGroups)
        {
            var combinationsPerAnagramGroup = new List<double>();
            const int pairNumber = 2;

            foreach (var anagramGroup in anagramGroups)
            {
                var numberOfCombinations = GetNumberOfCombinations(anagramGroup.Anagrams.Count, pairNumber);

                combinationsPerAnagramGroup.Add(numberOfCombinations);
            }

            var sum = combinationsPerAnagramGroup.Sum();

            return (int)sum;
        }

        private static double GetNumberOfCombinations(int objectsCount, int objectsCountInCombination)
        {
            var diff = objectsCount - objectsCountInCombination;
            if (diff == 0)
            {
                return 1;
            }

            var divident = FactorialCalculator.Factorial(objectsCount);
            var divisor = FactorialCalculator.Factorial(objectsCountInCombination) * FactorialCalculator.Factorial(diff);

            var numberOfCombinations = divident / divisor;
            return numberOfCombinations;
        }

        private class FactorialCalculator
        {
            private static readonly Dictionary<int, double> FactorialCache = new Dictionary<int, double>();

            public static double Factorial(int inputValue)
            {
                if (inputValue < 2)
                {
                    return 1;
                }

                if (FactorialCache.TryGetValue(inputValue, out var returnValue))
                {
                    return returnValue;
                }

                returnValue = inputValue * Factorial(inputValue - 1);

                FactorialCache.Add(inputValue, returnValue);

                return returnValue;
            }
        }

        private class AnagramGroup
        {
            public List<string> Anagrams { get; set; }
        }
    }
}
