using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Arrays
{
    /// <summary>
    /// 2D Array - DS
    /// <see href="https://www.hackerrank.com/challenges/2d-array/"/>
    /// </summary>
    public class Hourglass
    {
        public static int HourglassSum(int[][] arr)
        {
            if (arr == null || !arr.Any())
            {
                return 0;
            }

            var hourglassSubsets = GetHourglassSubsetsFromMatrix(arr);
            var sumFromEachSubset = GetSumFromHourglassSubsets(hourglassSubsets);
            var sum = sumFromEachSubset.Max();

            return sum;
        }

        private static List<int[][]> GetHourglassSubsetsFromMatrix(int[][] arr)
        {
            var subsets = new List<int[][]>();

            const int hourglassOffset = 1;
            var matrixLength = arr.Length;
            var matrixHeight = arr.First().Length;

            for (var i = hourglassOffset; i < matrixLength - hourglassOffset; i++)
            {
                for (var j = hourglassOffset; j < matrixHeight - hourglassOffset; j++)
                {
                    const int defaultValue = 0;
                    var subset = new int[][]
                    {
                        new [] { arr[i - 1][j - 1], arr[i - 1][j], arr[i - 1][j + 1] },
                        new [] { defaultValue, arr[i][j], defaultValue },
                        new [] { arr[i + 1][j - 1], arr[i + 1][j], arr[i + 1][j + 1] },
                    };

                    subsets.Add(subset);
                }
            }

            return subsets;
        }

        private static List<int> GetSumFromHourglassSubsets(List<int[][]> hourglassSubsets)
        {
            var hourglassSubsetSumList = hourglassSubsets.Select(x => x.Select(y => y.Sum()).Sum()).ToList();

            return hourglassSubsetSumList;
        }
    }
}
