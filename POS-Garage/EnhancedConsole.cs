using System;

 abstract class EnhancedConsole
{
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

            case "white":
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static string GetAt(int x,int y,int lenght)
    {
        string slot = new string('-',lenght);
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
        for(int i = 1; i < heigth-1; i++)
        {
            for(int j = 0; j < width; j++)
            {
                Console.SetCursorPosition(x, y + j);
                if(j == 0 || j == width-1)
                    Console.Write('|');
                else
                    Console.Write(' ');
                Console.WriteLine();
            }
        }
        Console.SetCursorPosition(x, y + heigth);
        Console.WriteLine(topBot);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void DrawWindow(int x, int y, string text)
    {
        int width = 20;
        int heigth = 5;
        Console.SetCursorPosition(x, y);
        string topBot = new string('_', width);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(topBot);
        for (int i = 1; i < heigth - 1; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.SetCursorPosition(x, y + j);
                if (j == 0 || j == width - 1)
                    Console.Write('|');
                else
                    Console.Write(' ');
                Console.WriteLine();
            }
        }
        Console.SetCursorPosition(x, y + heigth);
        Console.WriteLine(topBot);
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(x + 1, y + 1);
        Console.WriteLine(text);
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

    public static char GetAt(int x, int y, int lenght, string charAvaliable)
    {
        string slot = new string('-', lenght);
        string confirmation;
        char confirmationC;
        Console.SetCursorPosition(x, y);
        slot = '[' + slot + ']';
        Console.WriteLine(slot);
        Console.SetCursorPosition(x + 1, y);
        do
        {
            confirmation = Console.ReadLine();
        }
        while (!char.TryParse(confirmation, out confirmationC) &&
        charAvaliable.ToLower().Contains(confirmation.ToLower()));
        return confirmationC;
    }

    public static char WaitForKey(string charAvaliable)
    {
        char key = ' ';
        ConsoleKeyInfo keyInfo;
        bool exit = false;
        do
        {
            keyInfo = Console.ReadKey();
            for (int i = 0; i < charAvaliable.Length; i++)
            {
                if (charAvaliable[i] == keyInfo.KeyChar)
                {
                    key = charAvaliable[i];
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

