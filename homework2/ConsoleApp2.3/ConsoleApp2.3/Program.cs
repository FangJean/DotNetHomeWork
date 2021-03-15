using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = new int[101];
            for(int i = 2; i <= 100; i++)
            {
                key[i] = 1;
            }
            for(int i = 2; i <= 50; i++)
            {
                for(int j = 2; j <= 100; j++)
                {
                    if (j % i == 0&&i!=j)
                    {
                        key[j] = 0;
                        continue;
                    }
                }
            }
            for(int i = 2; i <= 100; i++)
            {
                if (key[i] == 1)
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadKey();
        }
    }
}
