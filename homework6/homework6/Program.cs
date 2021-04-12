using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace homework6
{
    public class Order
    {
        public string goods;
        public int id;
        public string customer;
        private List<OrderDetails> details;
        //public string oname;
        //public int onum;
        //public int oprice;
        public Order() { }
        public Order(int i, string cus, List<OrderDetails> d)
        {
            id = i;
            customer = cus;
            details = d;
        }
        public override string ToString()
        {
            return "订单号:" + id + "客户:" + customer;
        }
        public override bool Equals(System.Object obj)
        {
            Order a = obj as Order;
            return this.id == a.id;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public class OrderDetails : Order
    {
        public int odnum;
        public int odpri;
        public string odname;
        public OrderDetails() { }
        public OrderDetails(int num, int p, string name)
        {
            odnum = num;
            odpri = p;
            odname = name;
        }
        public override string ToString()
        {
            return "商品:" + odname + "数目:" + odnum + " " + "价格:" + odpri;
        }
    }
    public class OrderService
    {
        public List<Order> orderdata = new List<Order>();
        private List<OrderDetails> odetailsdata = new List<OrderDetails>();//把订单详细修改为private类型
        public OrderService() { }
        public void AddOrder()
        {
            Console.WriteLine("输入订单编号");//输入编号，int用于排序
            int orderid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("输入客户");//输入客户
            string person = Console.ReadLine();
            Console.WriteLine("输入订单项");//输入详细的订单内容
            Order ord = new Order(orderid, person, odetailsdata);
            bool same = false;
            foreach (Order e in orderdata)
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
                OrderDetails ordd = new OrderDetails(price, num, name);
                odetailsdata.Add(ordd);//加入list
            }
        }
        public void RemoveOrder()//输入id删除订单
        {
            Console.WriteLine("输入id删除订单");
            int deid = Convert.ToInt32(Console.ReadLine());
            bool tf = true;
            Console.WriteLine("是否输入错误(0错误,1正确)");
            int tor = Convert.ToInt32(Console.ReadLine());
            if (tor == 0)
            {
                tf = false;
            }
            foreach (Order e in orderdata)//foreach循环不能进行remove/add操作
            {
                if (e.id == deid && tf)
                {
                    orderdata.RemoveAt(e.id);
                }
                break;//删除后直接结束循环避免抛异常
            }
        }
        public void SortOrder()//按照订单号大小进行排序
        {
            orderdata.Sort((x, y) => x.id.CompareTo(y.id));
        }
        public void SearchOrder()//查询修改
        {
            Console.WriteLine("查询单号【1】，查询商品【2】，查询客户【3】，查询金额【4】");
            int searchnum = Convert.ToInt32(Console.ReadLine());
            switch (searchnum)
            {
                case 1:
                    Console.WriteLine("输入单号");
                    int searchid = Convert.ToInt32(Console.ReadLine());
                    var q1 = from s in orderdata where s.id == searchid select s;
                    List<Order> l1 = q1.ToList();
                    foreach (Order b1 in l1)
                    {
                        Console.WriteLine("[0] [1] [2]", b1.id, b1.customer, b1.goods);
                    }
                    break;
                case 2:
                    Console.WriteLine("输入商品");
                    string searchname = Console.ReadLine();
                    var q2 = from s in odetailsdata where s.odname == searchname select s;
                    List<OrderDetails> l2 = q2.ToList();
                    foreach (OrderDetails b2 in l2)
                    {
                        Console.WriteLine("[0] [1] [2] [3]", b2.id,b2.odname,b2.odnum,b2.odpri);
                    }
                    break;
                case 3:
                    Console.WriteLine("输入客户");
                    string searchcustomer = Console.ReadLine();
                    var q3 = from s in orderdata where s.customer == searchcustomer select s;
                    List<Order> l3 = q3.ToList();
                    foreach (Order b3 in l3)
                    {
                        Console.WriteLine("[0] [1] [2]", b3.id, b3.customer, b3.goods);
                    }
                    break;
                case 4:
                    Console.WriteLine("输入金额");
                    int searchpri = Convert.ToInt32(Console.ReadLine());
                    var q4 = from s in odetailsdata where s.odpri == searchpri select s;
                    List<OrderDetails> l4 = q4.ToList();
                    foreach (OrderDetails b4 in l4)
                    {
                        Console.WriteLine("[0] [1] [2] [3]", b4.id, b4.odname, b4.odnum, b4.odpri);
                    }
                    break;
            }
        }
        public void Export()//将所有订单序列化为.xml文件
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("order.xml", FileMode.Create))
            {
                xs.Serialize(fs, orderdata);
            }
        }
        public void Import()//将.xml文件的内容载入订单
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using(FileStream fs=new FileStream("order.xml", FileMode.Open))
            {
                List<Order> xmlorder = (List<Order>)xs.Deserialize(fs);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService a = new OrderService();
            bool count = true;
            while (count)
            {
                a.AddOrder();
                a.RemoveOrder();
                a.SearchOrder();
                a.SortOrder();
                a.Export();
                Console.WriteLine("是否继续添加订单(0否1是)");
                int c = Convert.ToInt32(Console.ReadLine());
                if (c == 0)
                {
                    count = false;
                }
            }
        }
    }
}
