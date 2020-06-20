namespace HackerRank.Arrays
{
    /// <summary>
    /// Arrays: Left Rotation
    /// <see href="https://www.hackerrank.com/challenges/ctci-array-left-rotation/"/>
    /// </summary>
    public class LeftRotation
    {
        public static int[] RotateLeft(int[] arr, int steps)
        {
            if (arr == null || arr.Length == 0)
            {
                return new int[0];
            }

            var array = new int[arr.Length];
            var rotateSteps = steps % arr.Length;

            for (var currentIndex = 0; currentIndex < array.Length; currentIndex++)
            {
                var indexWithOffset = currentIndex + rotateSteps;
                if (indexWithOffset >= array.Length)
                {
                    indexWithOffset = currentIndex + rotateSteps - array.Length;
                }

                array[currentIndex] = arr[indexWithOffset];
            }

            return array;
        }
    }
}
