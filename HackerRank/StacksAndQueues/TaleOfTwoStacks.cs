using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank.StacksAndQueues
{
    /// <summary>
    /// Queues: A Tale of Two Stacks
    /// <see href="https://www.hackerrank.com/challenges/ctci-queue-using-two-stacks/"/>
    /// </summary>
    public class TaleOfTwoStacks
    {
        private static List<int> GetQueriesResult(List<List<int>> queries)
        {
            var isArrayEmpty = queries == null || !queries.Any();
            if (isArrayEmpty)
            {
                return new List<int>();
            }

            var results = new List<int>();
            var queue = new MyQueue<int>();

            foreach (var query in queries)
            {
                var operation = GetOperationTypeFromQuery(query);
                switch (operation)
                {
                    case OperationType.EnqueueOperation:
                        var value = GetValueFromQuery(query);
                        queue.Enqueue(value);
                        break;
                    case OperationType.DequeueOperation:
                        queue.Dequeue();
                        break;
                    case OperationType.PrintOperation:
                        value = queue.Peek();
                        results.Add(value);
                        break;
                }
            }

            return results;
        }

        private static OperationType GetOperationTypeFromQuery(List<int> query)
        {
            const int operationQueryIndex = 0;

            var value = query[operationQueryIndex];

            return (OperationType)value;
        }

        private enum OperationType
        {
            EnqueueOperation = 1,
            DequeueOperation = 2,
            PrintOperation = 3
        }

        private static int GetValueFromQuery(List<int> query)
        {
            const int dataElementQueryIndex = 1;

            var result = query[dataElementQueryIndex];

            return result;
        }

        private static void MainImplementation(string[] args)
        {
            var textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            var queriesCount = Convert.ToInt32(Console.ReadLine().Trim());
            var queries = new List<List<int>>();

            for (var i = 0; i < queriesCount; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            var answer = GetQueriesResult(queries);

            textWriter.WriteLine(string.Join("\n", answer));

            textWriter.Flush();
            textWriter.Close();
        }

        public class MyQueue<T>
        {
            private Stack<T> _stackNewestOnTop = new Stack<T>();
            private Stack<T> _stackOldestOnTop = new Stack<T>();
            private int _dequeueCount = 0;

            public void Enqueue(T value)
            {
                const int minCountToFlush = 1000;
                if (_dequeueCount > minCountToFlush)
                {
                    var actualElements = _stackNewestOnTop.Take(_stackNewestOnTop.Count - _dequeueCount);
                    _stackNewestOnTop = new Stack<T>(actualElements.Reverse());

                    _dequeueCount = 0;
                }

                _stackNewestOnTop.Push(value);
            }

            public T Peek()
            {
                if (!_stackOldestOnTop.Any())
                {
                    var actualElements = _stackNewestOnTop.Take(_stackNewestOnTop.Count - _dequeueCount);
                    _stackOldestOnTop = new Stack<T>(actualElements);
                }

                var value = _stackOldestOnTop.Peek();

                return value;
            }

            public T Dequeue()
            {
                if (!_stackOldestOnTop.Any())
                {
                    var actualElements = _stackNewestOnTop.Take(_stackNewestOnTop.Count - _dequeueCount);
                    _stackOldestOnTop = new Stack<T>(actualElements);
                }

                var value = _stackOldestOnTop.Pop();
                _dequeueCount++;

                return value;
            }
        }
    }
}
