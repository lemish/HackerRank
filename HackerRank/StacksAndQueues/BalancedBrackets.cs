using System.Collections.Generic;
using System.Linq;

namespace HackerRank.StacksAndQueues
{
    /// <summary>
    /// Balanced Brackets
    /// <see href="https://www.hackerrank.com/challenges/balanced-brackets/"/>
    /// </summary>
    public class BalancedBrackets
    {
        public static string IsBalanced(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "YES";
            }

            var openBrackets = new HashSet<char> { '(', '[', '{' };
            var closeToOpenBrackets = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            var stack = new Stack<char>();

            for (var index = 0; index < s.Length; index++)
            {
                var bracket = s[index];

                if (openBrackets.Contains(bracket))
                {
                    stack.Push(bracket);
                }
                else if (closeToOpenBrackets.ContainsKey(bracket))
                {
                    if (!stack.Any())
                    {
                        stack.Push(bracket);
                        break;
                    }
                    else if (stack.Peek() == closeToOpenBrackets[bracket])
                    {
                       stack.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            var isBalanced = stack.Count == 0;
            return isBalanced ? "YES" : "NO";
        }
    }
}
