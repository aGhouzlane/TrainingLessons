using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training {
    public class CSVData {
        public string Name { get; set; }
        public int Years { get; set; }
        public string HairColor { get; set; }

        public CSVData(string name, int years, string hair) {
            this.Name = name;
            this.Years = years;
            this.HairColor = hair;
        }

        public override string ToString() {
            return $"Name: {this.Name}, Years: {this.Years}, Hair Color: {this.HairColor}";
        }
    }
}
