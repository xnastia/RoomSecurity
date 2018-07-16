using System;
using System.Collections.Generic;

namespace Security.BusinessLogic
{
    public class MonitorProvider
    {
        private static readonly Dictionary<int, Monitor> Monitors = new Dictionary<int, Monitor>();

        public Monitor GetMonitor(int monitorId)
        {
            if (!Monitors.ContainsKey(monitorId))
            {
                switch (monitorId)
                {
                    case 1:
                        var monitor = FirstFloorSecurityDashboardBuilder.CreateMonitor();
                        new SecurityDashboard(new TimerScanInvoker(), monitor).StartScanning();
                        Monitors.Add(monitorId, monitor);
                        break;
                    case 2:
                        var monitor2 = SecondFloorSecurityDashboardBuilder.CreateMonitor();
                        new SecurityDashboard(new TimerScanInvoker(), monitor2).StartScanning();
                        Monitors.Add(monitorId, monitor2);
                        break;
                    default:
                        throw new ArgumentException("Development in progress: The only \"1\" or \"2\" are valid Ids for now", nameof(monitorId));
                }
            }
            return Monitors[monitorId];
        }
    }
}