using System;
using System.Collections.Generic;
using System.Text;

public class ConsoleUI
{
    private List<string> m_buffer;
    private int m_lineLimit;
    private int m_lineToRemove;


    public ConsoleUI()
    {
        m_buffer = new List<string>();
        m_lineLimit = 40;
        m_lineToRemove = 20;
    }

    public void Add(string text)
    {
        m_buffer.Add(text);
        UpdateUI();
    }


    public void UpdateUI()
    {
        if (m_buffer.Count > m_lineLimit) {
            m_buffer.RemoveRange(0, m_lineToRemove);
        }
        Console.Clear();
        foreach (string text in m_buffer)
        {
            Console.WriteLine(text);
        }
    }
}
