using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework8
{
    public class Goods
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Goods() { }
        public Goods(int id,string name,int pr)
        {
            ID = id;
            Name = name;
            Price = pr;
        }
    }
}
