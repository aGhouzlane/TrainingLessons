using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillars {

    public abstract class Animal 
    //public sealed class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        protected int _field;
        //private protected int _field2;

        public int Field {
            get { return _field; }
            set {
                if (value > 0) {
                    _field = value;
                } else {
                    throw new InvalidOperationException();
                }
            }
        }

        public Animal() { }

        public Animal(int id, string name) {
            this.Id = id;
            this.Name = name;
        }

        public virtual string Speak() {
            return "Words";
        }

        public string Walk(int distance) {
            return $"I walked {distance}";
        }

        public string GetInfo() {
            return $"My name is {this.Name}, and my id is {this.Id}";
        }
    }
}
