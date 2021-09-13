using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    public class Cat : Animal {
        public string EyeColor { get; set; }

        public Cat(string name, string color, string eye) : base(name, color) {
            this.EyeColor = eye;
            this.Tail2 = true;
        }

        public override string Move() {
            return "I sleep";
        }

        public override string Speak() {
            return "MEOW";
        }

        public bool GetTail() {
            return this.Tail2;
        }
    }
}
