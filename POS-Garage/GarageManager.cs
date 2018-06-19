using System;
using System.Threading;

class GarageManager
{
    static void Main(string[] args)
    {
        
        ThreadStart TS = new ThreadStart(Clock);
        Thread t = new Thread(TS);
        ChangeColors();
        DisplayWelcomeScreen();
        t.Start();
        DisplayMenuAnUsersControl();
        t.Abort();
    }

    public static void DisplayMenuAnUsersControl()
    {
        bool exit = false;
        ListOfCustomers listOfCustomers = new ListOfCustomers();
        int count = 0;
        do
        {
            Console.Clear();
            EnhancedConsole.WriteAt(0, 1, "CUSTOMERS  " + (count + 1).ToString("000")
                + "/" + listOfCustomers.Amount.ToString("000"), "white");
            

            Console.SetCursorPosition(0, 5);
            EnhancedConsole.WriteAt(0, 5, listOfCustomers.Get(count).ToString(), "white");
            

            
            EnhancedConsole.WriteAt(0, Console.WindowHeight - 3, "1.-Previous Customer"+
                "      2.-Next Customer"+ "     3.-Search by record"+
                "     4.-Search"+ "     5.-Add Customer", "white");
            EnhancedConsole.WriteAt(0, Console.WindowHeight - 2, "6.-Edit record"
                +"            0.-Exit     "+"         D.- Delete"+
                "              F1.-Help", "white");

            
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1: //Previus 
                    if (count != 0)
                        count--;
                    break;

                case ConsoleKey.RightArrow:
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
                case ConsoleKey.D6: //EDIT
                    Modify (listOfCustomers, count);
                    break;

                case ConsoleKey.D: //Delete
                    EnhancedConsole.WriteAt(0, Console.WindowHeight - 5,
                        "Delete this Record ? Y / N", "white");
                    
                    if(Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        listOfCustomers.Get(count).SetDeleted(true);
                    }
                        
                    break;

                case ConsoleKey.F1:
                    HelpMenuAndControl(listOfCustomers, count);
                    break;

                case ConsoleKey.NumPad0:
                case ConsoleKey.D0: //EXIT
                    exit = true;
                    
                    break;

            }
        } while (!exit);
    }

    private static Customer GetDataToCreateCustomer()
    {
        int count = 5;

        EnhancedConsole.WriteAt(0, count, "Name:", "white");
        count++;
        string name = EnhancedConsole.GetAt(0, count,20);
        count++;

        
        EnhancedConsole.WriteAt(0, count, "ID:", "white");
        count++;
        string iD = EnhancedConsole.GetAt(0, count, 10);
        count++;

        
        EnhancedConsole.WriteAt(0, count, "Residence: ", "white");
        count++;
        string residence = EnhancedConsole.GetAt(0, count, 10);
        count++;

        EnhancedConsole.WriteAt(0, count, "City: ", "white");
        count++;
        string city = EnhancedConsole.GetAt(0, count, 15);
        count++;

        EnhancedConsole.WriteAt(0, count, "Postal Code: ", "white");
        count++;
        string postalCode = EnhancedConsole.GetAt(0, count, 10);
        count++;

        EnhancedConsole.WriteAt(0, count, "Country: ", "white");
        count++;
        string country = EnhancedConsole.GetAt(0, count, 12);
        count++;

        EnhancedConsole.WriteAt(0, count, "Phone Number: ", "white");
        count++;
        string phoneSTR;
        uint phone;
        do
        {
            phoneSTR = EnhancedConsole.GetAt(0, count, 9);
            
        } while (!UInt32.TryParse(phoneSTR, out phone));
        count++;

        EnhancedConsole.WriteAt(0, count, "eMail: ", "white");
        count++;
        string eMail = EnhancedConsole.GetAt(0, count, 25);
        count++;

        EnhancedConsole.WriteAt(0, count, "Contact: ", "white");
        count++;
        string contact = EnhancedConsole.GetAt(0, count, 20);
        count++;

        EnhancedConsole.WriteAt(0, count, "Comments: ", "white");
        count++;
        string observation = EnhancedConsole.GetAt(0, count, 40);
        count++;


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
            EnhancedConsole.WriteAt(0, 10,
                "Enter the number you are looking for", "white");
            numberSTR = EnhancedConsole.GetAt(0, 11, 3);
        }
        while (!UInt16.TryParse(numberSTR, out number));
        if (number > 0 && number <= list.Amount)
        {
            count = number - 1;
        }
        else
        {
            EnhancedConsole.WriteAt(0, 10,
                "Wrong Number!", "white");
            Console.ReadLine();
        }
            
    }

    private static void SearchByText(ListOfCustomers listOfCustomers, ref int count)
    {
        Console.Clear();
        EnhancedConsole.WriteAt(0, 10,
            "What are you looking for?", "white");
        string search = EnhancedConsole.GetAt(0, 11, 15);
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
                EnhancedConsole.WriteAt(0, 10,
                    "Found on the record " + (count + 1).ToString("000"),
                    "yellow");
                Console.ReadLine();
                count--;
            }
            count++;
        }
        while (!found && count < listOfCustomers.Amount - 1);
        if (!found)
        {
            Console.Clear();
            EnhancedConsole.WriteAt(0, 10,
                "Not Found!", "red");

            EnhancedConsole.WriteAt(0, 12,
                "Do you want to search from the first record?", "white");
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
                        EnhancedConsole.WriteAt(0, 10,
                            "Found on the record " + (count + 1).ToString("000"),
                            "yellow");
                        Console.ReadLine();
                        count--;
                    }
                    count++;
                }
                while (!found && count < listOfCustomers.Amount - 1);

                if (!found)
                {
                    Console.Clear();
                    EnhancedConsole.WriteAt(0, 10,
                        "Not Found!", "red");
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

    private static void DisplayWelcomeScreen()
    {
        DateTime DateOfVersion = new DateTime(2018, 6, 19);

        EnhancedConsole.DrawWindow(Console.WindowWidth / 3,
                                Console.WindowHeight / 3,
                                40, 5);
        EnhancedConsole.WriteAt((Console.WindowWidth / 3) + 1,
                                (Console.WindowHeight / 3) + 1,
                                EnhancedConsole.AUTHOR, "white");

        EnhancedConsole.WriteAt((Console.WindowWidth / 3) + 1,
                                (Console.WindowHeight / 3) + 3,
                                EnhancedConsole.VERSION
                                +DateOfVersion.Day.ToString("00")+
                                "/"+DateOfVersion.Month.ToString("00")+
                                "/"+DateOfVersion.Year.ToString("0000"), 
                                "white");
        bool exit = false;
        int count = 0;
        do
        {
            Thread.Sleep(50);
            if(Console.KeyAvailable)
                exit = true;
            count++;
        }
        while (!exit && count < 100);
    }

    private static void HelpMenuAndControl(ListOfCustomers listOfCustomers,
                        int countCustomers)
    {
        
        string[] help = { "This text gives help",
                        "This one helps too",
                        "This one its even longer, so we need to check if the "+ 
                        "string its too long"};
        int count = 0;
        bool exit = false;
        do
        {
            Console.Clear();
            EnhancedConsole.WriteAt(0, 5, listOfCustomers.Get(countCustomers)
                        .ToString(), "white");
            Console.BackgroundColor = ConsoleColor.Red;
            EnhancedConsole.DrawWindow(Console.WindowWidth / 4,
                            Console.WindowHeight / 4,
                            help[count]);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    if (count != 0)
                        count--;
                    break;

                case ConsoleKey.RightArrow:
                    if (count != help.Length-1)
                        count++;
                    break;

                case ConsoleKey.Escape:
                    exit = true;
                    break;
            }
        } while (!exit);

        

        
    }

    private static void Clock()
    {
        while(1==1)

        {
            string date = DateTime.Now.Day.ToString("00") + "/" +
                DateTime.Now.Month.ToString("00") + "/" +
                DateTime.Now.Year.ToString("0000") +
                "   " + DateTime.Now.Hour.ToString("00") + ":" +
                DateTime.Now.Minute.ToString("00") + ":" +
                DateTime.Now.Second.ToString("00");

            EnhancedConsole.WriteAt(Console.WindowHeight, 0, date, "white");
            Thread.Sleep(1000);
        }
    }
}

