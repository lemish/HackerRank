using System.Collections.Generic;

namespace HackerRank.DictionariesAndHashmaps
{
    /// <summary>
    /// Two Strings
    /// <see href="https://www.hackerrank.com/challenges/two-strings/"/>
    /// </summary>
    public class TwoStrings
    {
        public static string CheckTwoStrings(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                return "NO";
            }

            var hashSet = new HashSet<char>(a);

            foreach (var symbol in b)
            {
                var contains = hashSet.Contains(symbol);
                if (contains)
                {
                    return "YES";
                }
            }

            return "NO";
        }
    }
}
