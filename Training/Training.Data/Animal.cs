using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    //Sealed keyword stops classes from inhereting from the class
    //public sealed class Animal
    public abstract class Animal {
        public string Name { get; set; }
        public string Color { get; set; }
        private bool Tail { get; set; }
        protected bool Tail2 { get; set; }

        public Animal() {
            this.Tail = true;
            this.Tail2 = true;
        }

        public Animal(string name, string color) {
            this.Name = name;
            this.Color = color;
        }

        public abstract string Speak();

        public virtual string View() {
            return $"I am a {this.Color} animal.";
        }

        public abstract string Move();
    }
}
