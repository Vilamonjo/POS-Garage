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
            Console.Write("     3.-Search by record     4.-Search");
            Console.WriteLine("     5.-Add Customer");
            Console.Write("6.-Edit record            0.-Exit     ");
            Console.WriteLine("         D.- Delete");
            
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1: //Previus 
                    if (count != 0)
                        count--;
                    break;

                case ConsoleKey.NumPad2:
                case ConsoleKey.D2: //Next
                    //I cant allCustomers[count+1] != null
                    if (count != listOfCustomers.Amount -1)
                        count++;
                    break;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3: //Search by number
                    SearchByNumber(listOfCustomers, ref count);
                    break;

                case ConsoleKey.NumPad4:
                case ConsoleKey.D4: //Search by text
                    SearchByText(listOfCustomers, ref count);
                    break;

                case ConsoleKey.NumPad5:
                case ConsoleKey.D5: //Add Customer
                    Console.Clear();
                    listOfCustomers.Add(GetDataToCreateCustomer());
                    break;

                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    Modify (listOfCustomers, count);
                    break;

                case ConsoleKey.D: //Delete
                    Console.SetCursorPosition(0, Console.WindowHeight - 5);
                    Console.WriteLine("Delete this Record? Y/N");
                    if(Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        listOfCustomers.Get(count).SetDeleted(true);
                    }
                        
                    break;

                case ConsoleKey.NumPad0:
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
        Console.WriteLine("Comments: ");
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
        else
        {
            Console.WriteLine("Wrong Number!");
            Console.ReadLine();
        }
            
    }

    private static void SearchByText(ListOfCustomers listOfCustomers, ref int count)
    {
        Console.Clear();
        Console.SetCursorPosition(0, 10);
        Console.WriteLine("What are you looking for?");
        string search = Console.ReadLine();
        search = search.ToLower();
        bool found = false;
        do
        {
            if (listOfCustomers.Get(count).GetName().ToLower().
                Contains(search) ||
                listOfCustomers.Get(count).GetID().ToLower().
                Contains(search) ||
                listOfCustomers.Get(count).GetResidence().ToLower().
                Contains(search) ||
                listOfCustomers.Get(count).GetCity().ToLower().
                Contains(search) ||
                listOfCustomers.Get(count).GetPostalCode().ToLower().
                Contains(search) ||
                listOfCustomers.Get(count).GetCountry().ToLower().
                Contains(search) ||
                listOfCustomers.Get(count).GetEMail().ToLower().
                Contains(search) ||
                listOfCustomers.Get(count).GetContact().ToLower().
                Contains(search) ||
                listOfCustomers.Get(count).GetComments().ToLower().
                Contains(search) ||
                listOfCustomers.Get(count).GetKey().ToLower().
                Contains(search) ||
                listOfCustomers.Get(count).GetPhoneNumber().ToString().
                Contains(search))
            {
                found = true;
                Console.Clear();
                Console.SetCursorPosition(0, 10);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Found on the record " + (count + 1).ToString("000"));
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                count--;
            }
            count++;
        }
        while (!found && count < listOfCustomers.Amount - 1);
        if (!found)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not found!");
            //Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Do you want to search from the first record?");
            count = 0;
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {

                do
                {
                    if (listOfCustomers.Get(count).GetName().ToLower().
                        Contains(search) ||
                        listOfCustomers.Get(count).GetID().ToLower().
                        Contains(search) ||
                        listOfCustomers.Get(count).GetResidence().ToLower().
                        Contains(search) ||
                        listOfCustomers.Get(count).GetCity().ToLower().
                        Contains(search) ||
                        listOfCustomers.Get(count).GetPostalCode().ToLower().
                        Contains(search) ||
                        listOfCustomers.Get(count).GetCountry().ToLower().
                        Contains(search) ||
                        listOfCustomers.Get(count).GetEMail().ToLower().
                        Contains(search) ||
                        listOfCustomers.Get(count).GetContact().ToLower().
                        Contains(search) ||
                        listOfCustomers.Get(count).GetComments().ToLower().
                        Contains(search) ||
                        listOfCustomers.Get(count).GetKey().ToLower().
                        Contains(search) ||
                        listOfCustomers.Get(count).GetPhoneNumber().ToString().
                        Contains(search))
                    {
                        found = true;
                        Console.Clear();
                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Found on the record " + (count + 1).ToString("000"));
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        count--;
                    }
                    count++;
                }
                while (!found && count < listOfCustomers.Amount - 1);

                if (!found)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 10);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not found!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    count = 0;
                }
            }
        }
    }

    private static void Modify(ListOfCustomers listOfCustomers, int count)
    {
        Console.Clear();
        Console.SetCursorPosition(0, Console.WindowHeight - 2);
        Console.WriteLine("To not change something, just press Enter");
        Console.SetCursorPosition(0, 5);
        string aux;
        aux = listOfCustomers.Get(count).GetName();

        Console.WriteLine("Name: "+ listOfCustomers.Get(count).GetName());
        string name = Console.ReadLine();
        if (name == "")
            name = aux;
        listOfCustomers.Get(count).SetName(name);
       

        aux = listOfCustomers.Get(count).GetID();
        Console.WriteLine("ID: " + listOfCustomers.Get(count).GetID());
        string iD = Console.ReadLine();
        if (iD == "")
            iD = aux;
        listOfCustomers.Get(count).SetID(iD);

        aux = listOfCustomers.Get(count).GetResidence();
        Console.WriteLine("Residence: " + listOfCustomers.Get(count).GetResidence());
        string residence = Console.ReadLine();
        if (residence == "")
            residence = aux;
        listOfCustomers.Get(count).SetResidence(residence);

        aux = listOfCustomers.Get(count).GetCity();
        Console.WriteLine("City: " + listOfCustomers.Get(count).GetCity());
        string city = Console.ReadLine();
        if (city == "")
            city = aux;
        listOfCustomers.Get(count).SetCity(city);

        aux = listOfCustomers.Get(count).GetPostalCode();
        Console.WriteLine("Postal Code: " + listOfCustomers.Get(count).GetPostalCode());
        string postalCode = Console.ReadLine();
        if (postalCode == "")
            postalCode = aux;
        listOfCustomers.Get(count).SetPostalCode(postalCode);

        aux = listOfCustomers.Get(count).GetCountry();
        Console.WriteLine("Country: " + listOfCustomers.Get(count).GetCountry());
        string country = Console.ReadLine();
        if (country == "")
            country = aux;
        listOfCustomers.Get(count).SetCountry(country);

        uint auxUINT = listOfCustomers.Get(count).GetPhoneNumber();
        Console.WriteLine("Phone Number: " + listOfCustomers.Get(count).GetPhoneNumber());
        string phoneSTR;
        uint phone;
        do
        {
            phoneSTR = Console.ReadLine();
        } while (( !UInt32.TryParse (phoneSTR, out phone)) && phoneSTR != "");
        if (phoneSTR == "")
            phone = auxUINT;
        listOfCustomers.Get(count).SetPhoneNumber(phone);

        aux = listOfCustomers.Get(count).GetEMail();
        Console.WriteLine("eMail: " + listOfCustomers.Get(count).GetEMail());
        string eMail = Console.ReadLine();
        if (eMail == "")
            eMail = aux;
        listOfCustomers.Get(count).SetEMail(eMail);

        aux = listOfCustomers.Get(count).GetContact();
        Console.WriteLine("Contact: " + listOfCustomers.Get(count).GetContact());
        string contact = Console.ReadLine();
        if (contact == "")
            contact = aux;
        listOfCustomers.Get(count).SetContact(contact);

        aux = listOfCustomers.Get(count).GetComments();
        Console.WriteLine("Comments: " + listOfCustomers.Get(count).GetComments());
        string comments = Console.ReadLine();
        if (comments == "")
            comments = aux;
        listOfCustomers.Get(count).SetComments(comments);
    }

    private static void ChangeColors()
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
    }
}

