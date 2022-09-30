using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO.Net
{
    public class ADO_AddressBook
    {
        /// <summary>
        /// Establish Connection using connection string
        /// </summary>
        public static string ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=AddressBook_ServiceDB;Integrated Security=True";
        public static void GetAllEmployees()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConnectionString);
                //open connection
                connection.Open();
                using (connection)
                {
                    Console.WriteLine("Successfully connection created");
                }
                //Close connection
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
