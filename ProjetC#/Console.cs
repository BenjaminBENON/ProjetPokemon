using System;
using System.Collections.Generic;

public class CustomConsole
{
    private static CustomConsole instance;
    private List<string> leftTexts = new List<string>();
    private List<string> middleTexts = new List<string>();
    private List<string> rightTexts = new List<string>();
    private PositionState positionState = PositionState.Left; 

    public bool m_allowWrite = false;

    public enum PositionState
    {
        Left,
        Middle,
        Right
    }

    private CustomConsole() { }

    public static CustomConsole Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CustomConsole();
            }
            return instance;
        }
    }

    public void SetPositionState(PositionState state)
    {
        positionState = state;
    }

    public void WriteText(string text)
    {
        switch (positionState)
        {
            case PositionState.Left:
                WriteToLeft(text);
                break;
            case PositionState.Middle:
                WriteToMiddle(text);
                break;
            case PositionState.Right:
                WriteToRight(text);
                break;
        }
    }

    public void WriteToLeft(string text)
    {
        if (text.Length > 40)
        {
            List<string> strings = new List<string>();
            strings.Add(text.Substring(0, 40));
            strings.Add(text.Substring(40));
            foreach (string s in strings)
            {
                leftTexts.Add(s);
            }
        }
        else
        {
            leftTexts.Add(text);
        }
        
        if (leftTexts.Count > 30)
        {
            Console.WriteLine("On dépasse");
            leftTexts.RemoveRange(0, 20);
        }

        DisplayTexts();
    }

    public void DisplayPokemons()
    {
        Console.Clear();
        string[] linesPokemon1 = new string[]
        {
            "       ,___          .-;'",
            "       `\"-.`\\_...._/`.`",
            "    ,      \\        /",
            " .-' ',    / ()   ()\\",
            "`'._   \\  /()    .  (|",
            "    > .' ;,     -'-  /",
            "   / <   |;,     __.;",
            "   '-.'-.|  , \\    , \\",
            "      `>.|;, \\_)    \\_)",
            "       `-;     ,    /",
            "          \\    /   <",
            "           '. <`'-,_)",
            "         '._)"
        };

        string[] linesText = new string[]
                {
            "  __ _       _     _   ",
            " / _(_)     | |   | |  ",
            "| |_ _  __ _| |__ | |_ ",
            "|  _| |/ _` | '_ \\| __|",
            "| | | | (_| | | | | |_ ",
            "|_| |_|\\__, |_| |_|\\__|",
            "        __/ |          ",
            "       |___/           "
        };

        string[] linesPokemon2 = new string[]
        {
            ";-.          ___,",
            "  `.`\\_...._/`.-\"`",
            "    \\        /      ,",
            "    /()   () \\    .' `-._",
            "   |)  .    ()\\  /   _.'",
            "   \\  -'-     ,; '. <",
            "    ;.__     ,;|   > \\",
            "   / ,    / ,  |.-'.-'",
            "  (_/    (_/ ,;|.<`",
            "    \\    ,     ;-`",
            "     >   \\    /",
            "    (_,-'`> .'",
            "      (_,',"
        };

        int initialRow = Console.CursorTop;
        int textInitialRow = Console.CursorTop;
        int secondInitialRow = Console.CursorTop;

        Console.ForegroundColor = ConsoleColor.Green;
        foreach (string line in linesPokemon1)
        {
            Console.SetCursorPosition(30, initialRow++);
            Console.WriteLine(line);
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (string line in linesText)
        {
            Console.SetCursorPosition(90, textInitialRow++);
            Console.WriteLine(line);
        }
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (string line in linesPokemon2)
        {
            Console.SetCursorPosition(150, secondInitialRow++);
            Console.WriteLine(line);
        }

        DateTime startTime = DateTime.Now;
        TimeSpan duration = TimeSpan.FromMilliseconds(3000);

        DateTime currentTime;

        do
        {
            currentTime = DateTime.Now;
        } while (currentTime - startTime < duration);

        Console.Clear();
    }

    public void WriteToMiddle(string text)
    {
        if (text.Length > 40)
        {
            List<string> strings = new List<string>();
            strings.Add(text.Substring(0, 40));
            strings.Add(text.Substring(40));
            foreach (string s in strings)
            {
                middleTexts.Add(s);
            }
        }
        else
        {
            middleTexts.Add(text);
        }
        
        if (middleTexts.Count > 30)
        {
            Console.WriteLine("On dépasse");
            middleTexts.RemoveRange(0, 20);
        }

        DisplayTexts();
    }



    public void WriteToRight(string text)
    {

        if (text.Length > 30)
        {
            List<string> strings = new List<string>();
            strings.Add(text.Substring(0, 30));
            strings.Add(text.Substring(30));
            foreach (string s in strings)
            {
                rightTexts.Add(s);
            }
        }
        else
        {
            rightTexts.Add(text);
        }

        if (rightTexts.Count > 30)
        {
            //for each 
            Console.WriteLine("On dépasse");
            rightTexts.RemoveRange(0, 20);
        }

        DisplayTexts();
    }

    private void DisplayTexts()
    {
        if (!m_allowWrite)
        {
            return;
        }
        Console.Clear();
        DisplayLeftTexts();
        DisplayMiddleTexts();
        DisplayRightTexts();
    }

    private void DisplayLeftTexts()
    {

        Console.SetCursorPosition(20, 5);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Myself :");
        for (int i = 0; i < leftTexts.Count; i++)
        {
            Console.SetCursorPosition(0, 10 + (i));
            Console.Write($"           {leftTexts[i]}\n");
        }
    }

    private void DisplayMiddleTexts()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition((Console.WindowWidth - 60) / 2, 5);
        Console.Write("Global Fight :");
        for (int i = 0; i < middleTexts.Count; i++)
        {
            Console.SetCursorPosition((Console.WindowWidth - 60) / 2, 10 + (i));
            Console.Write($"{middleTexts[i]}\n");
        }
    }

    private void DisplayRightTexts()
    {
        Console.SetCursorPosition(Console.WindowWidth - 60, 5);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Enemy :\n");
        for (int i = 0; i < rightTexts.Count; i++)
        {
            Console.SetCursorPosition(Console.WindowWidth - 60, 10 + (i));
            Console.Write($"{rightTexts[i]}\n");
        }
    }

    public void Cleanup()
    {
        Console.Clear();
        leftTexts.Clear();
        middleTexts.Clear();
        rightTexts.Clear();
    }
}
