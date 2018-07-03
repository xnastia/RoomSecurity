using System;
using System.Collections.Generic;
using Security.Entities;
using System.Threading;
using System.Timers;
using Timer = System.Threading.Timer;

namespace Security.Example
{
    internal class Program
    {
       /* public System.Timers.Timer CurrentTimer;
        public TimeSpan CurrentTime = new TimeSpan();

        public void StartTimer()
        {
            CurrentTimer.Enabled = true;
            CurrentTimer.Interval = 1000;
            CurrentTimer.Elapsed += OnScan;
        }

        private void OnScan(object sender, ElapsedEventArgs e)
        {
            CurrentTime += new TimeSpan(0, 30, 0);
            if (CurrentTime.Hours >= 24)
                CurrentTime = new TimeSpan(0, 0, 0);

            OnScanInvoke?.Invoke(CurrentTime);
        }*/

        private static void Main()
        {

            TimerScanInvoker timerScanInvoker = new TimerScanInvoker();
            SecurityDashboard securityDashboard = new SecurityDashboard(timerScanInvoker);
            securityDashboard.StartScanning();
            IAlarmMessageHandler alarmMessageHandler = new ConsoleAlarmMessageHandler();
            Alarmer alarmer = new Alarmer(alarmMessageHandler);
            securityDashboard.Monitor.EventOnIntruderDetected += alarmer.OnIntruderDetected;
            Console.ReadLine();
        }
    }
}

