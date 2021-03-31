using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4._1
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList(int[] vs)
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = null;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T>action)
        {
            Node<T> h = head;
            while (h != null)
            {
                action(h.Data);
                h = h.Next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var intlist = new GenericList<int>(
            new[] { 1,2,3,4,5,6});
            intlist.ForEach( s => Console.WriteLine(s));
            Console.ReadKey();
        }
    }
}
