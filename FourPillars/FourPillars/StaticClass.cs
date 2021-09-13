using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillars {
    public class StaticClass {
        public static int counter = 0;

        public StaticClass() {
            counter++;
        }

        public static void SayHello() {
            Console.WriteLine($"Hello Static World {counter}");
        }

        public void SayHello2() {
            Console.WriteLine("Hello Static World");
        }
    }
}
