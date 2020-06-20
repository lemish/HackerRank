using System.Collections.Generic;

namespace HackerRank.Sorting
{
    /// <summary>
    /// Sorting: Comparator
    /// <see href="https://www.hackerrank.com/challenges/ctci-comparator-sorting/"/>
    /// </summary>
    public class PlayerComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            if (x.Score > y.Score)
            {
                return -1;
            }

            if (x.Score < y.Score)
            {
                return 1;
            }

            return string.Compare(x.Name, y.Name);
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
