using System.Linq;
using System.Text;

namespace HackerRank.GreedyAlgorithms
{
    /// <summary>
    /// Reverse Shuffle Merge.
    /// <see href="https://www.hackerrank.com/challenges/reverse-shuffle-merge/"/>
    /// </summary>
    public class ReverseShuffleAndMerge
    {
        public static string ReverseShuffleMerge(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            var charsOccurrences = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count() / 2);

            var lastIndex = s.Length;
            var uniqueElement = charsOccurrences.Count();
            var solution = new StringBuilder(lastIndex / 2);

            while (uniqueElement > 0)
            {
                var charsOccurrencesCopy = charsOccurrences.ToDictionary(x => x.Key, x => x.Value);
                var temporaryUniqueElement = uniqueElement;
                var windowSize = 0;

                for (var i = 0; i < s.Length; i++)
                {
                    var currentChar = s[i];
                    charsOccurrencesCopy[currentChar]--;
                    if (charsOccurrencesCopy[currentChar] == 0)
                    {
                        temporaryUniqueElement--;
                    }

                    if (temporaryUniqueElement == 0)
                    {
                        break;
                    }

                    windowSize++;
                }

                var minCharacter = char.MaxValue;
                for (var i = lastIndex - 1; i >= windowSize; i--)
                {
                    if (minCharacter > s[i] && charsOccurrences[s[i]] > 0)
                    {
                        minCharacter = s[i];
                        lastIndex = i;
                    }
                }

                // We add the character to the solution
                solution.Append(minCharacter);
                charsOccurrences[minCharacter]--;

                if (charsOccurrences[minCharacter] == 0)
                {
                    uniqueElement--;
                }
            }

            var result = solution.ToString();
            return result;
        }
    }
}
