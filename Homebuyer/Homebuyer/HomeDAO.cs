using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homebuyer.Data {
    public class HomeDAO : IHomeDAO {
        //You would NEVER want this in a production system
        //NO hardcoded string or values EVER
        private string connString = "Data Source=0298L-898G503;Initial Catalog=homebuyer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<Home> GetHomes() {
            List<Home> homeList = new List<Home>();

            using (SqlConnection conn = new SqlConnection(connString)) {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Homes", conn);

                try {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read()) {
                        Home temp = new Home(reader["Address"].ToString(), double.Parse(reader["Price"].ToString()));
                        //Home temp = new Home(reader["Address"].ToString(), reader.GetDouble(reader.GetOrdinal("Price")));
                        temp.Id = Convert.ToInt32(reader["Id"]);

                        homeList.Add(temp);
                    }
                } catch (SqlException ex) {
                    Console.WriteLine("Could not get all the Homes!\n{0}", ex.Message);
                } finally {
                    conn.Close();
                }
            }

            return homeList;
        }
        
    }
}
