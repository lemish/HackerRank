using System;
using System.Linq;

namespace HackerRank.Search
{
    /// <summary>
    /// Hash Tables: Ice Cream Parlor
    /// <see href="https://www.hackerrank.com/challenges/ctci-ice-cream-parlor/"/>
    /// </summary>
    public class IceCreamParlor
    {
        public static void WhatFlavors(int[] costOfEachFlawor, int totalMoney)
        {
            var isArrayEmpty = costOfEachFlawor == null || !costOfEachFlawor.Any();
            if (isArrayEmpty)
            {
                return;
            }

            var dictionaryOfFlaworCosts = costOfEachFlawor
                .Select((cost, index) => new { Cost = cost, Index = index + 1 })
                .GroupBy(x => x.Cost)
                .ToDictionary(
                    x => x.Key,
                    x => x.Select(costAndIndex => costAndIndex.Index));

            foreach (var flaworCost in dictionaryOfFlaworCosts)
            {
                var firstFlaworCost = flaworCost.Key;
                var expectedSecondFlaworCost = totalMoney - firstFlaworCost;

                var firstCostIndex = flaworCost.Value.First();
                var secondCostIndex = 0;
                var isSecondFlaworExist = false;

                if (expectedSecondFlaworCost != firstFlaworCost &&
                    dictionaryOfFlaworCosts.ContainsKey(expectedSecondFlaworCost))
                {
                    isSecondFlaworExist = true;
                    secondCostIndex = dictionaryOfFlaworCosts[expectedSecondFlaworCost].First();
                }
                else if (expectedSecondFlaworCost == firstFlaworCost &&
                         flaworCost.Value.Count() > 1)
                {
                    isSecondFlaworExist = true;
                    secondCostIndex = flaworCost.Value.Where(x => x != firstCostIndex).First();
                }

                if (isSecondFlaworExist)
                {
                    var min = Math.Min(firstCostIndex, secondCostIndex);
                    var max = Math.Max(firstCostIndex, secondCostIndex);

                    Console.WriteLine($"{min} {max}");
                    return;
                }
            }
        }
    }
}
