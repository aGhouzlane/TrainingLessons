using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    public class Sedan : IVehicle {
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public Sedan() { }

        public Sedan(string year, string make, string model) {
            this.Year = year;
            this.Make = make;
            this.Model = model;
        }

        public string GetInfo() {
            return $"I am a {this.Year} {this.Make} {this.Model}";
        }

        public int GetMileage() {
            //user does something wrong
            throw new InvalidOperationException();
        }

        public string StartEngine() {
            return "Vroom";
        }

        public string CanDrive(int age) {
            if (age >= 18) {
                return "Full License";
            } else if (age >= 16) {
                return "Learner's";
            } else {
                return "No Driving";
            }
        }
    }
}
