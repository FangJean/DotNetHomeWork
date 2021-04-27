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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private OrderService orderService;
        public Order order;
        public List<Order> ods;
        private OrderDetails orderDetails;
        private OrderDetails modods;
        private Goods g;
        public Form3(Order order, List<Order> orders, OrderService s,OrderDetails od)
        {
            InitializeComponent();
            orderService = s;
            this.order = order;
            orderDetails = od;
            ods = orders;
        }
        private void buttonMod_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxModID.Text);
            bool istrue=false;
            foreach(Order a in ods)
            {
                if (a.id == id)
                {
                    istrue = true;
                }
            }
            if (istrue)
            {
                g.Name = textBoxModName.Text;
                g.ID = Convert.ToInt32(textBoxModID.Text);
                g.Price = Convert.ToInt32(textBoxModPri.Text);
                modods.odname = g;
                modods.odnum = Convert.ToInt32(textBoxModNum.Text);
                modods.odpri = Convert.ToInt32(textBoxModPri.Text);
                var model = ods.Where(c => c.id == id).FirstOrDefault();
                model.details.Clear();
                model.details.Add(modods);
            }
            bindingSourceModOrder.ResetBindings(false);
        }
    }
}
