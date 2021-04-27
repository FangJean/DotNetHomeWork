using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework8
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Client() { }
        public Client(int id,string name)
        {
            ID = id;
            Name = name;
        }
    }
}
