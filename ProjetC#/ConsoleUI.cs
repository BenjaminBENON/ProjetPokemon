using System;
using System.Collections.Generic;
using System.Text;

public class ConsoleUI
{
    private readonly Dictionary<(int x, int y), string> uiElements;

    public ConsoleUI()
    {
        uiElements = new Dictionary<(int x, int y), string>();
    }

    public void AddElement(string text, int x, int y)
    {
        uiElements[(x, y)] = text;
    }

    public void DrawUI()
    {
        Console.Clear();

        foreach (var element in uiElements)
        {
            int x = element.Key.x;
            int y = element.Key.y;

            if (x >= 0 && x < Console.WindowWidth && y >= 0 && y < Console.WindowHeight)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(element.Value);
            }
        }
    }
}
