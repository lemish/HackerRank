using System;

namespace HackerRank.StringManipulations
{
    /// <summary>
    /// Common Child.
    /// <see href="https://www.hackerrank.com/challenges/common-child/"/>
    /// </summary>
    public class CommonChildStrings
    {
        public static int CommonChild(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                return 0;
            }

            const int offset = 1;
            var table = new int[s1.Length + offset, s2.Length + offset];

            for (var indexS1 = 1; indexS1 <= s1.Length; indexS1++)
            {
                for (var indexS2 = 1; indexS2 <= s2.Length; indexS2++)
                {
                    var previousIndexS1 = indexS1 - 1;
                    var previousIndexS2 = indexS2 - 1;

                    if (s1[previousIndexS1] == s2[previousIndexS2])
                    {
                        table[indexS1, indexS2] = 1 + table[previousIndexS1, previousIndexS2];
                    }
                    else
                    {
                        table[indexS1, indexS2] = Math.Max(
                            table[indexS1, previousIndexS2],
                            table[previousIndexS1, indexS2]);
                    }
                }
            }

            return table[s1.Length, s2.Length];
        }
    }
}
