namespace HackerRank.StringManipulations
{
    /// <summary>
    /// Alternating Characters
    /// <see href="https://www.hackerrank.com/challenges/alternating-characters/"/>
    /// </summary>
    public class AlternatingCharacters
    {
        public static int GetAlternatingCharactersCount(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var duplicateCount = 0;

            for (var index = 1; index < s.Length; index++)
            {
                if (s[index - 1] == s[index])
                {
                    duplicateCount++;
                }
            }

            return duplicateCount;
        }
    }
}
