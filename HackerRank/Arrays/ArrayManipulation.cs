namespace HackerRank.Arrays
{
    /// <summary>
    /// Array Manipulation.
    /// <see href="https://www.hackerrank.com/challenges/crush/"/>
    /// </summary>
    public class ArrayManipulation
    {
        public static long arrayManipulation(int n, int[][] queries)
        {
            if (queries == null || queries.Length == 0)
            {
                return 0;
            }

            var array = new long[n];

            foreach (var query in queries)
            {
                var indexFrom = query[0];
                var indexTo = query[1];
                var value = query[2];

                var indexFromWithOffset = indexFrom - 1;
                array[indexFromWithOffset] += value;

                if (indexTo != array.Length)
                {
                    array[indexTo] -= value;
                }
            }

            long maxValue = 0;
            long temp = 0;

            foreach (var number in array)
            {
                temp += number;
                if (temp > maxValue)
                {
                    maxValue = temp;
                }
            }

            return maxValue;
        }
    }
}
