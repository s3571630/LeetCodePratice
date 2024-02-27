using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePratice.LeetCode.Interfaces
{
    public interface ILeetCodePGM
    {
        string FilePath { get; set; }
        string Difficulty { get; set; }
        string ProblemName { get; set; }
        void Exec();
        void PrintQusion();
        void PrintAnswer();
        void PrintResult();
        void PrintResultPGM();
        void PrintExplain();
    }
}
