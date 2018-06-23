
using System;
using System.Collections.Generic;
using System.Linq;

class InvoiceManager
{
    private ListOfInvoice listOfInvoice;

    int currentRecord;
    string separator;
    ListOfProducts listOfProducts;
    ListOfCustomers listOfCustomers;
    CustomerManager customerManager;
    ProductManager productManager;

    public InvoiceManager()
    {
        listOfInvoice = new ListOfInvoice();
        listOfProducts = new ListOfProducts();
        listOfCustomers = new ListOfCustomers();

        listOfInvoice.Load(listOfCustomers, listOfProducts);
    }

    public void Run()
    {
        SeeInvoices();
    }

    

    private void SeeInvoices()
    {
        bool exit = false;
        do
        {
            Console.Clear();
            WriteHeader();
            WriteInvoicesHeader();
            WriteInvoicesLines();
            WriteTotal();
            ShowFooter();
            ShowClock();
            

            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                case ConsoleKey.LeftArrow:
                    if (currentRecord != 0)
                        currentRecord--;
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                case ConsoleKey.RightArrow:
                    if (currentRecord != listOfInvoice.Amount-1)
                        currentRecord++;
                    break;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    SearchByNumber(listOfInvoice, ref currentRecord);
                    break;

                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Search(listOfInvoice, ref currentRecord);
                    break;

                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    CreateInvoice();
                    break;

                case ConsoleKey.F1:
                    HelpMenuAndControl(separator);
                    break;

                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
                case ConsoleKey.Escape:
                    exit = true;
                    break;
            }
        }
        while (!exit);
    }

    private void CreateInvoice()
    {
        bool exit = false;
        customerManager = new CustomerManager();
        productManager = new ProductManager();
        Customer c = customerManager.RunToGetCustomer();
        Product p;
        listOfInvoice.Add(c);
        do
        {
            p = productManager.RunToGetProduct();
            EnhancedConsole.WriteAt(2, Console.BufferHeight - 5
                , "AMOUNT?", "yellow");
            string amountSTR;
            int amount;
            do
            {
                amountSTR = Console.ReadLine();
            }
            while (!Int32.TryParse(amountSTR, out amount));
            listOfInvoice.Get(listOfInvoice.Amount - 1).GetLines().Add
                (new Line(p, amount, p.GetSellPrice()));
            Console.Clear();
            EnhancedConsole.WriteAt(2, Console.BufferHeight - 5
    , "DO YOU NEED MORE PRODUCTS? Y/N", "yellow");
            if (Console.ReadKey().Key == ConsoleKey.Y)
                exit = false;
            else
                exit = true;
        }
        while (!exit);
        listOfInvoice.Save();
    }

    public void SearchByNumber(ListOfInvoice list, ref int count)
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

    private void WriteHeader()
    {
        EnhancedConsole.WriteAt(2, 0, "INVOICES  " + (currentRecord + 1)
            + "/" + listOfInvoice.Amount, "white");
        EnhancedConsole.WriteAt(68, 0, "J.V. 2018", "white");
        EnhancedConsole.WriteAt(0, 1, separator, "gray");
        ShowClock();
    }

    private void WriteInvoicesHeader()
    {
        Header h = listOfInvoice.Get(currentRecord).GetHeader();
        EnhancedConsole.WriteAt(2, 2,
            h.GetNumInvoice().ToString("000"), "White");
        EnhancedConsole.WriteAt(2, 3,
            "Customer:", "gray");
        EnhancedConsole.WriteAt(12, 3,
            h.GetCustomer().GetName(), "white");
        EnhancedConsole.WriteAt(2, 4,
            "ID:", "gray");
        EnhancedConsole.WriteAt(12, 4,
            h.GetCustomer().GetID(), "White");
        EnhancedConsole.WriteAt(2, 5,
            h.GetDate().Day.ToString("00") + '/' +
            h.GetDate().Month.ToString("00") + '/' +
            h.GetDate().Year.ToString("0000"), "white");
        EnhancedConsole.WriteAt(0, 6, separator, "gray");
    }
    
    private void WriteInvoicesLines()
    {
        List<Line> lines = listOfInvoice.Get(currentRecord).GetLines();
        EnhancedConsole.WriteAt(2, 8, "ITEM", "gray");
        EnhancedConsole.WriteAt(20, 8, "AMOUNT", "gray");
        EnhancedConsole.WriteAt(28, 8, "PRICE", "gray");
        EnhancedConsole.WriteAt(36, 8, "TOTAL", "gray");
        int y = 9;
        foreach (Line l in lines)
        {
            EnhancedConsole.WriteAt(2, y,
                l.GetProduct().GetDescription(), "white");
            EnhancedConsole.WriteAt(20, y,
                l.GetAmount().ToString("000"), "white");
            EnhancedConsole.WriteAt(28, y,
                l.GetPrice().ToString(), "white");
            EnhancedConsole.WriteAt(36, y,
                (l.GetPrice()*(Convert.ToDouble(l.GetAmount()))).ToString(), "white");
            y++;
        }
    }

    public void WriteTotal()
    {
        double total = CalculateTotal();
        double iva = CalculateIVA(total);
        double bas = total - iva;
        string separator = new string('_', 46);

        EnhancedConsole.WriteAt(0, Console.WindowHeight - 8, separator, "yellow");
        EnhancedConsole.WriteAt(20, Console.WindowHeight - 7, "BASE", "gray");
        EnhancedConsole.WriteAt(28, Console.WindowHeight - 7, "IVA", "gray");
        EnhancedConsole.WriteAt(36, Console.WindowHeight - 7, "TOTAL", "gray");

        EnhancedConsole.WriteAt(20, Console.WindowHeight - 6, bas.ToString(), "white");
        EnhancedConsole.WriteAt(28, Console.WindowHeight - 6, iva.ToString(), "white");
        EnhancedConsole.WriteAt(36, Console.WindowHeight - 6, total.ToString(), "red");

    }

    private void ShowFooter()
    {
        EnhancedConsole.WriteAt(0, Console.WindowHeight - 4, separator, "gray");
        EnhancedConsole.WriteAt(2, Console.WindowHeight - 3, "1.-Previous" +
            "      2.-Next" + "     3.-Number" +
            "     4.-Search" + "     5.-Add", "white");
        EnhancedConsole.WriteAt(2, Console.WindowHeight - 2, "0.-Exit  "+
            "        F1.-Help", "white");
    }

    private double CalculateIVA(double total)
    {
        double iva = (total * 21) / 100;
        return iva;
    }

    private double CalculateTotal()
    {
        List<Line> currentInvoiceLines =
            listOfInvoice.Get(currentRecord).GetLines();
        double total = 0;

        foreach(Line l in currentInvoiceLines)
        {
            total += l.GetPrice() * (double) l.GetAmount();
        }
        return total;
    }
    

    public void Search(ListOfInvoice listOfInvoices, ref int count)
    {
        Console.Clear();
        EnhancedConsole.WriteAt(0, 10,
            "What are you looking for?", "white");
        string search = EnhancedConsole.GetAt(0, 11, 15);
        search = search.ToLower();
        bool found = false;
        count = 0;
        do
        {
            if (listOfInvoices.Get(count).GetHeader().
                GetCustomer().GetName().ToLower().
                Contains(search))
            {
                found = true;
                Console.Clear();
                EnhancedConsole.WriteAt(1, 20,
                    "Found on the record " + (count + 1).ToString("000"),
                    "yellow");
                Console.ReadLine();
                count--;
            }
            count++;
        }
        while (!found && count < listOfInvoices.Amount);
        if (!found)
        {
            Console.Clear();
            count = 0;
            SearchByItem(listOfInvoice, ref count, search);
        }
    }

    public void SearchByItem(ListOfInvoice list, ref int count, string search)
    {
        bool found = false;
        int count2 = 0;
        Queue<string> founds = new Queue<string>();
        int y = 8;
        do
        {
            
            Invoice i = list.Get(count);
            count2 = 0;
            do
            {
                if (i.GetLines().ElementAt(count2).
                    GetProduct().GetDescription().
                    ToLower().Contains(search.ToLower()) ||
                    i.GetLines().ElementAt(count2).
                    GetProduct().GetCode().
                    ToLower().Contains(search.ToLower()) ||
                    i.GetLines().ElementAt(count2).
                    GetProduct().GetCategory().
                    ToLower().Contains(search.ToLower()))
                {
                    found = true;
                    founds.Enqueue("Find at " + (count + 1));
                }
                    

                    count2++;
            }
            while (count2 < i.GetLines().Count);
            count++;
        }
        while (count < list.Amount);
        if(!found)
        {
            EnhancedConsole.WriteAt(30, 16,
                "Not Found!", "red");
        }
        else
        {
            foreach(string s in founds)
            {
                EnhancedConsole.WriteAt(2, y,
                    s, "white");
                y++;
            }
            Console.ReadLine();
        }
        count = 0;
    }

    public void HelpMenuAndControl(string separator)
    {

        string[] help = { "This text gives help",
                        "This one helps too",
                        "This one its even longer, so we need to check if the "+
                        "string its too long"};
        int count = 0;
        bool exit = false;
        do
        {
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

    private void CreatePDF()
    {
        PDFGenerator doc = new PDFGenerator();
        doc.WriteAt("Invoice 1", 250,50,14);
        doc.WriteAt("End of invoice", 250, 700, 14);
        doc.DrawHoLine(4, 100);
        doc.DrawVeLine(4, 100);
        doc.SaveDocument("sample");
    }

    private void ShowClock()
    {
        EnhancedConsole.WriteAt(40, 0,
            DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "white");
    }
}

