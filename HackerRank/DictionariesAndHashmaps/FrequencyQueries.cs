using System.Collections.Generic;
using System.Linq;

namespace HackerRank.DictionariesAndHashmaps
{
    /// <summary>
    /// Frequency Queries
    /// <see href="https://www.hackerrank.com/challenges/frequency-queries/"/>
    /// </summary>
    public class FrequencyQueries
    {
        public static List<int> FreqQuery(List<List<int>> queries)
        {
            var isArrayEmpty = queries == null || queries.Count == 0;
            if (isArrayEmpty)
            {
                return new List<int>();
            }

            var sharedData = new Dictionary<int, int>();
            var repeatsCountPerValueInSharedData = new Dictionary<int, List<int>>();

            var result = new List<int>();
            foreach (var query in queries)
            {
                var operation = GetOperationTypeFromQuery(query);
                var value = GetValueFromQuery(query);

                switch (operation)
                {
                    case OperationType.InsertOperation:
                        AddValueByKey(value, sharedData, repeatsCountPerValueInSharedData);
                        break;
                    case OperationType.DeleteOperation:
                        DeleteValueByKey(value, sharedData, repeatsCountPerValueInSharedData);
                        break;
                    case OperationType.ContainsKeyOperation:
                        var containsAnyNumber = ContainsAnyValueByKey(value, repeatsCountPerValueInSharedData);
                        result.Add(containsAnyNumber ? 1 : 0);
                        break;
                }
            }

            return result;
        }

        private enum OperationType
        {
            InsertOperation = 1,
            DeleteOperation = 2,
            ContainsKeyOperation = 3
        }

        #region Query

        private static OperationType GetOperationTypeFromQuery(List<int> query)
        {
            const int operationQueryIndex = 0;

            var value = query[operationQueryIndex];

            return (OperationType)value;
        }

        private static int GetValueFromQuery(List<int> query)
        {
            const int dataElementQueryIndex = 1;

            var result = query[dataElementQueryIndex];

            return result;
        }

        #endregion

        #region Supported operations

        private static void AddValueByKey(int value, Dictionary<int, int> sharedData, Dictionary<int, List<int>> repeatsCountPerValue)
        {
            sharedData.TryGetValue(value, out var repeatsCount);

            RemoveValueByKey(repeatsCountPerValue, repeatsCount, value);

            repeatsCount++;
            sharedData[value] = repeatsCount;

            AddValueByKey(repeatsCountPerValue, repeatsCount, value);
        }

        private static void DeleteValueByKey(int key, Dictionary<int, int> sharedData, Dictionary<int, List<int>> repeatsCountPerValue)
        {
            sharedData.TryGetValue(key, out var repeatsCount);

            if (repeatsCount < 1)
            {
                return;
            }

            RemoveValueByKey(repeatsCountPerValue, repeatsCount, key);

            repeatsCount--;
            sharedData[key] = repeatsCount;

            AddValueByKey(repeatsCountPerValue, repeatsCount, key);
        }

        private static bool ContainsAnyValueByKey(int key, Dictionary<int, List<int>> repeatsCountPerValue)
        {
            if (repeatsCountPerValue.ContainsKey(key) &&
                repeatsCountPerValue[key].Any())
            {
                return true;
            }

            return false;
        }

        #endregion

        private static void RemoveValueByKey(Dictionary<int, List<int>> repeatsCountPerValue, int key, int value)
        {
            if (repeatsCountPerValue.ContainsKey(key))
            {
                repeatsCountPerValue[key].Remove(value);
            }
        }

        private static void AddValueByKey(Dictionary<int, List<int>> repeatsCountPerValue, int key, int value)
        {
            if (repeatsCountPerValue.ContainsKey(key))
            {
                repeatsCountPerValue[key].Add(value);
            }
            else
            {
                repeatsCountPerValue[key] = new List<int> { value };
            }
        }
    }
}
