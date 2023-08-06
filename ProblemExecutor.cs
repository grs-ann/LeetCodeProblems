using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    internal static class ProblemExecutor
    {
        /// <summary>
        /// 1. Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
        /// </summary>
        internal static bool ContainsDuplicate(int[] nums)
        {
            // Структура `HashSet` предоставляет поиск элемента близкой к O(1), в то время как, например, `List` осуществляет поиск
            // с линейной сложностью O(n). Таким образом, использование HashSet значительно ускоряет поиск дубликатов.
            HashSet<int> existingNums = new(nums.Length);

            for (int i = 0; i < nums.Length; i++)
            {
                if (existingNums.Contains(nums[i]))
                {
                    return true;
                }

                existingNums.Add(nums[i]);
            }

            return false;
        }

        /// <summary>
        /// 2. Given two strings s and t, return true if t is an anagram of s, and false otherwise.
        /// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
        /// </summary>
        internal static bool IsAnagram(string s, string t)
        {
            // Не имеет смысла продолжать проверку на анаграмму, если строки изначально имеют разную длину.
            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, int> charsCount = new();

            // Проходимся сразу по обеим строкам одним циклом:
            // для первой коллекции увеличиваем счетчик символа,
            // а для второй - уменьшаем.
            for (int i = 0; i < s.Length; i++)
            {
                if (charsCount.ContainsKey(s[i]))
                {
                    charsCount[s[i]]++;
                }
                else
                {
                    charsCount.Add(s[i], 1);
                }

                if (charsCount.ContainsKey(t[i]))
                {
                    charsCount[t[i]]--;
                }
                else
                {
                    charsCount.Add(t[i], -1);
                }
            }

            // В результате имеем словарь, в котором ключом является символ, а значением - "разница" между количеством его нахождений во входных строках.
            // Если эта разница не равна 0, то кол-во этих символов не одинаково, и данные строки не являются анаграммами.
            foreach (int charCount in charsCount.Values)
            {
                if (charCount != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
