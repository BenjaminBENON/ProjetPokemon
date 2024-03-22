using System;
using System.Runtime.InteropServices;

class Program
{

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();

    const int SW_MAXIMIZE = 3;

    public static void Resize()
    {
        IntPtr handle = GetConsoleWindow();
        ShowWindow(handle, SW_MAXIMIZE);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        Console.Clear();
    }
    static void Main(string[] args)
    {



        Resize();
        
        Game game = new Game();
        while (true)
        {
            game.Run();
        }
    }
}