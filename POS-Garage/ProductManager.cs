
using System;

class ProductManager
{
    private ListOfProducts listOfProducts;

    public ProductManager()
    {
        listOfProducts = new ListOfProducts();
    }

    public void Run()
    {
        Console.Clear();
        EnhancedConsole.WriteAt(Console.WindowWidth / 2 - 2,
            Console.WindowHeight / 2, "SOON", "yellow");
        Console.ReadKey();
    }
}

