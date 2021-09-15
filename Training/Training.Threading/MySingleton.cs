using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threading {
    public sealed class MySingleton {
        private static MySingleton instance = null;

        private MySingleton() { }

        //this is not threadsafe
        public static MySingleton Instance {
            get {
                if (instance == null) {
                    instance = new MySingleton();
                }
                return instance;
            }
        }
    }
}
