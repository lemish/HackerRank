using System;
using System.Collections.Generic;

namespace HackerRank.DictionariesAndHashmaps
{
    /// <summary>
    /// Hash Tables: Ransom Note
    /// <see href="https://www.hackerrank.com/challenges/ctci-ransom-note/"/>
    /// </summary>
    public class RansomNote
    {
        public static void CheckMagazine(string[] magazine, string[] note)
        {
            var isMagazineEmpty = magazine == null || magazine.Length == 0;
            var isNoteEmpty = note == null || note.Length == 0;
            if (isMagazineEmpty || isNoteEmpty)
            {
                Console.WriteLine("No");
                return;
            }

            var magazineWordsPerCount = GetWordPerCountDictionary(magazine);

            var containsAllWords = true;
            foreach (var wordInNote in note)
            {
                if (magazineWordsPerCount.ContainsKey(wordInNote) &&
                    magazineWordsPerCount[wordInNote] > 0)
                {
                    containsAllWords &= true;
                    magazineWordsPerCount[wordInNote] -= 1;
                }
                else
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            Console.WriteLine("Yes");
        }

        private static Dictionary<string, int> GetWordPerCountDictionary(string[] words)
        {
            var dictionary = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 1);
                }
                else
                {
                    dictionary[word] += 1;
                }
            }

            return dictionary;
        }
    }
}
