using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class Order
    {
        public string goods;
        public int id;
        public string customer;
        List<OrderDetails> details;
        //public string oname;
        //public int onum;
        //public int oprice;
        public Order() { }
        public Order(int i,string cus, List<OrderDetails>d)
        {
            id = i;
            customer = cus;
            details = d;
        }
        /*
        public void AddOrderDetails(string na,int nu,int pr)
        {
            oname = na;
            onum = nu;
            oprice = pr;
        }*/
        
        public override string ToString()
        {
            return "订单号:"+id+"客户:"+customer;
        }
        public override bool Equals(System.Object obj)
        {
            Order a = obj as Order;
            return this.id == a.id;
        }
    }
    class OrderDetails:Order
    {
        public int odnum;
        public int odpri;
        public string odname;
        public OrderDetails() { }
        public OrderDetails(int num,int p,string name)
        {
            odnum = num;
            odpri = p;
            odname = name;
        }
        public override string ToString()
        {
            return "商品:"+odname+"数目:" + odnum + " " + "价格:" + odpri;
        }
    }
    class OrderService
    {
        List<Order> orderdata = new List<Order>();
        List<OrderDetails> odetailsdata = new List<OrderDetails>();
        public OrderService() { }
        public void AddOrder()
        {
            Console.WriteLine("输入订单编号");//输入编号，int用于排序
            int orderid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("输入客户");//输入客户
            string person = Console.ReadLine();
            Console.WriteLine("输入订单项");//输入详细的订单内容
            Order ord = new Order(orderid, person,odetailsdata);
            bool same = false;
            foreach(Order e in orderdata)
            {
                if (e.Equals(ord))
                {
                    same = true;//如果orderdata中和ord相同，则订单号重复
                }
            }
            if (same)
            {
                Console.WriteLine("订单重复");
            }
            else//输入订单详细内容
            {
                Console.WriteLine("商品");
                string name = Console.ReadLine();
                Console.WriteLine("数目");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("价格");
                int price = Convert.ToInt32(Console.ReadLine());
                OrderDetails ordd = new OrderDetails(price,num,name);
                odetailsdata.Add(ordd);//加入list
            }
        }
        public void RemoveOrder()//输入id删除订单
        {
            Console.WriteLine("输入id删除订单");
            int deid = Convert.ToInt32(Console.ReadLine());
            bool tf = true;
            Console.WriteLine("是否输入错误(0错误)");
            int tor = Convert.ToInt32(Console.ReadLine());
            if (tor == 0)
            {
                tf = false;
            }
            foreach(Order e in orderdata)
            {
                if (e.id == deid&&tf)
                {
                    orderdata.RemoveAt(e.id);
                }
            }
        }
        public void SortOrder()//按照订单号大小进行排序
        {
            orderdata.Sort((x,y)=>x.id.CompareTo(y.id));
        }
        public void SearchOrder()
        {
            Console.WriteLine("查询单号【1】，查询商品【2】，查询客户【3】，查询金额【4】");
            int searchnum = Convert.ToInt32(Console.ReadLine());
            switch (searchnum)
            {
                case 1:
                    Console.WriteLine("输入单号");
                    int searchid = Convert.ToInt32(Console.ReadLine());
                    var q1 = from s in orderdata where s.id == searchid select s;
                    Console.WriteLine(q1);
                    break;
                case 2:
                    Console.WriteLine("输入商品");
                    string searchname = Console.ReadLine();
                    var q2 = from s in odetailsdata where s.odname == searchname select s;
                    Console.WriteLine(q2);
                    break;
                case 3:
                    Console.WriteLine("输入客户");
                    string searchcustomer = Console.ReadLine();
                    var q3 = from s in orderdata where s.customer == searchcustomer select s;
                    Console.WriteLine(q3);
                    break;
                case 4:
                    Console.WriteLine("输入金额");
                    int searchpri = Convert.ToInt32(Console.ReadLine());
                    var q4 = from s in odetailsdata where s.odpri == searchpri select s;
                    Console.WriteLine(q4);
                    break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //int id = Convert.ToInt32(Console.ReadLine());
            //string cus = Console.ReadLine();
            OrderService a = new OrderService();
            bool count = true;
            while (count)
            {
                a.AddOrder();
                a.RemoveOrder();
                a.SearchOrder();
                a.SortOrder();
            }
        }
    }
}
