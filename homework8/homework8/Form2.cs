using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework8
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private OrderService orderService;
        public Order order;
        public Form2(Order order,OrderService s)
        {
            InitializeComponent();
            orderService = s;
            this.order = order;

        }
        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            Order o = new Order(1, "ZhangSan", new List<OrderDetails>());
            int num = Convert.ToInt32(textBoxAddNum.Text);
            int pri = Convert.ToInt32(textBoxAddPri.Text);
            string name = textBoxAddName.Text;
            o.AddItem(new OrderDetails(num, new Goods(num, name, pri), pri));
            orderService.AddOrder(o);
            OrderD2BindingSource.ResetBindings(false);
        }
        private void buttonRemoveOrder_Click(object sender, EventArgs e)
        {
            orderService.RemoveOrder(Convert.ToInt32(textBoxAddID.Text));
            OrderD2BindingSource.ResetBindings(false);

        }
    }
}
