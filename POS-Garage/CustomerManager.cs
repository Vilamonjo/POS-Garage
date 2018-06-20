using System;

class CustomerManager
{
    private ListOfCustomers listOfCustomers;

    public CustomerManager()
    {
        listOfCustomers = new ListOfCustomers();
    }

    public void Run()
    {
        bool exit = false;
        ListOfCustomers listOfCustomers = new ListOfCustomers();
        int count = 0;
        string separator = new string('_', Console.WindowWidth);
        do
        {
            Console.Clear();
            EnhancedConsole.WriteAt(0, 0, "CUSTOMERS  " + (count + 1).ToString("000")
                + "/" + listOfCustomers.Amount.ToString("000"), "white");
            EnhancedConsole.WriteAt(0, 1, separator, "gray");

            WriteCustomer(listOfCustomers, count);

            EnhancedConsole.WriteAt(0, Console.WindowHeight - 4, separator, "gray");
            EnhancedConsole.WriteAt(0, Console.WindowHeight - 3, "1.-Previous Customer" +
                "      2.-Next Customer" + "     3.-Search by record" +
                "     4.-Search" + "     5.-Add Customer", "white");
            EnhancedConsole.WriteAt(0, Console.WindowHeight - 2, "6.-Edit record"
                + "            0.-Exit     " + "         D.- Delete" +
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
                    if (count != listOfCustomers.Amount - 1)
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
                    Modify(listOfCustomers, count);
                    break;

                case ConsoleKey.D: //Delete
                    EnhancedConsole.WriteAt(0, Console.WindowHeight - 5,
                        "Delete this Record ? Y / N", "white");

                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        listOfCustomers.Get(count).SetDeleted(true);
                    }

                    break;

                case ConsoleKey.F1:
                    HelpMenuAndControl(listOfCustomers, count, separator);
                    break;

                case ConsoleKey.NumPad0:
                case ConsoleKey.D0: //EXIT
                    exit = true;

                    break;

            }
        } while (!exit);
    }

    public Customer GetDataToCreateCustomer()
    {
        int count = 5;

        EnhancedConsole.WriteAt(0, count, "Name:", "white");
        count++;
        string name = EnhancedConsole.GetAt(0, count, 20);
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

    public void SearchByNumber(ListOfCustomers list, ref int count)
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

    public void SearchByText(ListOfCustomers listOfCustomers, ref int count)
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

    public void Modify(ListOfCustomers listOfCustomers, int count)
    {
        int y = 5;
        Console.Clear();
        Console.SetCursorPosition(0, Console.WindowHeight - 2);
        Console.WriteLine("To not change something, just press Enter");
        Console.SetCursorPosition(0, 5);
        string aux;
        aux = listOfCustomers.Get(count).GetName();

        EnhancedConsole.WriteAt(0,y,
           "Name: " + listOfCustomers.Get(count).GetName()
           .ToString(), "white");
        y++;
        string name = EnhancedConsole.GetAt(0, y, 20);
        if (name == "")
            name = aux;
        listOfCustomers.Get(count).SetName(name);
        y++;


        aux = listOfCustomers.Get(count).GetID();
        EnhancedConsole.WriteAt(0, y,
            "ID: " + listOfCustomers.Get(count).GetID()
            .ToString(), "white");
        y++;
        string iD = EnhancedConsole.GetAt(0, y, 10);
        if (iD == "")
            iD = aux;
        listOfCustomers.Get(count).SetID(iD);
        y++;

        aux = listOfCustomers.Get(count).GetResidence();
        EnhancedConsole.WriteAt(0, y,
            "Residence: " + listOfCustomers.Get(count).GetResidence()
            .ToString(), "white");
        y++;
        string residence = EnhancedConsole.GetAt(0, y, 10);
        if (residence == "")
            residence = aux;
        listOfCustomers.Get(count).SetResidence(residence);
        y++;

        aux = listOfCustomers.Get(count).GetCity();
        EnhancedConsole.WriteAt(0, y,
           "City: " + listOfCustomers.Get(count).GetCity()
           .ToString(), "white");
        y++;
        string city = EnhancedConsole.GetAt(0, y, 15);
        if (city == "")
            city = aux;
        listOfCustomers.Get(count).SetCity(city);
        y++;

        aux = listOfCustomers.Get(count).GetPostalCode();
        EnhancedConsole.WriteAt(0, y,
            "Postal Code: " + listOfCustomers.Get(count).GetPostalCode()
            .ToString(), "white");
        y++;
        string postalCode = EnhancedConsole.GetAt(0, y, 10);
        if (postalCode == "")
            postalCode = aux;
        listOfCustomers.Get(count).SetPostalCode(postalCode);
        y++;

        aux = listOfCustomers.Get(count).GetCountry();
        EnhancedConsole.WriteAt(0, y,
            "Country: " + listOfCustomers.Get(count).GetCountry()
            .ToString(), "white");
        y++;
        string country = EnhancedConsole.GetAt(0, y, 12);
        if (country == "")
            country = aux;
        listOfCustomers.Get(count).SetCountry(country);
        y++;

        uint auxUINT = listOfCustomers.Get(count).GetPhoneNumber();
        EnhancedConsole.WriteAt(0, y,
            "Phone Number: " + listOfCustomers.Get(count).GetPhoneNumber()
            .ToString(), "white");
        y++;
        string phoneSTR;
        uint phone;
        do
        {
            phoneSTR = EnhancedConsole.GetAt(0, y, 9);
        } while ((!UInt32.TryParse(phoneSTR, out phone)) && phoneSTR != "");
        if (phoneSTR == "")
            phone = auxUINT;
        listOfCustomers.Get(count).SetPhoneNumber(phone);
        y++;

        aux = listOfCustomers.Get(count).GetEMail();
        EnhancedConsole.WriteAt(0, y,
            "eMail: " + listOfCustomers.Get(count).GetEMail()
            .ToString(), "white");
        y++;
        string eMail = EnhancedConsole.GetAt(0, y, 25);
        if (eMail == "")
            eMail = aux;
        listOfCustomers.Get(count).SetEMail(eMail);
        y++;

        aux = listOfCustomers.Get(count).GetContact();
        EnhancedConsole.WriteAt(0, y,
           "Contact: " + listOfCustomers.Get(count).GetContact()
            .ToString(), "white");
        y++;
        string contact = EnhancedConsole.GetAt(0, y, 20);
        if (contact == "")
            contact = aux;
        listOfCustomers.Get(count).SetContact(contact);
        y++;

        aux = listOfCustomers.Get(count).GetComments();
        EnhancedConsole.WriteAt(0, y,
          "Comments: " + listOfCustomers.Get(count).GetComments()
            .ToString(), "white");
        y++;
      
        string comments = EnhancedConsole.GetAt(0, y, 40);
        if (comments == "")
            comments = aux;
        listOfCustomers.Get(count).SetComments(comments);
        y++;
    }

    private static void WriteCustomer(ListOfCustomers listOfCustomers, int count)
    {
        int y = 5;
        EnhancedConsole.WriteAt(0, y, "KEY: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfCustomers.Get(count).GetKey(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "NAME: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfCustomers.Get(count).GetName(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "ID: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfCustomers.Get(count).GetID(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "RESIDENCE: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfCustomers.Get(count).GetResidence(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "CITY: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfCustomers.Get(count).GetCity(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "POSTAL CODE: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfCustomers.Get(count).GetPostalCode(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "COUNTRY: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfCustomers.Get(count).GetCountry(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "PHONE NUMBER: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfCustomers.Get(count).GetPhoneNumber().ToString(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "eMAIL: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfCustomers.Get(count).GetEMail(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "CONTACT: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfCustomers.Get(count).GetContact(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "COMMENTS: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfCustomers.Get(count).GetComments(), "white");
        y++;
    }

    public void HelpMenuAndControl(ListOfCustomers listOfCustomers,
                       int countCustomers, string separator)
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
            EnhancedConsole.WriteAt(0, 0, "CUSTOMERS  " + (count + 1).ToString("000")
                + "/" + listOfCustomers.Amount.ToString("000"), "white");
            EnhancedConsole.WriteAt(0, 1, separator, "gray");

            WriteCustomer(listOfCustomers, countCustomers);

            EnhancedConsole.WriteAt(0, Console.WindowHeight - 4, separator, "gray");
            EnhancedConsole.WriteAt(0, Console.WindowHeight - 3, "1.-Previous Customer" +
                "      2.-Next Customer" + "     3.-Search by record" +
                "     4.-Search" + "     5.-Add Customer", "white");
            EnhancedConsole.WriteAt(0, Console.WindowHeight - 2, "6.-Edit record"
                + "            0.-Exit     " + "         D.- Delete" +
                "              F1.-Help", "white");
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
                    if (count != help.Length - 1)
                        count++;
                    break;

                case ConsoleKey.Escape:
                    exit = true;
                    break;
            }
        } while (!exit);
    }
}

