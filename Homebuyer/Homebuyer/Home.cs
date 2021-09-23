using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homebuyer.Data {
    public class Home {
        public int Id { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        // ? after a data type makes it a nullable value, int? could be null or could be an integer
        // int can never be null

        public Home() { }

        public Home(string address, double price) {
            this.Address = address;
            this.Price = price;
        }
    }
}
