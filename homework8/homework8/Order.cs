using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework8
{
    public class Order
    {
        //public static string goods { get; set; }
        public int id{ get; set; }
        public string customer { get; set; }
        public List<OrderDetails> details;
        //public string oname;
        //public int onum;
        //public int oprice;
        public Order() { }
        public Order(int i, string cus, List<OrderDetails> items)
        {
            id = i;
            customer = cus;
            details = (items == null) ? new List<OrderDetails>() : items;
        }
        public List<OrderDetails> Details
        {
            get { return details; }
        }
        public void AddItem(OrderDetails item)
        {
            if (Details.Contains(item))
            {
                throw new ApplicationException($"订单已经存在");
            }
            Details.Add(item);
        }
        public void RemoveItem(OrderDetails item)
        {
            details.Remove(item);
        }
        public override string ToString()
        {
            return "订单号:" + id + "客户:" + customer;
        }
        //public override bool Equals(System.Object obj)
        //{
            //Order a = obj as Order;
            //return this.id == a.id;
        //}
        //public override int GetHashCode()
        //{
            //return base.GetHashCode();
        //}
    }
}
