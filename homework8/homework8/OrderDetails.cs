using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework8
{
    public class OrderDetails
    {
        public int odnum { get; set; }
        public int odpri { get; set; }
        public Goods odname { get; set; }
        public OrderDetails() { }
        public OrderDetails(int num, Goods goods, int p)
        {
            odnum = num;
            odpri = p;
            odname = goods;
        }
        public override string ToString()
        {
            return "商品:" + odname + "数目:" + odnum + " " + "价格:" + odpri;
        }
    }
}
