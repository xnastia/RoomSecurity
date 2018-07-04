using System.Collections.Generic;
using Security.Entities;

namespace Security.Models
{
    public class MonitorSnapshot
    {
        public Dictionary<string, bool> SecurityScannerStatuses { get; set; }

        private static MonitorSnapshot _monitorSnapshot;

        private MonitorSnapshot()
        {
        }

        public static MonitorSnapshot GetMonitorSnapshot()
        {
            if (_monitorSnapshot == null)
            {
                Monitor monitor = SecurityDashboardBuilder.CreateMonitor();
                var dashboard = SecurityDashboardBuilder.CreateDashboard(monitor);
                dashboard.StartScanning();
                _monitorSnapshot = new MonitorSnapshot(monitor);
            }

            return _monitorSnapshot;
        }

        private MonitorSnapshot(Monitor monitor)
        {
            SecurityScannerStatuses = new Dictionary<string, bool>();
            monitor.EventOnCheckDone += MonitorOnEventOnCheckDone;
        }

        private void MonitorOnEventOnCheckDone(CheckerResponse checkerResponse)
        {
            SecurityScannerStatuses[checkerResponse.ScannerName] = checkerResponse.IntruderFound;
        }
    }
}