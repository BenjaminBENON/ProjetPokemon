using System;
using System.Runtime.InteropServices;

class Program
{
    //[DllImport("user32.dll")]
    //static extern IntPtr GetConsoleWindow();
    //[DllImport("user32.dll")]
    //static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    //const int SW_MAXIMIZE = 3;
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();

    const int SW_MAXIMIZE = 3;

    public static void test()
    {
        IntPtr handle = GetConsoleWindow();
        ShowWindow(handle, SW_MAXIMIZE);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        Console.Clear();
    }
    static void Main(string[] args)
    {
        test();
        //IntPtr handle = GetConsoleWindow();
        //if (handle != IntPtr.Zero)
        //{
        //    ShowWindow(handle, SW_MAXIMIZE);
        //}
        //else
        //{
        //    Console.WriteLine("Erreur lors de la récupération de la fenêtre de la console");
        //}

        Game game = new Game();
        while (true)
        {
            game.Start();
        }
    }
}