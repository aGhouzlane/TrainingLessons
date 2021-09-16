using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threading {
    public sealed class MySingleton2 {
        private static readonly object mutex = new object();
        private static MySingleton2 instance = null;

        private MySingleton2() { }

        //this is threadsafe
        public static MySingleton2 Instance {
            get {
                //as much code as you want
                //critical section
                lock (mutex) {
                    if (instance == null) {
                        instance = new MySingleton2();
                    }
                    return instance;
                }
                //as much code as you want
            }
        }
    }
}
