using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework11
{
    public class Goods
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Goods() {
            ID = Guid.NewGuid().ToString();
        }
        public Goods(string name,int pr):this()
        {
            
            Name = name;
            Price = pr;
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null && ID == goods.ID && Name == goods.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
