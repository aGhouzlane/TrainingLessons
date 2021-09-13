using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training {
    public class Day1 {
        //private int _id;

        //public int Id {
        //    get { return _id; }
        //    set {
        //        if (value > 0) {
        //            _id = value;
        //        }
        //    }
        //}

        public string Name { get; set; }
        public int Id { get; set; }

        public Day1() { }

        public Day1(int id, string name) {
            this.Id = id;
            this.Name = name;
        }

        public string SayHello() {
            //return "Hello my name is " + this.Name;

            //return @"Hello
            //         my 
            //         name is 
            //         " + this.Name
            //         + @" and
            //           my id is " + this.Id;

            //return @"some random path: C:\user\something\file.txt pathenthesis ""quote text""";

            return $"Hello my name is {this.Name} and my id is {this.Id}";
        }

        public IEnumerable<int> CovariantReturn() {
            //return new List<int>();
            //return new LinkedList<int>();
            return new HashSet<int>();
        }
    }
}
