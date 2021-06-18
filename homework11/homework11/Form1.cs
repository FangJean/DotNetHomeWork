using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework11
{
    public partial class Form1 : Form
    {
        public List<Order> orders;
        public List<OrderDetails> odlist;
        public OrderService orderservice;
        private OrderDetails od;
        BindingSource binding = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            Goods apple = new Goods(1, "apple", 100);
            Client c = new Client(1,"ZhangSan");
            od = new OrderDetails(1, new Goods(1, "apple", 100), 100);
            Order o=new Order(1, "ZhangSan", new List<OrderDetails>());
            o.AddItem(new OrderDetails(1, new Goods(1, "apple", 100), 100));
            odlist = new List<OrderDetails>();
            odlist.Add(od);

            orderservice = new OrderService();
            orderservice.AddOrder(o);
            orders = orderservice.orderdata;

            OrderBindingSourse.DataSource = orderservice.orderdata;

        }
        private void button_AddOrder_Click(object sender, EventArgs e)//添加/删除订单
        {
            Form2 form2 = new Form2(new Order(),orderservice);
            form2.ShowDialog();
        }

        private void button_ModifyOrder_Click(object sender, EventArgs e)//修改订单
        {
            Form3 form3 = new Form3(new Order(),orders, orderservice,od);
            form3.ShowDialog();
        }

        private void button_DeleteOrder_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(new Order(), orderservice);
            form2.ShowDialog();
        }

        private void button_ExportOrder_Click(object sender, EventArgs e)
        {
            orderservice.Export("../xml");
        }

        private void button_ImportOrder_Click(object sender, EventArgs e)
        {
            orderservice.Import("../xml");
        }
    }
}
