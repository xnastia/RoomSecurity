using System;
using System.Threading;
using System.Timers;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            TestTimer();

            Console.WriteLine("Finish");
            Console.ReadLine();
        }

        private static void TestTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Elapsed += TimerOnElapsed;

            Thread.Sleep(20000);
        }

        private static void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(1);
        }
    }
}
