namespace HackerRank.Arrays
{
    /// <summary>
    /// New Year Chaos.
    /// <see href="https://www.hackerrank.com/challenges/new-year-chaos/"/>
    /// </summary>
    public class NewYearChaos
    {
        public static string MinimumBribes(int[] queue)
        {
            if (queue == null || queue.Length == 0)
            {
                return "0";
            }

            var swapCount = 0;

            for (var index = queue.Length - 1; index >= 0; index--)
            {
                var expectedValue = index + 1;

                var currentValue = queue[index];
                if (currentValue == expectedValue)
                {
                    continue;
                }

                var leftIndex = index - 1;
                var twoLeftIndex = index - 2;
                var isLeftIndexExists = leftIndex >= 0;
                var isTwoLeftIndexExists = twoLeftIndex >= 0;

                if (isLeftIndexExists && queue[leftIndex] == expectedValue)
                {
                    swapCount++;
                    Swap(queue, index, leftIndex);
                }
                else if (isTwoLeftIndexExists && queue[twoLeftIndex] == expectedValue)
                {
                    swapCount += 2;
                    Swap(queue, twoLeftIndex, leftIndex);
                    Swap(queue, leftIndex, index);
                }
                else
                {
                    return "Too chaotic";
                }
            }

            return swapCount.ToString();
        }

        private static void Swap(int[] array, int a, int b)
        {
            var temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
