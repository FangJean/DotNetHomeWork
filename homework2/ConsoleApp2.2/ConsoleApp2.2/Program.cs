using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入数组元素个数:");
            string num = "";
            num = Console.ReadLine();
            int n = int.Parse(num);
            int[] arr;
            arr = new int[5];
            string str = "";
            Console.WriteLine("输入数组元素:");
            for(int i = 0; i < 100; i++)
            {
                str = Console.ReadLine();
                arr[i] = int.Parse(str);
            }
            Console.WriteLine("平均值为:" + Average(arr, n));
            MaxandMin(arr, n);
        }
        public static double Average(int[] a,int n)
        {
            int sum=0;
            for(int i = 0; i < n; i++)
            {
                sum += a[i];
            }
            double ave = sum / n;
            return ave;
        }
        public static void MaxandMin(int[]a,int n)
        {
            int max = a[0];
            int min = a[0];
            for(int i = 1; i < n; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            Console.WriteLine("最小值为:"+min+"最大值为:"+max);
        }
    }
}
