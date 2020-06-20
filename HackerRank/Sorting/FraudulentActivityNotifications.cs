using System;
using System.Collections.Generic;

namespace HackerRank.Sorting
{
    /// <summary>
    /// Fraudulent Activity Notifications
    /// <see href="https://www.hackerrank.com/challenges/fraudulent-activity-notifications/"/>
    /// </summary>
    public class FraudulentActivityNotifications
    {
        public static int ActivityNotifications(int[] expenditure, int daysForMedianSpending)
        {
            var isArrayEmpty = expenditure == null || expenditure.Length == 0;
            if (isArrayEmpty)
            {
                return 0;
            }

            var startIndex = 0;
            var expenditureForMedianPeriod = GetSubArray(expenditure, startIndex, daysForMedianSpending);

            var sortedExpeditureForMedianPeriod = GetSortedList(expenditureForMedianPeriod);
            var notificationsCount = 0;

            for (var dayIndex = daysForMedianSpending; dayIndex < expenditure.Length; dayIndex++)
            {
                if (dayIndex > daysForMedianSpending)
                {
                    var previousDayIndex = dayIndex - 1;
                    var oldValue = expenditure[previousDayIndex - daysForMedianSpending];
                    var newValue = expenditure[previousDayIndex];

                    if (oldValue != newValue)
                    {
                        sortedExpeditureForMedianPeriod.Remove(oldValue);
                        sortedExpeditureForMedianPeriod.Add(newValue);
                    }
                }

                var currentDayExpenditure = expenditure[dayIndex];

                var canNotifyClient = CanNotifyClient(sortedExpeditureForMedianPeriod, currentDayExpenditure);
                if (canNotifyClient)
                {
                    notificationsCount++;
                }
            }

            return notificationsCount;
        }

        private static bool CanNotifyClient(SortedList<int> sortedExpeditureForMedianPeriod, int currentDayExpenditure)
        {
            var medianExpenditure = GetMedian(sortedExpeditureForMedianPeriod);
            var oneDayExpenditureLimit = medianExpenditure * 2;

            var canNotifyClient = currentDayExpenditure >= oneDayExpenditureLimit;

            return canNotifyClient;
        }

        #region Median

        private static double GetMedian(SortedList<int> array)
        {
            if (array == null || !array.Any())
            {
                return 0;
            }

            var isOdd = array.Count % 2 != 0;
            if (isOdd)
            {
                return GetMedianFromOddArray(array);
            }

            return GetMedianFromEvenArray(array);
        }

        private static double GetMedianFromOddArray(SortedList<int> array)
        {
            var medianIndex = array.Count / 2;
            var median = array[medianIndex];
            return median;
        }

        private static double GetMedianFromEvenArray(SortedList<int> array)
        {
            var median1 = array[array.Count / 2];
            var median2 = array[array.Count / 2 - 1];

            var averageMedian = (double)(median1 + median2) / 2;
            return averageMedian;
        }

        #endregion

        #region Common

        private static int[] GetSubArray(int[] array, int startIndex, int length)
        {
            var subArray = new int[length];
            const int destinationIndex = 0;

            Array.Copy(array, startIndex, subArray, destinationIndex, length);

            return subArray;
        }

        private static SortedList<int> GetSortedList(int[] array)
        {
            var sortedExpediture = new int[array.Length];

            array.CopyTo(sortedExpediture, 0);
            Array.Sort(sortedExpediture);

            var sortedList = new SortedList<int>(sortedExpediture);
            return sortedList;
        }

        private class SortedList<T>
        {
            private readonly List<T> _list = new List<T>();

            public SortedList(IEnumerable<T> collection)
            {
                _list = new List<T>(collection);
            }

            public int Count => _list.Count;

            public void Add(T item)
            {
                var insertIndex = _list.BinarySearch(item);
                if (insertIndex < 0)
                {
                    insertIndex = ~insertIndex;
                }

                _list.Insert(insertIndex, item);
            }

            public bool Any() => _list.Count > 0;

            public T this[int index] => _list[index];

            public void Remove(T item)
            {
                var index = _list.BinarySearch(item);
                if (index >= 0)
                {
                    _list.RemoveAt(index);
                }
            }
        }

        #endregion
    }
}
