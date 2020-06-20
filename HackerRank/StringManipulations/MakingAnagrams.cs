using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.StringManipulations
{
    /// <summary>
    /// Strings: Making Anagrams
    /// https://www.hackerrank.com/challenges/ctci-making-anagrams/
    /// </summary>
    public class MakingAnagrams
    {
        public static int MakeAnagram(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                return 0;
            }

            var charsA = a.ToCharArray().GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var charsB = b.ToCharArray().GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            var charsOut = new Dictionary<char, int>();

            foreach (var charA in charsA)
            {
                charsB.TryGetValue(charA.Key, out var charBCount);

                var difference = Math.Abs(charA.Value - charBCount);
                charsOut.Add(charA.Key, difference);
            }

            foreach (var charB in charsB)
            {
                var contains = charsA.TryGetValue(charB.Key, out var charACount);

                if (!contains)
                {
                    charsOut.Add(charB.Key, charB.Value);
                }
            }

            var result = charsOut.Sum(x => x.Value);
            return result;
        }
    }
}
