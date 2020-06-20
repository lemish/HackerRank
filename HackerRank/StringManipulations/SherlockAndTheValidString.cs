using System.Linq;

namespace HackerRank.StringManipulations
{
    /// <summary>
    /// Sherlock and the Valid String
    /// <see href="https://www.hackerrank.com/challenges/sherlock-and-valid-string/"/>
    /// </summary>
    public class SherlockAndTheValidString
    {
        public static string IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "NO";
            }

            var charsPerCount = s.ToCharArray()
                                 .GroupBy(x => x)
                                 .GroupBy(x => x.Count())
                                 .Select(x => new { DuplicatesCount = x.Key, CharsCount = x.Count() })
                                 .ToList();

            if (charsPerCount.Count == 1)
            {
                return "YES";
            }

            if (charsPerCount.Count == 2)
            {
                var firstChar = charsPerCount[0];
                var lastChar = charsPerCount[1];

                var firstCharOffset = firstChar.CharsCount * firstChar.DuplicatesCount;
                var secondCharOffset = lastChar.CharsCount * lastChar.DuplicatesCount;

                const int removeOffset = 1;
                var canRemoveSymbol = firstCharOffset == removeOffset || secondCharOffset == removeOffset;
                if (canRemoveSymbol)
                {
                    return "YES";
                }

                var canRemoveLastSymbol = lastChar.CharsCount == removeOffset;
                var isDuplicatesCountEqual = firstChar.DuplicatesCount == (lastChar.DuplicatesCount - removeOffset);
                if (canRemoveLastSymbol && isDuplicatesCountEqual)
                {
                    return "YES";
                }

                var canRemoveFirstSymbol = firstChar.CharsCount == removeOffset;
                isDuplicatesCountEqual = lastChar.DuplicatesCount == (firstChar.DuplicatesCount - removeOffset);
                if (canRemoveFirstSymbol && isDuplicatesCountEqual)
                {
                    return "YES";
                }
            }

            return "NO";
        }
    }
}
