using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    public class VirtualAnimal {
        public string Name { get; set; }
        public string Color { get; set; }


        public VirtualAnimal() { }

        public VirtualAnimal(string name, string color) {
            this.Name = name;
            this.Color = color;
        }

        public virtual string Speak() {
            throw new NotImplementedException();
        }

        public string View() {
            return $"I am a {this.Color} animal.";
        }

        public virtual string Move() {
            return "I walk";
        }
    }
}
