using System;
using System.Linq;

class GarageManager
{
    static void Main(string[] args)
    {
        ChangeColors();

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
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("CUSTOMERS  "+(count+1).ToString("00")
                +"/"+listOfCustomers.Amount.ToString("00")+"  "+
                "DATE AND TIME (Soon)");

            Console.SetCursorPosition(0, 5);
            Console.WriteLine( listOfCustomers.Get(count) ); 

            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.WriteLine("1.-Previous Customer      2.-Next Customer");
            Console.WriteLine("5.-Add Customer      0.-Exit");
            
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    if (count != 0)
                        count--;
                    break;

                case ConsoleKey.D2:
                    //I cant allCustomers[count+1] != null
                    if (count != listOfCustomers.Amount -1)
                        count++;
                    break;

                case ConsoleKey.D5:
                    Console.Clear();
                    listOfCustomers.Add(GetDataToCreateCustomer());
                    
                    break;

                case ConsoleKey.D0:
                    exit = true;
                    break;

            }
        } while (!exit);
    }

    private static Customer GetDataToCreateCustomer()
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

        
        Customer customerToReturn = new Customer(
            name, iD, residence, city, postalCode, country,
            phone, eMail, contact, observation);

        return customerToReturn;
    }

    private static void ChangeColors()
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
    }
}

