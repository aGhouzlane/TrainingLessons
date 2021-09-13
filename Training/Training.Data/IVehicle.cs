using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    public interface IVehicle {
        public string GetInfo();
        public string StartEngine();
        public int GetMileage();
    }
}
