using System;
using System.Threading;

namespace musicvolume
{
    class Program
    {
        static WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();

        public static void VolumeUp()
        {
            Player.settings.volume = Player.settings.volume + 5;
        }

        public static void VolumeDown()
        {
            Player.settings.volume = Player.settings.volume - 5;
        }

        static void song()
        {
            Player.settings.volume = 1;
            Player.URL = "c:\\LP-Other-People_10699617.mp3";
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.UpArrow)
                {
                    VolumeUp();
                }
                if (Console.ReadKey(true).Key == ConsoleKey.DownArrow)
                {
                    VolumeDown();
                }
            }
        }
        static void time()
        {
            while (true)
            {
                Console.SetCursorPosition(Console.WindowWidth - Console.WindowWidth / 8, 0);
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                Thread.Sleep(1000);
                Console.SetCursorPosition(Console.WindowWidth - Console.WindowWidth / 8, 0);
                Console.WriteLine("        ");
            }
        }

        static void volume()
        {
            if (Console.ReadKey(true).Key == ConsoleKey.UpArrow)
            {
                VolumeUp();
            }
            if (Console.ReadKey(true).Key == ConsoleKey.DownArrow)
            {
                VolumeDown();
            }
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(time);
            Thread t2 = new Thread(song);
            Thread t3 = new Thread(volume);
            t1.Start();
            t2.Start();
            t3.Start();
            Console.ReadKey();
        }
    }
}
