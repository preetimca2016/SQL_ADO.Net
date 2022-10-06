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
        public static void DataBaseConnection()
        {
            // Establishing the connection using the Sqlconnection.  
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
        //UC2- Retrieve All employee detail Create addressbook table with first and last names, address, city, state, zip, phone number and email as its attributes 
        public static void GetAllEmployee()
                                                                                                                  {
            AddressBook_Contacts contacts = new AddressBook_Contacts();
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection = new SqlConnection(ConnectionString);
                using (connection)
                {
                    //query to get all the employee detail from the table
                    string query = "select * from AddressBookDB";
                    // Impementing the command on the connection fetched database table
                    // Create a command object  
                    SqlCommand cmd = new SqlCommand(query, connection);
                    //Open the connection.
                    connection.Open();
                    // executing the sql data reader to fetch the records
                    // Call ExecuteReader to return a SQlDataReader 
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        // Loop through all the rows in the DataTableReader
                        // Mapping the data to the employee model class object
                        while (reader.Read())
                        {
                            
                            contacts.FirstName = reader.GetString(1);
                            contacts.LastName = reader.GetString(2);
                            contacts.Address = reader.GetString(3);
                            contacts.City = reader.GetString(4);
                            contacts.State = reader.GetString(5);
                            contacts.Zip = reader.GetInt32(6);
                            contacts.PhoneNumber = reader.GetInt64(7);
                            contacts.EmailId = reader.GetString(8);
                            //prinitng the output
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", contacts.FirstName, contacts.LastName,
                                contacts.Address, contacts.City, contacts.State, contacts.Zip, contacts.PhoneNumber, contacts.EmailId);
                            Console.WriteLine("\n");
                        }
                    }
                }  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void AddEmployee(AddressBook_Contacts contacts)
        {
            SqlConnection connection = null;
            try
            {
                string query = "select * from AddressBookDB";
                //AddressBook_Contacts contacts = new AddressBook_Contacts();
                connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("dbo.sp_AddEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", contacts.FirstName);
                command.Parameters.AddWithValue("@Address", contacts.Address);
                command.Parameters.AddWithValue("@Phone", contacts.PhoneNumber);
                int num = command.ExecuteNonQuery();
                if(num!=0)
                    Console.WriteLine("Employee Updated Successfully");
                else
                {
                    Console.WriteLine("Something Went Wrong");
                }
                connection.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void UpdateEmployee(AddressBook_Contacts contacts)
        {
            SqlConnection connection = null;
            try
            {
                string query = "select * from AddressBook_DB";
                //AddressBook_Contacts contacts = new AddressBook_Contacts();
                connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("dbo.sp_UpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", contacts.FirstName);
                command.Parameters.AddWithValue("@Address", contacts.Address);
                command.Parameters.AddWithValue("@Id", contacts.EmployeeId);
                int num = command.ExecuteNonQuery();
                if (num != 0)
                    Console.WriteLine("Employee Added Successfully");
                else
                {
                    Console.WriteLine("Something Went Wrong");
                }
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void DeleteEmployee(AddressBook_Contacts contacts)
        {
            SqlConnection connection = null;
            try
            {
                string query = "select * from AddressBook_DB";
                //AddressBook_Contacts contacts = new AddressBook_Contacts();
                connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("dbo.sp_DeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", contacts.FirstName);
                command.Parameters.AddWithValue("@Address", contacts.Address);
                command.Parameters.AddWithValue("@Id", contacts.EmployeeId);
                int num = command.ExecuteNonQuery();
                if (num != 0)
                    Console.WriteLine("Employee deleted Successfully");
                else
                {
                    Console.WriteLine("Something Went Wrong");
                }
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
