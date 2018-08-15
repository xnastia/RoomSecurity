﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Security.DataLayer;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class MonitorProvider
    {
        private static readonly Dictionary<int, Monitor> Monitors = new Dictionary<int, Monitor>();

        private SecurityScannerProvider _securityScannerProvider = new SecurityScannerProvider();
        
        public Monitor GetMonitor(Guid uiId)
        {
            MonitorRepository monitorRepository = new MonitorRepository();
            int monitorId = monitorRepository.GetMonitorIdByUiId(uiId);
            if (!Monitors.ContainsKey(monitorId))
            {
                switch (monitorId)
                {
                    case 1:
                        var monitor1 = CreateMonitor1();
                        new SecurityDashboard(new TimerScanInvoker(), monitor1).StartScanning();
                        Monitors.Add(monitorId, monitor1);
                        break;
                    case 2:
                        var monitor2 = CreateMonitor2();
                        new SecurityDashboard(new TimerScanInvoker(), monitor2).StartScanning();
                        Monitors.Add(monitorId, monitor2);
                        break;
                    default:
                        throw new ArgumentException("Development in progress: The only \"1\" or \"2\" are valid Ids for now", nameof(monitorId));
                }
            }
            return Monitors[monitorId];
        }
        public Monitor CreateMonitor1()
        {
            IRecognizer recognizer = new RandomRecognizer(12121213);
            var hall = _securityScannerProvider.CreateHall(recognizer);
            var conferenceRoom = _securityScannerProvider.CreateConferenceRoom(recognizer);
            var securitryScanners = new List<ISecurityScanner>
            {
                hall,
                conferenceRoom,
            };
            return new Monitor(securitryScanners);
        }

        public Monitor CreateMonitor2()
        {
            IRecognizer recognizer = new RandomRecognizer(12121213);
            var dinnerRoom = _securityScannerProvider.CreateDinnerRoom(recognizer);
            var armoryRoom = _securityScannerProvider.CreateArmoryRoom(recognizer);
            var securitryScanners = new List<ISecurityScanner>
            {
                dinnerRoom,
                armoryRoom
            };
            return new Monitor(securitryScanners);
        }

        public List<MonitorTab> GetMonitorsTabList()
        {
            MonitorRepository monitorRepository = new MonitorRepository();
            return monitorRepository.GeMonitorTabs();
        }
    }
}