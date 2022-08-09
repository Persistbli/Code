using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bliexercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4 };
            int[] b = RunningSum(nums);

            string Title = "《活着》";
            string Author = "余华";
            int year = 2001;
            InterfaceTraing ex = new InterfaceTraing(Title,Author,year);
            Console.WriteLine(ex.ColumnValues[0]);
            Console.WriteLine(ex.ColumnValues[1]);
            Console.WriteLine(ex.ColumnValues[2]);
            Console.ReadKey();

        }
        //动态求和
        //输入：nums = [1,1,1,1,1]
        //输出：[1,2,3,4,5]
        //解释：动态和计算过程为[1, 1 + 1, 1 + 1 + 1, 1 + 1 + 1 + 1, 1 + 1 + 1 + 1 + 1] 。
        public static int[] RunningSum(int[] nums)
        {
            int[] a = new int[4];
            for (int i = 0; i < nums.Length; i++)
            {
                a[i] = nums.Take(i+1).ToArray().Sum();
            }
            return a;
        }
        //回文数
        public static bool IsPalidrome(int x)
        {
            string s = x.ToString();
            int i = 0;

            if (s[i] == s[s.Length - i])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
