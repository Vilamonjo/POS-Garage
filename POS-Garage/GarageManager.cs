using System;

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
            Console.WriteLine("CUSTOMERS  "+(count+1).ToString("000")
                +"/"+listOfCustomers.Amount.ToString("000")+"  "+
                "DATE AND TIME (Soon)");

            Console.SetCursorPosition(0, 5);
            Console.WriteLine( listOfCustomers.Get(count) ); 

            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.Write("1.-Previous Customer      2.-Next Customer");
            Console.WriteLine("     3.-Search by record     4.-Search");
            Console.WriteLine("5.-Add Customer      0.-Exit     D.-Delete");
            
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1: //Previus 
                    if (count != 0)
                        count--;
                    break;

                case ConsoleKey.D2: //Next
                    //I cant allCustomers[count+1] != null
                    if (count != listOfCustomers.Amount -1)
                        count++;
                    break;

                case ConsoleKey.D3: //Search by number
                    SearchByNumber(listOfCustomers, ref count);
                    break;

                case ConsoleKey.D4: //Search by text
                    Console.Clear();
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("What are you looking for?");
                    string search = Console.ReadLine();
                    search = search.ToLower();
                    bool found = false;
                    for(int i = count; i < listOfCustomers.Amount; i++)
                    {
                        if (listOfCustomers.Get(i).GetName().ToLower().
                            Contains(search) ||
                            listOfCustomers.Get(i).GetID().ToLower().
                            Contains(search) ||
                            listOfCustomers.Get(i).GetResidence().ToLower().
                            Contains(search) ||
                            listOfCustomers.Get(i).GetCity().ToLower().
                            Contains(search) ||
                            listOfCustomers.Get(i).GetPostalCode().ToLower().
                            Contains(search) ||
                            listOfCustomers.Get(i).GetCountry().ToLower().
                            Contains(search) ||
                            listOfCustomers.Get(i).GetEMail().ToLower().
                            Contains(search) ||
                            listOfCustomers.Get(i).GetContact().ToLower().
                            Contains(search) ||
                            listOfCustomers.Get(i).GetComments().ToLower().
                            Contains(search) ||
                            listOfCustomers.Get(i).GetKey().ToLower().
                            Contains(search) ||
                            listOfCustomers.Get(i).GetPhoneNumber().ToString().
                            Contains(search))
                        {
                            found = true;
                            Console.Clear();
                            Console.SetCursorPosition(0, 10);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Found on the record "+(i+1).ToString("000"));
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    if(!found)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not found!");
                        //Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Do you want to search from the first record?");
                        if(Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            for(int i = 0; i < listOfCustomers.Amount; i++)
                            {
                                if (listOfCustomers.Get(i).GetName().ToLower().
                                    Contains(search) ||
                                    listOfCustomers.Get(i).GetID().ToLower().
                                    Contains(search) ||
                                    listOfCustomers.Get(i).GetResidence().ToLower().
                                    Contains(search) ||
                                    listOfCustomers.Get(i).GetCity().ToLower().
                                    Contains(search) ||
                                    listOfCustomers.Get(i).GetPostalCode().ToLower().
                                    Contains(search) ||
                                    listOfCustomers.Get(i).GetCountry().ToLower().
                                    Contains(search) ||
                                    listOfCustomers.Get(i).GetEMail().ToLower().
                                    Contains(search) ||
                                    listOfCustomers.Get(i).GetContact().ToLower().
                                    Contains(search) ||
                                    listOfCustomers.Get(i).GetComments().ToLower().
                                    Contains(search) ||
                                    listOfCustomers.Get(i).GetKey().ToLower().
                                    Contains(search) ||
                                    listOfCustomers.Get(i).GetPhoneNumber().ToString().
                                    Contains(search))
                                {
                                    found = true;
                                    Console.Clear();
                                    Console.SetCursorPosition(0, 10);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Found on the record " + count + 1.ToString("000"));
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            if(!found)
                            {
                                Console.Clear();
                                Console.SetCursorPosition(0, 10);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Not found!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                    break;

                case ConsoleKey.D5: //Add Customer
                    Console.Clear();
                    listOfCustomers.Add(GetDataToCreateCustomer());
                    break;

                case ConsoleKey.D:
                    Console.SetCursorPosition(0, Console.WindowHeight - 5);
                    Console.WriteLine("Delete this File? Y/N");
                    if(Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        listOfCustomers.Get(count).SetDeleted(true);
                    }
                        
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

    private static void SearchByNumber( ListOfCustomers list, ref int count)
    {
        string numberSTR;
        ushort number;
        do
        {
            Console.Clear();
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Enter the number you are looking for");
            numberSTR = Console.ReadLine();
        }
        while (!UInt16.TryParse(numberSTR, out number));
        if (number > 0 && number <= list.Amount)
        {
            count = number - 1;
        }
    }

    private static void ChangeColors()
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
    }
}

