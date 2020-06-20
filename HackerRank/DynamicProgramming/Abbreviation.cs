namespace HackerRank.DynamicProgramming
{
    /// <summary>
    /// Abbreviation.
    /// <see href="https://www.hackerrank.com/challenges/abbr/"/>
    /// </summary>
    public class Abbreviation
    {
        public static string CanTransoformAToB(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                return "NO";
            }

            var transformPossibilityMap = new bool[a.Length + 1, b.Length + 1];

            // Initial state
            transformPossibilityMap[0, 0] = true;

            for (var aIndex = 0; aIndex < a.Length; aIndex++)
            {
                for (var bIndex = 0; bIndex <= b.Length; bIndex++)
                {
                    var canTransoformPreviousCharAToB = transformPossibilityMap[aIndex, bIndex];
                    if (!canTransoformPreviousCharAToB)
                    {
                        continue;
                    }

                    var canTransformCurrentCharAToB = bIndex < b.Length && char.ToUpper(a[aIndex]) == b[bIndex];
                    if (canTransformCurrentCharAToB)
                    {
                        transformPossibilityMap[aIndex + 1, bIndex + 1] = true;
                    }

                    if (!char.IsUpper(a[aIndex]))
                    {
                        transformPossibilityMap[aIndex + 1, bIndex] = true;
                    }
                }
            }

            var canTransformLastCharFromAToB = transformPossibilityMap[a.Length, b.Length];
            
            return canTransformLastCharFromAToB ? "YES" : "NO";
        }
    }
}
