using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    public class WrongItemException : Exception {
        public WrongItemException() { }

        public WrongItemException(string message) : base(message) { }

        public WrongItemException(string message, Exception inner) : base(message, inner) { }
    }
}
