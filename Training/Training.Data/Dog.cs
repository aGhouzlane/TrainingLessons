using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    public class Dog : Animal {
        public bool Collar { get; set; }

        public Dog(string name, string color, bool collar) : base(name, color) {
            this.Collar = collar;
        }

        public override string Move() {
            return "I run";
        }

        public string Move(int number) {
            return $"the number: {number}";
        }

        public override string Speak() {
            return "BARK!!!";
        }

        public string DogMethod() {
            return "I am only in dog";
        }
    }
}
