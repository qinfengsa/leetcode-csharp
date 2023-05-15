using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_csharp.DataStructure.String
{
    internal class StringMain
    {

        // 5. 最长回文子串
        // 给你一个字符串 s，找到 s 中最长的回文子串。 
        // 如果字符串的反序与原始字符串相同，则该字符串称为回文字符串。 

        // 示例 1： 
        // 输入：s = "babad"
        // 输出："bab"
        // 解释："aba" 同样是符合题意的答案。

        // 示例 2： 
        // 输入：s = "cbbd"
        // 输出："bb" 

        // 提示： 
        // 1 <= s.length <= 1000
        // s 仅由数字和英文字母组成 
        public string LongestPalindrome(string s)
        {
            int n = s.Length;
            string result = "";
            for (int i = 0; i < n; i++)
            {
                int left = i, right = i;
                // 寻找中间的回文
                while (right + 1 < n && s[right + 1] == s[right])
                {
                    right++;
                }
                i = right;
                // 向两边扩展
                while (left - 1 >= 0 && right + 1 < n && s[left - 1] == s[right + 1])
                {
                    left--;
                    right++;
                }
                var l = right - left + 1;
                if (l > result.Length)
                {
                    result = s.Substring(left, l);
                }
            }
            return result;
        }


        // 3. 无重复字符的最长子串
        // 给定一个字符串 s ，请你找出其中不含有重复字符的 最长子串 的长度。 

        // 示例 1: 
        // 输入: s = "abcabcbb"
        // 输出: 3 
        // 解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。

        // 示例 2: 
        // 输入: s = "bbbbb"
        // 输出: 1
        // 解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。

        // 示例 3: 
        // 输入: s = "pwwkew"
        // 输出: 3
        // 解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
        // 请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。 

        // 提示： 
        // 0 <= s.length <= 5 * 104
        // s 由英文字母、数字、符号和空格组成 
        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            if (n <= 1)
            {
                return n;
            }
            var result = 1;
            var letters = new int[128];
            var left = 0;
            for (int i = 0; i < n; i++)
            {
                var idx = s[i];
                letters[idx]++;
                while (letters[idx] > 1)
                {
                    var leftIdx = s[left];
                    letters[leftIdx]--;
                    left++;
                }
                var l = i - left + 1;
                result = Math.Max(result, l);
            }

            return result;
        }
    }
}
