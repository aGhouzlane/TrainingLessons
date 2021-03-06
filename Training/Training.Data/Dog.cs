using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    public class Dog : Animal, IComparable<Dog> {
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

        public override string View() {
            return base.View() + " Some other code.";
        }

        public string DogMethod() {
            return "I am only in dog";
        }

        public void ThreadTest() {
            Console.WriteLine($"I ran in a thread. Name: {this.Name}");
        }

        public override string ToString() {
            return $"[Dog: {Name}, {Color}, {Collar}]";
        }

        public int CompareTo(Dog other) {
            return String.Compare(this.Name, other.Name);
        }
    }
}
