using System;

public struct Customer
{
    string name;
    string cif;
    string residence;
    string city;
    ushort postalCode;
    string country;
    uint phoneNumber;
    string eMail;
    string contact;
    string observations;
}
class Program
{
    static void Main(string[] args)
    {
        Customer[] allCustomers = new Customer[1000];
        Program.DisplayMenu();
        
    }

    public static void DisplayMenu()
    {
        Console.SetCursorPosition(0, Console.WindowHeight - 3);
        Console.ReadLine();
    }
}

