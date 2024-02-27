# LeetCode練習工具

## 使用方式
> 請參考 .\Program\Medium\M_22_Generate_Parentheses.cs 範例題
> 類別中有4個#region 為固定寫法, 提供底層程式去列印題目、解答、程式、說明...等
> 請照規則命名題目類別 => 難度(H: Hard, M: Medium, E: Eazy)_題目.cs, <br>
將題目放在指定難度資料夾 EX: .\Program\Medium\M_22_Generate_Parentheses.cs
> 主程式中使用 LeetCode.Program.LeetCode.main("M_22_Generate_Parentheses"); 反射想要觀察的題目

## 範例
'''cs
namespace LeetCodePratice
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LeetCode
            // 傳入符合規範的類別名稱(難度_題號_題目名稱) 印出題目解答說明..等
            LeetCode.Program.LeetCode.main("M_22_Generate_Parentheses");

            #endregion

        }
    }
}
'''

'''cs
// .\Program\Medium\M_22_Generate_Parentheses.cs

namespace LeetCodePratice.LeetCode.Program // 命名空間請使用LeetCodePratice.LeetCode.Program
{
    public class M_22_Generate_Parentheses : LeetCodePGMBase, ILeetCodePGM // 抽象方法與介面必須繼承
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

        // 這邊放問題敘述
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

        // 這邊放解法, 會印出解題過程
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
        #endregion

        // 這邊放解釋或筆記
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
'''

## Console印出的結果
'''
================ LeetCode(題目: 22_Generate_Parentheses 難度: Medium) ================

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

-------------------------------- 解答 --------------------------------

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

-------------------------------- 執行結果 --------------------------------

/// <summary>
/// 呼叫程式執行區域，此處印呼叫過程與結果
/// </summary>
public override void PrintResult()
{
    Solution solution = new Solution();
    IList<string> res = solution.GenerateParenthesis(3);
    Console.WriteLine($"輸入: 3 輸出{string.Join(",", res)}");
}



輸入: 3 輸出((())),(()()),(())(),()(()),()()()

-------------------------------- 說明 --------------------------------

    使用DFS 先做左邊到最深節點 每次都會加 '('
    左邊做完 再往上看有沒有右邊 每次都會加 ')'
    會回朔是因為 先進的stack 做完左 會做右
    最下層節點做完時 因為使用遞迴 之前的stack還沒做另一邊 所以會接者做

'''
