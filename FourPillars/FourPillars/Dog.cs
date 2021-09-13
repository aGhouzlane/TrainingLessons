using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillars {
    public class Dog : Animal {

        public Dog() {

        }

        public Dog(string name, int id) {
            this.Name = name;
            this.Id = id;
            //this._field = 3;
            //this._field2 = 4;
        }

        public int MyProperty { get; set; }

        public string DogOnly() {
            return "only in dog";
        }
    }
}
