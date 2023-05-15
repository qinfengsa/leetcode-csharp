using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_csharp.DataStructure.Array
{
    public class ArrayMain
    {
        // 1. 两数之和
        // 给定一个整数数组 nums 和一个整数目标值 target，请你在该数组中找出 和为目标值 target 的那 两个 整数，并返回它们的数组下标。

        // 你可以假设每种输入只会对应一个答案。但是，数组中同一个元素在答案里不能重复出现。

        // 你可以按任意顺序返回答案。 

        // 示例 1： 
        // 输入：nums = [2,7,11,15], target = 9
        // 输出：[0,1]
        // 解释：因为 nums[0] + nums[1] == 9 ，返回[0, 1] 。

        // 示例 2： 
        // 输入：nums = [3,2,4], target = 6
        // 输出：[1,2]

        // 示例 3： 
        // 输入：nums = [3,3], target = 6
        // 输出：[0,1]


        // 提示： 
        // 2 <= nums.length <= 104
        // -109 <= nums[i] <= 109
        // -109 <= target <= 109
        // 只会存在一个有效答案 

        // 进阶：你可以想出一个时间复杂度小于 O(n2) 的算法吗？
        public int[] TwoSum(int[] nums, int target)
        {
            var result = new int[2];
            var indexMap = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                var remainder = target - num;
                if (indexMap.ContainsKey(remainder))
                {
                    var index = indexMap[remainder];
                    result[0] = index;
                    result[1] = i;
                    break;
                }
                indexMap[num] = i;

            }
            return result;
        }


        // 4. 寻找两个正序数组的中位数
        // 给定两个大小分别为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。请你找出并返回这两个正序数组的 中位数 。 
        // 算法的时间复杂度应该为 O(log (m+n))  

        // 示例 1： 
        // 输入：nums1 = [1,3], nums2 = [2]
        // 输出：2.00000
        // 解释：合并数组 = [1,2,3] ，中位数 2

        // 示例 2： 
        // 输入：nums1 = [1,2], nums2 = [3,4]
        // 输出：2.50000
        // 解释：合并数组 = [1,2,3,4] ，中位数(2 + 3) / 2 = 2.5 

        // 提示： 
        // nums1.length == m
        // nums2.length == n
        // 0 <= m <= 1000
        // 0 <= n <= 1000
        // 1 <= m + n <= 2000
        //-106 <= nums1[i], nums2[i] <= 106
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var m = nums1.Length;
            var n = nums2.Length;
            if (m > n)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }
            var left = 0;
            var right = m;
            var midIdx = (m + n) >> 1;
            var mid1 = 0;
            var mid2 = 0;
            // 把数组划分为 左右两部分
            while (left <= right)
            {
                // 左边 nums1 [0, i - 1] nums2[0,j - 1]
                // 右边 nums1 [i, m - 1] nums2 [j, n - 1]
                var i = (left + right) / 2;

                var j = midIdx - i;

                var num10 = int.MinValue;
                var num11 = int.MaxValue;

                if (i > 0)
                {
                    num10 = nums1[i - 1];
                }
                if (i < m)
                {
                    num11 = nums1[i];

                }
                var num20 = int.MinValue;
                var num21 = int.MaxValue;
                if (j > 0)
                {
                    num20 = nums2[j - 1];
                }
                if (j < n)
                {
                    num21 = nums2[j];
                }
                if (num10 <= num21)
                {
                    mid1 = Math.Max(num10, num20);
                    mid2 = Math.Min(num11, num21);
                    left = i + 1;
                }
                else
                {
                    right = i - 1;
                }
            }
            if (((m + n) & 1) == 0)
            {
                return (double)(mid1 + mid2) / 2.0;
            }
            return (double)mid2;
        }
    }
}
