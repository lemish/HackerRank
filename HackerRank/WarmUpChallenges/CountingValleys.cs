namespace HackerRank.WarmUpChallenges
{
    /// <summary>
    /// Counting Valleys
    /// <see href="https://www.hackerrank.com/challenges/counting-valleys/"/>
    /// </summary>
    public class CountingValleys
    {
        public static int GetCountingValleys(int n, string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var countOfValleys = 0;
            var currentSeaLevel = 1;

            for (var index = 0; index < s.Length; index++)
            {
                if (s[index] == 'U')
                {
                    currentSeaLevel += 1;

                    if (currentSeaLevel == 1)
                    {
                        countOfValleys++;
                    }
                }
                else
                {
                    currentSeaLevel -= 1;
                }
            }

            return countOfValleys;
        }
    }
}
