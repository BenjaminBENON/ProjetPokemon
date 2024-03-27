using System;
using System.Collections.Generic;

public enum TextAlignment
{
    Left,
    Right,
    Center
}

public class ConsoleDraw
{
    private Dictionary<(int x, int y), List<string>> uiElements;
    private int bufferLimit;

    public ConsoleDraw(int bufferLimit = 100)
    {
        uiElements = new Dictionary<(int x, int y), List<string>>();
        this.bufferLimit = bufferLimit;
    }

    public void AddElement(string text, int x, int y, TextAlignment alignment = TextAlignment.Left)
    {
        if (!uiElements.ContainsKey((x, y)))
        {
            uiElements[(x, y)] = new List<string>();
        }

        // Truncate if buffer limit reached
        if (uiElements[(x, y)].Count >= bufferLimit)
        {
            uiElements[(x, y)].RemoveAt(0);
        }

        // Format text based on alignment
        string formattedText = FormatText(text, alignment);

        // Add to buffer
        uiElements[(x, y)].Add(formattedText);
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

                // Write each line of text
                foreach (string line in element.Value)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }

    private string FormatText(string text, TextAlignment alignment)
    {
        int maxWidth = Console.WindowWidth;

        switch (alignment)
        {
            case TextAlignment.Left:
                return text.PadRight(maxWidth);
            case TextAlignment.Right:
                return text.PadLeft(maxWidth);
            case TextAlignment.Center:
                return text.PadLeft((maxWidth + text.Length) / 2).PadRight(maxWidth);
            default:
                return text;
        }
    }
}
