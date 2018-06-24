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
        bool exit = false;
        ListOfProducts listOfProducts = new ListOfProducts();
        int count = 0;
        string separator = new string('_', Console.WindowWidth);
        do
        {
            Console.Clear();
            EnhancedConsole.WriteAt(0, 0, "PRODUCTSS  " + (count + 1).ToString("000")
                + "/" + listOfProducts.Amount.ToString("000"), "white");
            EnhancedConsole.WriteAt(0, 1, separator, "gray");

            WriteProduct(listOfProducts, count);

            EnhancedConsole.WriteAt(0, Console.WindowHeight - 4, separator, "gray");
            EnhancedConsole.WriteAt(0, Console.WindowHeight - 3, "1.-Previous Product" +
                "      2.-Next Product" + "     3.-Search by record" +
                "     4.-Search" + "     5.-Add Product", "white");
            EnhancedConsole.WriteAt(0, Console.WindowHeight - 2, "6.-Edit record"
                + "            0.-Exit     " + "                   " +
                "              F1.-Help", "white");

            EnhancedConsole.ShowClock();

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
                    //I cant allProducts[count+1] != null
                    if (count != listOfProducts.Amount - 1)
                        count++;
                    break;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3: //Search by number
                    SearchByNumber(listOfProducts, ref count);
                    break;

                case ConsoleKey.NumPad4:
                case ConsoleKey.D4: //Search by text
                    SearchByText(listOfProducts, ref count);
                    break;

                case ConsoleKey.NumPad5:
                case ConsoleKey.D5: //Add Product
                    Console.Clear();
                    listOfProducts.Add(GetDataToCreateProduct());
                    break;

                case ConsoleKey.NumPad6:
                case ConsoleKey.D6: //EDIT
                    Modify(listOfProducts, count);
                    break;

              //  case ConsoleKey.D: //Delete
              //      EnhancedConsole.WriteAt(0, Console.WindowHeight - 5,
              //           "Delete this Record ? Y / N", "white");
              //
              //      if (Console.ReadKey().Key == ConsoleKey.Y)
              //      {
              //          listOfProducts.Get(count).SetDeleted(true);
              //      }
              //
              //      break;

                case ConsoleKey.F1:
                    HelpMenuAndControl(listOfProducts, count, separator);
                    break;

                case ConsoleKey.NumPad0:
                case ConsoleKey.D0: //EXIT
                    exit = true;

                    break;

            }
        } while (!exit);
    }

    public Product RunToGetProduct()
    {
        bool exit = false;
        ListOfProducts listOfProducts = new ListOfProducts();
        int count = 0;
        string separator = new string('_', Console.WindowWidth);
        do
        {
            Console.Clear();
            EnhancedConsole.WriteAt(0, 0, "PRODUCTSS  " + (count + 1).ToString("000")
                + "/" + listOfProducts.Amount.ToString("000"), "white");
            EnhancedConsole.WriteAt(0, 1, separator, "gray");

            WriteProduct(listOfProducts, count);

            EnhancedConsole.WriteAt(0, Console.WindowHeight - 4, separator, "gray");
            EnhancedConsole.WriteAt(0, Console.WindowHeight - 3, "1.-Previous Product" +
                "      2.-Next Product" + "     3.-Search", "white");
            EnhancedConsole.WriteAt(0, Console.WindowHeight - 2, 
                "PRESS ENTER TO SELECT THE PRODUCT", "white");

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
                    //I cant allProducts[count+1] != null
                    if (count != listOfProducts.Amount - 1)
                        count++;
                    break;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3: //Search
                    SearchByText(listOfProducts, ref count);
                    break;

                case ConsoleKey.Enter:
                    exit = true;
                    break;

            }
        } while (!exit);
        return listOfProducts.Get(count);
    }

    public Product GetDataToCreateProduct()
    {
        int y = 5;

        EnhancedConsole.WriteAt(0, y, "Code:", "white");
        y++;
        string code = EnhancedConsole.GetAt(0, y, 10);
        y++;

        EnhancedConsole.WriteAt(0, y, "Description:", "white");
        y++;
        string description = EnhancedConsole.GetAt(0, y, 20);
        y++;

        EnhancedConsole.WriteAt(0, y, "Category: ", "white");
        y++;
        string category = EnhancedConsole.GetAt(0, y, 10);
        y++;

        EnhancedConsole.WriteAt(0, y, "Sell Price: ", "white");
        y++;
        string sPriceSTR;
        uint sellPrice;
        do
        {
            sPriceSTR = EnhancedConsole.GetAt(0, y, 9);

        } while (!UInt32.TryParse(sPriceSTR, out sellPrice));
        y++;

        EnhancedConsole.WriteAt(0, y, "Buy Price: ", "white");
        y++;
        string bPriceSTR;
        uint buyPrice;
        do
        {
            bPriceSTR = EnhancedConsole.GetAt(0, y, 9);

        } while (!UInt32.TryParse(bPriceSTR, out buyPrice));
        y++;

        EnhancedConsole.WriteAt(0, y, "Stock: ", "white");
        y++;
        string stockSTR;
        uint stock;
        do
        {
            stockSTR = EnhancedConsole.GetAt(0, y, 9);

        } while (!UInt32.TryParse(stockSTR, out stock));
        y++;

        EnhancedConsole.WriteAt(0, y, "Minimum Stock: ", "white");
        y++;
        string mStockSTR;
        uint minStock;
        do
        {
            mStockSTR = EnhancedConsole.GetAt(0, y, 9);

        } while (!UInt32.TryParse(mStockSTR, out minStock));
        y++;

        Product productToReturn = new Product(
            code, description, category, sellPrice, buyPrice,
            stock, minStock);

        return productToReturn;
    }

    public void SearchByNumber(ListOfProducts list, ref int count)
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

    public void SearchByText(ListOfProducts listOfProducts, ref int count)
    {
        Console.Clear();
        EnhancedConsole.WriteAt(0, 10,
            "What are you looking for?", "white");
        string search = EnhancedConsole.GetAt(0, 11, 15);
        search = search.ToLower();
        bool found = false;
        do
        {
            if (listOfProducts.Get(count).GetCode().ToLower().
                Contains(search) ||
                listOfProducts.Get(count).GetDescription().ToLower().
                Contains(search) ||
                listOfProducts.Get(count).GetCategory().ToLower().
                Contains(search) ||
                listOfProducts.Get(count).GetSellPrice().ToString().
                Contains(search) ||
                listOfProducts.Get(count).GetBuyPrice().ToString().
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
        while (!found && count < listOfProducts.Amount - 1);
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
                    if (listOfProducts.Get(count).GetCode().ToLower().
                        Contains(search) ||
                        listOfProducts.Get(count).GetDescription().ToLower().
                        Contains(search) ||
                        listOfProducts.Get(count).GetCategory().ToLower().
                        Contains(search) ||
                        listOfProducts.Get(count).GetSellPrice().ToString().
                        Contains(search) ||
                        listOfProducts.Get(count).GetBuyPrice().ToString().
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
                while (!found && count < listOfProducts.Amount - 1);

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

    public void Modify(ListOfProducts listOfProducts, int count)
    {
        int y = 5;
        Console.Clear();
        Console.SetCursorPosition(0, Console.WindowHeight - 2);
        Console.WriteLine("To not change something, just press Enter");
        Console.SetCursorPosition(0, 5);
        string aux;
        aux = listOfProducts.Get(count).GetCode();

        EnhancedConsole.WriteAt(0, y,
           "Code: " + listOfProducts.Get(count).GetCode()
           .ToString(), "white");
        y++;
        string code = EnhancedConsole.GetAt(0, y, 20);
        if (code == "")
            code = aux;
        listOfProducts.Get(count).SetCode(code);
        y++;

        aux = listOfProducts.Get(count).GetDescription();
        EnhancedConsole.WriteAt(0, y,
            "Description: " + listOfProducts.Get(count).GetDescription()
            .ToString(), "white");
        y++;
        string description = EnhancedConsole.GetAt(0, y, 10);
        if (description == "")
            description = aux;
        listOfProducts.Get(count).SetDescription(description);
        y++;

        aux = listOfProducts.Get(count).GetCategory();
        EnhancedConsole.WriteAt(0, y,
            "Category: " + listOfProducts.Get(count).GetCategory()
            .ToString(), "white");
        y++;
        string category = EnhancedConsole.GetAt(0, y, 10);
        if (category == "")
            category = aux;
        listOfProducts.Get(count).SetCategory(category);
        y++;

        double auxDouble = listOfProducts.Get(count).GetSellPrice();
        EnhancedConsole.WriteAt(0, y,
            "Sell Price: " + listOfProducts.Get(count).GetSellPrice()
            .ToString(), "white");
        y++;
        string sellPriceSTR;
        double sellPrice;
        do
        {
            sellPriceSTR = EnhancedConsole.GetAt(0, y, 9);
        } while ((!Double.TryParse(sellPriceSTR, out sellPrice)) && sellPriceSTR != "");
        if (sellPriceSTR == "")
            sellPrice = auxDouble;
        listOfProducts.Get(count).SetSellPrice(sellPrice);
        y++;

        auxDouble = listOfProducts.Get(count).GetBuyPrice();
        EnhancedConsole.WriteAt(0, y,
            "Buy Price: " + listOfProducts.Get(count).GetBuyPrice()
            .ToString(), "white");
        y++;
        string buyPriceSTR;
        double buyPrice;
        do
        {
            buyPriceSTR = EnhancedConsole.GetAt(0, y, 9);
        } while ((!Double.TryParse(buyPriceSTR, out buyPrice)) && buyPriceSTR!= "");
        if (buyPriceSTR == "")
            buyPrice = auxDouble;
        listOfProducts.Get(count).SetBuyPrice(buyPrice);
        y++;

        uint auxUINT = listOfProducts.Get(count).GetStock();
        EnhancedConsole.WriteAt(0, y,
            "Stock: " + listOfProducts.Get(count).GetStock()
            .ToString(), "white");
        y++;
        string stockSTR;
        uint stock;
        do
        {
            stockSTR = EnhancedConsole.GetAt(0, y, 9);
        } while ((!UInt32.TryParse(stockSTR, out stock )) && stockSTR != "");
        if (stockSTR == "")
            stock = auxUINT;
        listOfProducts.Get(count).SetStock(stock);
        y++;

        auxUINT = listOfProducts.Get(count).GetMinStock();
        EnhancedConsole.WriteAt(0, y,
            "Minimum Stock: " + listOfProducts.Get(count).GetMinStock()
            .ToString(), "white");
        y++;
        string minStockSTR;
        uint minStock;
        do
        {
            minStockSTR = EnhancedConsole.GetAt(0, y, 9);
        } while ((!UInt32.TryParse(minStockSTR, out minStock)) && minStockSTR!= "");
        if (minStockSTR == "")
            minStock = auxUINT;
        listOfProducts.Get(count).SetMinStock(minStock);
        y++;
    }

    private static void WriteProduct(ListOfProducts listOfProducts, int count)
    {
        int y = 5;
        EnhancedConsole.WriteAt(0, y, "CODE: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfProducts.Get(count).GetCode(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "DESCRIPTION: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfProducts.Get(count).GetDescription(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "CATEGORY: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfProducts.Get(count).GetCategory(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "SELL PRICE: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfProducts.Get(count).GetSellPrice()
            .ToString()+"$", "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "BUY PRICE: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfProducts.Get(count).GetBuyPrice()
            .ToString()+"$", "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "STOCK: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfProducts.Get(count).GetStock()
            .ToString(), "white");
        y++;

        EnhancedConsole.WriteAt(0, y, "MINIMUM STOCK: ", "gray");
        EnhancedConsole.WriteAt(15, y, listOfProducts.Get(count).GetMinStock()
            .ToString(), "white");
        y++;
    }

    public void HelpMenuAndControl(ListOfProducts listOfProducts,
                       int countProducts, string separator)
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
            EnhancedConsole.WriteAt(0, 0, "productS  " + (count + 1).ToString("000")
                + "/" + listOfProducts.Amount.ToString("000"), "white");
            EnhancedConsole.WriteAt(0, 1, separator, "gray");

            WriteProduct(listOfProducts, countProducts);

            EnhancedConsole.WriteAt(0, Console.WindowHeight - 4, separator, "gray");
            EnhancedConsole.WriteAt(0, Console.WindowHeight - 3, "1.-Previous Product" +
                "      2.-Next Product" + "     3.-Search by record" +
                "     4.-Search" + "     5.-Add Product", "white");
            EnhancedConsole.WriteAt(0, Console.WindowHeight - 2, "6.-Edit record"
                + "            0.-Exit     " + "                   " +
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