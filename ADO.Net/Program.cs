namespace ADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To ADO.NET");
            Console.WriteLine("Enter 1 for Connection checking");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    ADO_AddressBook.DataBaseConnection();
                    break;
            }

        }
            
    }
}
