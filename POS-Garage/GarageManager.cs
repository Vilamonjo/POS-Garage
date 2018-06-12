using System;
using System.Linq;

class GarageManager
{
    static void Main(string[] args)
    {
        DisplayMenuAnUsersControl();
    }

    public static void DisplayMenuAnUsersControl()
    {
        bool exit = false;
        ListOfCustomers listOfCustomers = new ListOfCustomers();
        int count = 0;
        do
        {
            Console.Clear();

            Console.SetCursorPosition(0, 5);
            Console.WriteLine( listOfCustomers.GetCustomer(count) ); 

            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.WriteLine("1.-Previus Customer      2.-Next Customer");
            Console.WriteLine("5.-Add Customer      0.-Exit");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    if (count != 0)
                        count--;
                    break;

                case "2":
                    //I cant allCustomers[count+1] != null
                    if (count != listOfCustomers.Amount -1)
                        count++;
                    break;

                case "5":
                    Console.Clear();
                    listOfCustomers.AddCustomer(GetDataToCreateCustomer());
                    
                    break;

                case "0":
                    exit = true;
                    break;

            }
        } while (!exit);
    }

    public static Customer GetDataToCreateCustomer()
    {
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("ID: ");
        string iD = Console.ReadLine();

        Console.WriteLine("Residence: ");
        string residence = Console.ReadLine();

        Console.WriteLine("City: ");
        string city = Console.ReadLine();

        Console.WriteLine("Postal Code: ");
        string postalCode = Console.ReadLine();

        Console.WriteLine("Country: ");
        string country = Console.ReadLine();

        Console.WriteLine("Phone Number: ");
        string phoneSTR;
        uint phone;
        do
        {
            phoneSTR = Console.ReadLine();
        } while (!UInt32.TryParse(phoneSTR, out phone));

        Console.WriteLine("eMail: ");
        string eMail = Console.ReadLine();
        Console.WriteLine("Contact: ");
        string contact = Console.ReadLine();
        Console.WriteLine("Observations: ");
        string observation = Console.ReadLine();

        string key = "FFMMAA"; //?????
        Customer customerToReturn = new Customer(
            key, name, iD, residence, city, postalCode, country,
            phone, eMail, contact, observation);

        return customerToReturn;
    }


}

