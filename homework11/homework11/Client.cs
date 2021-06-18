using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework11
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Client() {
            ID = Guid.NewGuid().ToString();
        }
        public Client(string name):this()
        {
            
            Name = name;
        }

        public override bool Equals(object obj)
        {
            var client = obj as Client;
            return client != null && ID == client.ID && Name == client.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
