using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_csharp.DataStructure.Matrix
{
    class MatrixMain
    {

        // 1072. 按列翻转得到最大值等行数
        // 给定 m x n 矩阵 matrix 。 
        // 你可以从中选出任意数量的列并翻转其上的 每个 单元格。（即翻转后，单元格的值从 0 变成 1，或者从 1 变为 0 。） 
        // 返回 经过一些翻转后，行与行之间所有值都相等的最大行数 。

        // 示例 1： 
        // 输入：matrix = [[0,1],[1,1]]
        // 输出：1
        // 解释：不进行翻转，有 1 行所有值都相等。

        // 示例 2： 
        // 输入：matrix = [[0,1],[1,0]]
        // 输出：2
        // 解释：翻转第一列的值之后，这两行都由相等的值组成。

        // 示例 3： 
        // 输入：matrix = [[0,0,0],[0,0,1],[1,1,0]]
        // 输出：2
        // 解释：翻转前两列的值之后，后两行由相等的值组成。


        // 提示： 
        // m == matrix.length
        // n == matrix[i].length
        // 1 <= m, n <= 300
        // matrix[i][j] == 0 或 1
        public int MaxEqualRowsAfterFlips(int[][] matrix)
        {
            var result = 0;
            var map = new Dictionary<string, int>();
            // 按照数字出现的连续次数定义特征，比如 11100110 -> 3221，这样的好处是，00011001 同样也是 3221
            foreach (var row in matrix)
            {
                var count = 1;
                var sb = new StringBuilder();
                for (var i = 1; i < row.Length; i++)
                {
                    if (row[i] == row[i - 1])
                    {
                        count++;
                    }
                    else
                    {
                        sb.Append(count).Append("-");
                        count = 1;
                    }
                }
                sb.Append(count);
                int n;
                if (map.ContainsKey(sb.ToString()))
                {
                    n = map[sb.ToString()];
                }
                else
                {
                    n = 0;
                }
                map[sb.ToString()] = n + 1;
                result = Math.Max(result, n);
            }
            return result;

        }
    }
}
