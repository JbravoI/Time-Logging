using System;
using System.IO;
using System.Timers;

namespace Time_Logging
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        public static void Main()
        {
           

            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(10000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var path = @"C:\Users\Ewuji O. John\source\repos\Time Logging\TimeLogged.txt";
            File.WriteAllText(path, "");
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
            File.AppendAllLines(path, new String[] { "The Elapsed event was raised at {{0:HH:mm:ss.fff}} " + e.SignalTime } );

        }

        public void GetLoggedTime(string newPath)
        {

            while (sortedLog.Count > 0)
            {
                File.AppendAllLines(newPath, new string[] { sortedLog.Pop().ToString() });
            }
            Console.WriteLine("Logging done! Check created file for reversed log.");
        }

        public string FileMaker()
        {
            var path = @"C:\Users\Ewuji O. John\source\repos\Time Logging\TimeLogged.txt";
            File.Create(path);
            Console.WriteLine("Folder and file has been Created");

                return path;
        }
    }
}
