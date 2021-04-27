using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace homework8
{
    public class OrderService
    {
        public List<Order> orderdata = new List<Order>();
        private List<OrderDetails> odetailsdata = new List<OrderDetails>();//把订单详细修改为private类型
        public OrderService() { }
        public void AddOrder(Order ord)
        {
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
                throw new AccessViolationException($"错误，订单存在");
            }
            else//输入订单详细内容
            {
                orderdata.Add(ord);
            }
        }
        public void RemoveOrder(int id)//输入id删除订单
        {
            foreach (Order e in orderdata) {
                if (id == e.id)
                {
                    orderdata.Remove(e);
                }
            }
        }
        public void SortOrder()//按照订单号大小进行排序
        {
            orderdata.Sort((x, y) => x.id.CompareTo(y.id));
        }
        public void SearchOrder()//查询修改
        {
            Console.WriteLine("查询单号【1】，查询客户【2】，查询金额【3】");
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
                        Console.WriteLine("[0] [1] [2]", b1.id, b1.customer);
                    }
                    break;
                case 2:
                    Console.WriteLine("输入客户");
                    string searchcustomer = Console.ReadLine();
                    var q3 = from s in orderdata where s.customer == searchcustomer select s;
                    List<Order> l3 = q3.ToList();
                    foreach (Order b3 in l3)
                    {
                        Console.WriteLine("[0] [1] [2]", b3.id, b3.customer);
                    }
                    break;
                case 3:
                    Console.WriteLine("输入金额");
                    int searchpri = Convert.ToInt32(Console.ReadLine());
                    var q4 = from s in odetailsdata where s.odpri == searchpri select s;
                    List<OrderDetails> l4 = q4.ToList();
                    foreach (OrderDetails b4 in l4)
                    {
                        Console.WriteLine("[0] [1] [2]", b4.odname, b4.odnum, b4.odpri);
                    }
                    break;
            }
        }
        public void Export(string path)//将所有订单序列化为.xml文件
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Create,FileAccess.Write))
            {
                xs.Serialize(fs, orderdata);
            }
        }
        public void Import(string path)//将.xml文件的内容载入订单
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open,FileAccess.Read))
            {
                List<Order> xmlorder = (List<Order>)xs.Deserialize(fs);
            }
        }
    }
}
