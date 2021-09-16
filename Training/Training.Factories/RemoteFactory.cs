using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Factories {
    //each factory will handle it's own setup and getting the different pieces it needs
    public abstract class RemoteFactory {
        public abstract Remote GetRemote();
    }
}
