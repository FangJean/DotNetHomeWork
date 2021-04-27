using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace homework6_2
{
    public class Test
    {
        Goods apple = new Goods(1, "apple", 100);
        Goods egg = new Goods(2, "egg", 15);
        Client c = new Client(1, "ZhangSan");
        Client c = new Client(2, "LiSi");

         public void Init()
        {
            Order o = new Order(1, "ZhangSan", new List<OrderDetails>());
            o.AddItem(new OrderDetails(1, new Goods(1, "apple", 100), 100));

            Order o2 = new Order(2, "LiSi", new List<OrderDetails>());
            o2.AddItem(new OrderDetails(2, new Goods(2, "apple", 15), 15));

            orderService = new OrderService();
            orderService.AddOrder(o);
            orderService.AddOrder(o2);
        }
        public void AddOrderTest()
        {
            Order o3 = new Order(4, "XiaoMing", new List<OrderDetails>());
            o3.AddItem(new OrderDetails(4, new Goods(4, "apple", 24), 24));
            orderService.AddOrder(o4);
        }
        public void UpdateOrderTest()
        {
            Order o3 = new Order(4, "XiaoMing", new List<OrderDetails>());
            o3.UpDate(new OrderDetails(5, new Goods(5, "banana", 38), 38));
            orderService.Update(o3);
        }
        public void RemoveOrderTest()
        {
            RemoveOrder(o3);
        }
        public void ExportTest()
        {
            String file = "temp.xml";
            orderService.Export(file);
        }
        public void ImportTest1()
        {
            orderService.Import("../../expectedOrders.xml");
        }
    }