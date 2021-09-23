using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homebuyer.Data {
    public interface IHomeDAO {
        // CRUD = Create, Retrieve, Update, Delete
        // Create -> POST
        // Retrieve -> GET
        // Update -> PUT
        // Delete -> DELETE

        public IEnumerable<Home> GetHomes();

        public Home GetHome(int id);
    }
}
