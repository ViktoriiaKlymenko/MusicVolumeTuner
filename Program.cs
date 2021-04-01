using System;
using System.Threading;

namespace musicvolume
{
    class Program
    {
        static WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();

        public static void volumeUp()
        {
            // method, that increases sound volume
            Player.settings.volume = Player.settings.volume + 5;
        }

        public static void volumeDown()
        {
            // method, that decreases sound volume
            Player.settings.volume = Player.settings.volume - 5;
        }

         static void time()
        {
            // method, that shows current time in the upper right corner
            while (true)
            {
                Console.SetCursorPosition(Console.WindowWidth - Console.WindowWidth / 10, 0);
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                Thread.Sleep(1000);
                Console.SetCursorPosition(Console.WindowWidth - Console.WindowWidth / 10, 0);
                Console.WriteLine("        ");
            }
        }
        
        static void song()
        {
            // method, that plays song
            Player.settings.volume = 1;
            Player.URL = "c:\\LP-Other-People_10699617.mp3";
        }

       static void volume()
        {
           // method, that cathces pressed key and detectes whether it's up or down key
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
