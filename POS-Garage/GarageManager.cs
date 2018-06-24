using System;
using System.Threading;

class GarageManager
{
    static void Main(string[] args)
    {
        ChangeColors();
        DisplayWelcomeScreen();
        Run();
    }

    private static void Run()
    {
        bool exit = false;
        do
        {
            Console.Clear();
            EnhancedConsole.WriteAt(Console.WindowWidth / 2 - 13, 10,
                "1.- INVOICE MANAGEMENT", "white");
            EnhancedConsole.WriteAt(Console.WindowWidth / 2 - 13, 11,
                "2.- CUSTOMERS MANAGEMENT", "white");
            EnhancedConsole.WriteAt(Console.WindowWidth / 2 - 13, 12,
                "3.- PRODUCT MANAGEMENT", "white");
            EnhancedConsole.WriteAt(Console.WindowWidth / 2 - 13, 13,
                "0.- EXIT", "white");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    InvoiceManager invoiceManager = new InvoiceManager();
                    invoiceManager.Run();
                    break;

                case '2':
                    CustomerManager customerManager = new CustomerManager();
                    customerManager.Run();
                    break;

                case '3':
                    ProductManager productManager = new ProductManager();
                    productManager.Run();
                    break;

                case '0':
                    exit = true;
                    break;
            }
        } while (!exit);
    }
   
    private static void ChangeColors()
    {
        Console.SetWindowSize(80, 25);
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
    }

    private static void DisplayWelcomeScreen()
    {
        DateTime DateOfVersion = new DateTime(2018, 6, 24);

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
}