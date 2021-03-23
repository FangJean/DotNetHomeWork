using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3._1
{
    public interface Shape
    {
        void Area();
        bool IsLegal();
    }
    class Rectangle : Shape
    {
        int a;
        int b;
        public Rectangle(int x,int y)
        {
            a = x;
            b = y;
        }
        public bool IsLegal()
        {
            return a > 0 && b > 0;
        }
            public void Area()
            {
            if (!IsLegal())
            {
                Console.WriteLine("illegal");
            }
                Console.WriteLine(a * b);
            }

        }
    public class Triangle : Shape
    {
        int a;
        int b;
        int c;
        public Triangle(int x,int y,int z)
        {
            a = x;
            b = y;
            c = z;
        }
        public bool IsLegal()
        {
            return a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a;
        }
        public void Area()
        {
            if (!IsLegal())
            {
                Console.WriteLine("illegal");
            }
            Console.WriteLine(0.25 * Math.Sqrt((a + b + c) * (a + b - c) * (a + c - b) * (b + c - a)));
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            string s = "";
            int w = 0;
            int q = 0;
            s = Console.ReadLine();
            w = int.Parse(s);
            s = Console.ReadLine();
            q = int.Parse(s);
            Shape square = new Rectangle(w,q);
            square.Area();
            Console.ReadKey();
        }
    }
}
