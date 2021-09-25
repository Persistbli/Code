using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //冒泡排序
            int[] a = new int[7] {3,1,5,7,9,11,6};
            for (int j = 0; j < a.Length - 1; j++)
            {
                //比较两个元素大小
                if (a[j] > a[j + 1])
                {
                    int temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                }
            }
            //遍历数组中的元素
            foreach (int b in a)
            {
                Console.Write( b + " ");
            }
            Console.WriteLine();
        }
    }
}
