using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2._1
{
    class Program
    {
        static bool IsPrime(int num)
        {
            int sq = Convert.ToInt32(Math.Sqrt(num));
            for(int i = 2; i <= sq; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static void GetPrime(int num)
        {
            int s = Convert.ToInt32(Math.Sqrt(num));
            for(int i = 2; i <= s; i++)
            {
                if (num % i == 0 && IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
            if (IsPrime(num))
            {
                Console.WriteLine(num);
            }
        }
        static void Main(string[] args)
        {
            int n = 72;
            GetPrime(n);
            Console.ReadKey();
        }
    }
}
