using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.StacksAndQueues
{
    /// <summary>
    /// Largest Rectangle
    /// <see href="https://www.hackerrank.com/challenges/largest-rectangle/"/>
    /// </summary>
    public class LargestRectangle
    {
        public static long GetAreaOfLargestRectangle(int[] histogram)
        {
            var isArrayEmpty = histogram == null || histogram.Length == 0;
            if (isArrayEmpty)
            {
                return 0;
            }

            var positions = new Stack<int>();
            var maxArea = 0;

            var position = 0;
            while (position < histogram.Length)
            {
                if (!positions.Any() || histogram[position] >= histogram[positions.Peek()])
                {
                    // Push index to the stack when the current height is larger than the previous one
                    positions.Push(position);
                    position++;
                }
                else
                {
                    // Calculate max area when the current height is less than the previous one
                    maxArea = CalculateMaxArea(histogram, positions, maxArea, position);
                }
            }

            while (positions.Any())
            {
                maxArea = CalculateMaxArea(histogram, positions, maxArea, position);
            }

            return maxArea;
        }

        private static int CalculateMaxArea(int[] histogram, Stack<int> positions, int maxArea, int position)
        {
            var previousPosition = positions.Pop();
            var previousHeight = histogram[previousPosition];

            var width = positions.Any() ? position - positions.Peek() - 1 : position;
            var area = previousHeight * width;

            maxArea = Math.Max(area, maxArea);
            return maxArea;
        }
    }
}
