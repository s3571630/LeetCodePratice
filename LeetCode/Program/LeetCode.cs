using LeetCodePratice.LeetCode.Interfaces;

namespace LeetCodePratice.LeetCode.Program
{
    public class LeetCode
    {
        public static void main(string className)
        {
            // 使用類別名稱獲取Type
            Type type = Type.GetType($"LeetCodePratice.LeetCode.Program.{className}", throwOnError: true);
            // 創建類別實例並指定型別
            object instance = Activator.CreateInstance(type);

            ILeetCodePGM myInterface = instance as ILeetCodePGM;
            myInterface.Exec();
        }
    }
}
