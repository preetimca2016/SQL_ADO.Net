using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBook_Contacts contacts = new AddressBook_Contacts()
            {
                FirstName = "Preeti",
                Address="Delhi",
                PhoneNumber=3439543543
            };
            Console.WriteLine("Welcome To ADO.NET");
            Console.WriteLine("Enter 1 for Connection checking");
            Console.WriteLine("Enter 2 Get All the Employee detail feom database table");
            Console.WriteLine("Enter 3 for Add Employee details");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    ADO_AddressBook.DataBaseConnection();
                    break;
                case 2:
                    ADO_AddressBook.GetAllEmployee();
                    break;
                case 3:
                    ADO_AddressBook.AddEmployee(contacts);
                    break;
            }

        }
            
    }
}
