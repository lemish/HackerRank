using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.GreedyAlgorithms
{
    /// <summary>
    /// Luck Balance
    /// <see href="https://www.hackerrank.com/challenges/luck-balance/"/>
    /// </summary>
    public class LuckBalance
    {
        public static int GetLuckBalance(int maxImportantContestsCount, int[][] contests)
        {
            var isArrayEmpty = contests == null || !contests.Any();
            if (isArrayEmpty)
            {
                return 0;
            }

            var contestList = GetContestList(contests);

            var importantContests = contestList.Where(x => x.IsContestImportant).ToList();
            var unimportantContests = contestList.Where(x => !x.IsContestImportant);

            var sortedImportantContests = GetContestsSortedByAmountOfLuck(importantContests);

            var amountOfLuckOfUnimportantContests = unimportantContests.Sum(x => x.AmountOfLuck);
            var amountOfLuckOfImportantContests = GetAmountOfLuck(sortedImportantContests, maxImportantContestsCount);

            var maximumAmountOfLuck = amountOfLuckOfUnimportantContests + amountOfLuckOfImportantContests;
            return maximumAmountOfLuck;
        }

        private static List<Contest> GetContestList(int[][] contests)
        {
            const int amountOfLuckIndex = 0;
            const int contestImportanceIndex = 1;

            var contestList = contests.Select(x => new Contest
            {
                AmountOfLuck = x[amountOfLuckIndex],
                IsContestImportant = x[contestImportanceIndex] == 1 ? true : false
            }).ToList();

            return contestList;
        }

        private class Contest
        {
            public int AmountOfLuck { get; set; }
            public bool IsContestImportant { get; set; }
        }

        private static List<Contest> GetContestsSortedByAmountOfLuck(List<Contest> contestList)
        {
            var contestSortedList = new SortedList<int, Contest>(new ReversedDuplicateKeyComparer<int>());

            foreach (var contest in contestList)
            {
                contestSortedList.Add(contest.AmountOfLuck, contest);
            }

            var sortedContestList = contestSortedList.Select(x => x.Value).ToList();
            return sortedContestList;
        }

        private static int GetAmountOfLuck(List<Contest> contestList, int maxImportantContestsCount)
        {
            var amountOfLuck = 0;
            var countOfLosedImportanceContests = 0;

            foreach (var contest in contestList)
            {
                if (countOfLosedImportanceContests < maxImportantContestsCount)
                {
                    amountOfLuck += contest.AmountOfLuck;
                    countOfLosedImportanceContests++;
                }
                else
                {
                    amountOfLuck -= contest.AmountOfLuck;
                }
            }

            return amountOfLuck;
        }

        private class ReversedDuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                int result = x.CompareTo(y);

                if (result == 0)
                {
                    return 1;
                }
                else
                {
                    return -result;
                }
            }
        }
    }
}