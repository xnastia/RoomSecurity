using System;
using System.Collections.Generic;
using Security.Entities;

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
            /*List<string> alarmMessages = new List<string>();
            alarmMessageHandler.HandleAlarmMessage(alarmMessages);*/
            Alarmer alarmer = new Alarmer(alarmMessageHandler);
            securityDashboard.Monitor.EventOnIntruder += alarmer.OnIntruder;
            timerScanInvoker.Start();
            Console.ReadLine();
        }
    }
}

