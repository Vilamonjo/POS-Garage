
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
       currentRecord = 0;
       separator = new string('-', Console.WindowWidth);
        bool exit = false;
        do
        {
            Console.Clear();
            EnhancedConsole.WriteAt(Console.WindowWidth / 2 - 13, 10,
                "1.- CREATE INVOICE", "white");
            EnhancedConsole.WriteAt(Console.WindowWidth / 2 - 13, 11,
                "2.- SEE ALL INVOICES", "white");
            EnhancedConsole.WriteAt(Console.WindowWidth / 2 - 13, 12,
                "0.- EXIT", "white");

            switch(Console.ReadKey().KeyChar)
            {
                case '1':
                    CreateInvoice();
                    break;

                case '2':
                    SeeInvoices();
                    break;

                case '0':
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
    ,           "DO YOU NEED MORE PRODUCTS? Y/N", "yellow");
            if (Console.ReadKey().Key == ConsoleKey.Y)
                exit = false;
            else
                exit = true;
        }
        while (!exit);
        listOfInvoice.Save();
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
            ShowFooter();
            

            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    if (currentRecord != 0)
                        currentRecord--;
                    break;

                case ConsoleKey.RightArrow:
                    if (currentRecord != listOfInvoice.Amount-1)
                        currentRecord++;
                    break;

                case ConsoleKey.Escape:
                    exit = true;
                    break;
            }
        }
        while (!exit);
    }

    private void WriteHeader()
    {
        EnhancedConsole.WriteAt(2, 0, "INVOICES  " + (currentRecord + 1)
            + "/" + listOfInvoice.Amount, "white");
        EnhancedConsole.WriteAt(68, 0, "J.V. 2018", "white");
        EnhancedConsole.WriteAt(0, 1, separator, "gray");
        ShowClock();
    }

    public void WriteInvoicesHeader()
    {
        Header h = listOfInvoice.Get(currentRecord).GetHeader();
        EnhancedConsole.WriteAt(2, 2,
            h.GetNumInvoice().ToString("000"), "White");
        EnhancedConsole.WriteAt(10, 2,
            h.GetCustomer().GetName(), "White");
        EnhancedConsole.WriteAt(2, 3,
            h.GetDate().Day.ToString("00") + '/' +
            h.GetDate().Month.ToString("00") + '/' +
            h.GetDate().Year.ToString("0000"), "white");
        EnhancedConsole.WriteAt(0, 6, separator, "gray");
    }
    
    public void WriteInvoicesLines()
    {
        List<Line> lines = listOfInvoice.Get(currentRecord).GetLines();
        EnhancedConsole.WriteAt(2, 8, "ITEM", "gray");
        EnhancedConsole.WriteAt(20, 8, "AMOUNT", "gray");
        EnhancedConsole.WriteAt(28, 8, "PRICE", "gray");
        int y = 10;
        foreach (Line l in lines)
        {
            EnhancedConsole.WriteAt(2, y,
                l.GetProduct().GetDescription(), "white");
            EnhancedConsole.WriteAt(20, y,
                l.GetAmount().ToString("000"), "white");
            EnhancedConsole.WriteAt(28, y,
                l.GetPrice().ToString(), "white");
            y += 2;
        }
    }

    private void ShowFooter()
    {
        EnhancedConsole.WriteAt(0, Console.WindowHeight - 4, separator, "gray");
        EnhancedConsole.WriteAt(2, Console.WindowHeight - 3, "Use the arrows to navigate","white");
        EnhancedConsole.WriteAt(2, Console.WindowHeight - 2, "ESC.- EXIT", "white");
    }

    private void ShowClock()
    {
        EnhancedConsole.WriteAt(40, 0,
            DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "white");
    }
}

