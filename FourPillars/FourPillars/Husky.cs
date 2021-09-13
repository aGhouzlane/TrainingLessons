using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillars {
    //can only extend one class, but can impleemnt as many interfaces as you want
    public class Husky : Dog, IAnimal, Interface2 {

        public Husky() {

        }

        public Husky(string name, int id) : base(name, id) {

        }

        public override string Speak() {
            return base.Speak() + " Bark!!";
        }

        public string HuskyOnly() {
            return "only in Husky";
        }

        public string Move() {
            throw new NotImplementedException();
        }

        public string Eat() {
            throw new NotImplementedException();
        }

        public int myMethod() {
            throw new NotImplementedException();
        }
    }
}
