using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework11
{
    public class OrderDetails
    {
        public string ID { get; set; }
        public int index { get; set; }
        public string goodsID { get; set; }
        public Goods goodsitem { get; set; }
        public string goodsname { get => goodsitem != null ? this.goodsitem.Name : ""; }
        public double unitprice { get => goodsitem != null ? this.goodsitem.Price : 0.0; }
        public OrderDetails() {
            ID = Guid.NewGuid().ToString();
        }
        public OrderDetails(int num, Goods goods, int p)
        {
            index = num;
            odpri = p;
            odname = goods;
        }
        public override string ToString()
        {
            return "商品:" + goodsname + "价格:" + unitprice;
        }
        public override bool Equals(object obj)
        {
            var item = obj as OrderDetails;
            return item != null && goodsname == item.goodsname;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
