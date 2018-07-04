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

