using System;


 abstract class EnhancedConsole
{
    
    public const string AUTHOR = "JOSE VILAPLANA, GARAGE POS ";
    public const string VERSION = "VERSION 0.06 ";
    

    public static void WriteAt(int x,int y,string text, string color)
    {
        Console.SetCursorPosition(x, y);
        switch(color.ToLower())
        {
            case "red":
                Console.ForegroundColor = ConsoleColor.Red;
                break;

            case "yellow":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;

            case "gray":
                Console.ForegroundColor = ConsoleColor.Gray;
                break;

            case "white":
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static string GetAt(int x,int y,int length)
    {
        string slot = new string('-',length);
        Console.SetCursorPosition(x, y);
        slot = '[' + slot + ']';
        Console.WriteLine(slot);
        Console.SetCursorPosition(x + 1, y);
        return Console.ReadLine();
    }

    public static void DrawWindow(int x, int y, int width, int heigth)
    {
        Console.SetCursorPosition(x, y);
        string topBot = new string('_', width);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(topBot);
        for(int i = 1; i < heigth; i++)
        {
            Console.SetCursorPosition(x, y + i);
            for (int j = 0; j < width; j++)
            {
                
                if(j == 0 || j == width-1)
                    Console.Write('|');
                else
                    Console.Write(' ');
            }
            Console.WriteLine();
        }
        Console.SetCursorPosition(x, y + heigth);
        Console.WriteLine(topBot);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void DrawWindow(int x, int y, string text)
    {
        int width = 40;
        int heigth = 5;
        int textCount = 0;
        Console.SetCursorPosition(x, y);
        string topBot = new string('_', width);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(topBot);
        for (int i = 1; i < heigth - 1; i++)
        {
            Console.SetCursorPosition(x, y + i);
            for (int j = 0; j < width; j++)
            {
                
                if (j == 0 || j == width - 1)
                    Console.Write('|');
                else
                {
                    if(textCount != text.Length)
                    {
                        Console.Write(text[textCount]);
                        textCount++;
                    }
                    else
                        Console.Write(' ');

                }
                    
                
            }
            Console.WriteLine();
        }
        Console.SetCursorPosition(x, y + heigth);
        Console.WriteLine(topBot);
        Console.ForegroundColor = ConsoleColor.White;
    }



    public static void WriteCentered(string text, int y, string color)
    {
        Console.SetCursorPosition(Console.WindowWidth/2-text.Length/2, y);
        switch (color.ToLower())
        {
            case "red":
                Console.ForegroundColor = ConsoleColor.Red;
                break;

            case "yellow":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;

            case "white":
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static char GetAt(int x, int y, int lenght, string charAvailable)
    {
        string slot = new string('-', lenght);
        char confirmation = ' ';
        ConsoleKeyInfo keyInfo;
        bool exit = false;

        Console.SetCursorPosition(x, y);
        slot = '[' + slot + ']';
        Console.WriteLine(slot);
        Console.SetCursorPosition(x + 1, y);
        do
        {
            keyInfo = Console.ReadKey();
            for (int i = 0; i < charAvailable.Length; i++)
            {
                if (charAvailable[i] == keyInfo.KeyChar)
                {
                    confirmation = charAvailable[i];
                    exit = true;
                }

            }
        } while (!exit);
    
        return confirmation;
    }

    public static char WaitForKey(string charAvailable)
    {
        char key = ' ';
        ConsoleKeyInfo keyInfo;
        bool exit = false;
        do
        {
            keyInfo = Console.ReadKey();
            for (int i = 0; i < charAvailable.Length; i++)
            {
                if (charAvailable[i] == keyInfo.KeyChar)
                {
                    key = charAvailable[i];
                    exit = true;
                }

            }
        } while (!exit);
        return key;
    }

    public static int GetIntegrerAt(int x, int y, int min, int max)
    {
        string numberSTR;
        int number;
        do
        {
            Console.SetCursorPosition(x, y);
            numberSTR = Console.ReadLine();
        } while ((!Int32.TryParse(numberSTR, out number)) &&
            (number >= min && number <= max));
        return number;
    }
}

