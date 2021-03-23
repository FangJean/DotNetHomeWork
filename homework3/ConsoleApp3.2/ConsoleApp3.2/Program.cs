using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3._2
{
    public interface Shape
    {
        void Area();
        bool IsLegal();
    }
    class Rectangle : Shape
    {
        double a;
        double b;
        public Rectangle(double x, double y)
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
        double a;
        double b;
        double c;
        public Triangle(double x, double y, double z)
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
    class Factory
    {
        public static Shape RanShape(int ran)
        {
            Random rd = new Random(ran);
            int k = rd.Next(0, 2);
            Shape shape=null;
            Console.Write(k);
            if (k == 0)
            {
                shape = new Triangle(rd.NextDouble() + rd.Next(1, 5), rd.NextDouble() + rd.Next(1, 5), rd.NextDouble() + rd.Next(1, 5));
                Console.WriteLine("三角形");
            }
            else if (k == 1)
            {
                shape = new Rectangle(rd.NextDouble() + rd.Next(0, 5), rd.NextDouble() + rd.Next(0, 5));
                Console.WriteLine("矩形");
            }
            return shape;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 10; i++)
            {
                Shape s = Factory.RanShape(i);
                s.Area();
            }
            Console.ReadKey();
        }
    }
}
