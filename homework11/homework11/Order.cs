using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework11
{
    public class Order:IComparable<Order>
    {
        //public static string goods { get; set; }
        public string orderid{ get; set; }
        public string customerid { get; set; }
        public Client customer { get; set; }
        public string customername { get => (customer != null) ? customer.Name : ""; }
        public DateTime createtime { get; set; }
        public List<OrderDetails> details { get; set; }
        //public string oname;
        //public int onum;
        //public int oprice;
        public Order() {
            orderid = Guid.NewGuid().ToString();
            details = new List<OrderDetails>();
            createtime = DateTime.Now;
        }
        public Order(string id, Client cus, List<OrderDetails> items)
        {
            orderid = id;
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
        public override bool Equals(System.Object obj)
        {
            var order = obj as Order;
            return order != null && orderid == order.orderid;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int CompareTo(Order other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.orderid.CompareTo(other.orderid);
        }
    }
}
