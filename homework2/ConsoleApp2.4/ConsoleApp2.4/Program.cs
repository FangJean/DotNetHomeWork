using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = 1;
            int [,] arr = new int[,] { { 0, 1, 2, 3, 4 }, { 1, 0, 1, 2, 3 }, { 2, 1, 0, 1, 2 }, { 3, 2, 1, 0, 1 } };
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (arr[i, j] != arr[i + 1, j + 1])
                    {
                        key = 0;
                        break;
                    }
                }
            }
            if (key == 1)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            Console.ReadKey();
            //0 1 2 3 4
            //1 0 1 2 3 
            //2 1 0 1 2
            //3 2 1 0 1
        }
    }
}
