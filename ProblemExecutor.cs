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
    }
}
