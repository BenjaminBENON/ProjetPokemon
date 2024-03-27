using System;
using System.Collections.Generic;

public class CustomConsole
{
    private static CustomConsole instance;
    private List<string> leftTexts = new List<string>();
    private List<string> middleTexts = new List<string>();
    private List<string> rightTexts = new List<string>();
    private PositionState positionState = PositionState.Left; // État par défaut

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
        leftTexts.Add(text);
        if (leftTexts.Count > 55)
        {
            Console.WriteLine("On dépasse");
            leftTexts.RemoveRange(0, 30);
        }

        DisplayTexts();
    }

    public void WriteToMiddle(string text)
    {
        middleTexts.Add(text);
        if (middleTexts.Count > 55)
        {
            Console.WriteLine("On dépasse");
            middleTexts.RemoveRange(0, 30);
        }

        DisplayTexts();
    }

    public void WriteToRight(string text)
    {
        rightTexts.Add(text);
        if (rightTexts.Count > 55)
        {
            Console.WriteLine("On dépasse");
            rightTexts.RemoveRange(0, 30);
        }

        DisplayTexts();
    }

    private void DisplayTexts()
    {
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
            Console.Write($"Ennemi {i}: {leftTexts[i]}\n");
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
            Console.Write($"Texte global {i} : {middleTexts[i]}\n");
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
            Console.Write($"Joueur {i}: {rightTexts[i]}\n");
        }
    }
}
