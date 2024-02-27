using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCodePratice.LeetCode.Abstracts;
using LeetCodePratice.LeetCode.Interfaces;

namespace LeetCodePratice.LeetCode.Program
{
    public class M_22_Generate_Parentheses : LeetCodePGMBase, ILeetCodePGM
    {

        public M_22_Generate_Parentheses() : base()
        {

        }

        #region ResultScope
        /// <summary>
        /// 呼叫程式執行區域，此處印呼叫過程與結果
        /// </summary>
        public override void PrintResult()
        {
            Solution solution = new Solution();
            IList<string> res = solution.GenerateParenthesis(3);
            Console.WriteLine($"輸入: 3 輸出{string.Join(",", res)}");
        }
        #endregion

        #region QusionScope
        /*
            Given n pairs of parentheses,                                            
            write a function to generate all combinations of well-formed parentheses.
                                                                                     
            Example 1:                                                               
                                                                                     
            Input: n = 3                                                             
            Output: [""((()))"",""(()())"",""(())()"",""()(())"",""()()()""]         
            Example 2:                                                               
                                                                                     
            Input: n = 1                                                             
            Output: [""()""]                                                         
                                                                                     
                                                                                     
            Constraints:                                                             
                                                                                     
            1 <= n <= 8                                                              
         */
        #endregion

        #region AnswerScope
        /// <summary>
        /// DFS解法
        /// </summary>
        public class Solution
        {
            public IList<string> GenerateParenthesis(int n)
            {
                var result = new List<string>();
                GenerateParenthesisDFS(n, n, "", result);
                return result;
            }


            private void GenerateParenthesisDFS(int left, int right, string str, IList<string> result)
            {
                if (left > right) return; // 基本的剪枝條件

                if (left == 0 && right == 0)
                {
                    result.Add(str);
                    return;
                }

                if (left > 0)
                {
                    GenerateParenthesisDFS(left - 1, right, str + "(", result);
                }

                if (right > 0)
                {
                    GenerateParenthesisDFS(left, right - 1, str + ")", result);
                }
            }
        }


        /// <summary>
        /// BFS解法
        /// </summary>
        public class Solution2
        {
            public IList<string> GenerateParenthesis(int n)
            {
                var result = new List<string>();
                var queue = new Queue<Node>();
                queue.Enqueue(new Node("", n, n));

                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    if (current.Left == 0 && current.Right == 0)
                    {
                        result.Add(current.Str);
                    }

                    if (current.Left > 0)
                    {
                        queue.Enqueue(new Node(current.Str + "(", current.Left - 1, current.Right));
                    }

                    if (current.Right > 0 && current.Left < current.Right)
                    {
                        queue.Enqueue(new Node(current.Str + ")", current.Left, current.Right - 1));
                    }
                }

                return result;
            }

            private class Node
            {
                public string Str;
                public int Left;
                public int Right;

                public Node(string str, int left, int right)
                {
                    Str = str;
                    Left = left;
                    Right = right;
                }
            }
        }

        #endregion

        #region ExplainScope
        /*
            使用DFS 先做左邊到最深節點 每次都會加 '('                                                           
            左邊做完 再往上看有沒有右邊 每次都會加 ')'        
            會回朔是因為 先進的stack 做完左 會做右        
            最下層節點做完時 因為使用遞迴 之前的stack還沒做另一邊 所以會接者做
         */
        #endregion





    }
}
