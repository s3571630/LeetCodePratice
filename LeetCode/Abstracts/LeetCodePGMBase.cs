using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePratice.LeetCode.Abstracts
{
    public abstract class LeetCodePGMBase
    {
        public string FilePath { get; set; }
        public string ProblemName { get; set; }
        public string Difficulty { get; set; }

        public List<string> QusionScope = new List<string>();
        public List<string> AnswerScope = new List<string>();
        public List<string> ExplainScope = new List<string>();
        public List<string> ResultScope = new List<string>();

        private class ReadRecord
        {
            public string NowRead = "";
            public int IndentSpace = 0;
        }

        public LeetCodePGMBase()
        {
            Dictionary<string, string> difficultyDic = new Dictionary<string, string>()
            {
                ["E"] = "Easy",
                ["M"] = "Medium",
                ["H"] = "Hard",
            };
            string className = GetType().Name;
            string[] classNameSplit = className.Split('_');

            Difficulty = difficultyDic[classNameSplit[0]];
            ProblemName = className.Replace($"{classNameSplit[0]}_", "");
            FilePath = Path.Combine("..", "..", "..", "LeetCode", "Program", Difficulty, $"{className}.cs");
            LoadScope();
        }

        /// <summary>
        /// 印出所有內容流程
        /// </summary>
        public virtual void Exec()
        {
            Console.WriteLine($"\n================ LeetCode(題目: {ProblemName} 難度: {Difficulty}) ================\n");
            PrintQusion();

            Console.WriteLine($"\n-------------------------------- 解答 --------------------------------\n");
            PrintAnswer();

            Console.WriteLine($"\n-------------------------------- 執行結果 --------------------------------\n");
            PrintResultPGM();
            PrintResult();

            Console.WriteLine($"\n-------------------------------- 說明 --------------------------------\n");
            PrintExplain();

            Console.WriteLine("\n\n\n");
        }

        /// <summary>
        /// 印出 #region Answer Scope .... #endregion中的所有函式與類別
        /// </summary>
        public virtual void PrintAnswer()
        {
            AnswerScope.ForEach(a => Console.WriteLine(a));
        }

        public virtual void PrintResultPGM()
        {
            ResultScope.ForEach(a => Console.WriteLine(a));
            Console.WriteLine("\n\n");
        }

        public virtual void PrintExplain()
        {
            ExplainScope.ForEach(a =>
            {
                if (!a.Contains("/*") && !a.Contains("*/")) Console.WriteLine(a);
            });
        }

        public virtual void PrintQusion()
        {
            QusionScope.ForEach(a =>
            {
                if (!a.Contains("/*") && !a.Contains("*/")) Console.WriteLine(a);
            });
        }

        public virtual void PrintResult()
        {

        }

        private void LoadScope()
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                ReadRecord readRecord = new ReadRecord();
                string nowRead = "";
                string line;

                // 逐行讀取直到文件結尾
                while ((line = reader.ReadLine()) != null)
                {
                    ReadRegion(line, "AnswerScope", AnswerScope, readRecord);
                    ReadRegion(line, "QusionScope", QusionScope, readRecord);
                    ReadRegion(line, "ExplainScope", ExplainScope, readRecord);
                    ReadRegion(line, "ResultScope", ResultScope, readRecord);
                }

            }
        }

        private void ReadRegion(string line, string regionName, List<string> linesReaded, ReadRecord readRecord)
        {

            string regionStartTag = $"#region {regionName}";

            // 算#region前方空白
            if (line.Contains(regionStartTag))
            {
                readRecord.NowRead = regionName;
                readRecord.IndentSpace = RegionFontSpace(line);
            }

            if (line.Contains("#endregion"))
            {
                readRecord.NowRead = "";
                readRecord.IndentSpace = 0;
            }

            if (readRecord.NowRead == regionName)
            {
                if (!line.Contains(regionStartTag))
                {
                    // 除空白並儲存
                    linesReaded.Add(RemoveLeadingSpaces(line, readRecord.IndentSpace));
                };
            }
        }

        private int RegionFontSpace(string line)
        {
            int res = 0;
            foreach (char item in line)
            {
                if (item != ' ')
                {
                    return res;
                }
                else
                {
                    res++;
                }
            }

            return res;
        }

        private string RemoveLeadingSpaces(string input, int numberOfSpacesToRemove)
        {
            int removeCount = 0;
            foreach (char c in input)
            {
                if (c == ' ' && removeCount < numberOfSpacesToRemove)
                {
                    removeCount++;
                }
                else
                {
                    break;
                }
            }

            return input.Substring(removeCount);
        }
    }
}
