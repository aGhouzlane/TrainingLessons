using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Factories {
    public abstract class Remote {
        public abstract string RemoteType { get; }
        public abstract string Company { get; set; }
        public Wire Wire { get; set; }
        public Batteries Batteries { get; set; }
    }
}
