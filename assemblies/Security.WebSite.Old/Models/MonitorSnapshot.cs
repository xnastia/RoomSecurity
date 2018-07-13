using System.Collections.Generic;
using System.Linq;
using Security.Entities;

namespace Security.WebSite.Old.Models
{
    public class MonitorSnapshot
    {
        public List<ScannerStatus> SecurityScannerStatuses { get; set; }

        private static MonitorSnapshot _monitorSnapshot;

        public string CurrentTime { get; set; }

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
            SecurityScannerStatuses = new List<ScannerStatus>();
            monitor.EventOnCheckDone += MonitorOnEventOnCheckDoneScannerStatus;
            monitor.EventOnCheckDone += MonitorOnEventOnCheckDoneGetCurrentTime;
        }

        private void MonitorOnEventOnCheckDoneScannerStatus(CheckerResponse checkerResponse)
        {
            var securityScannerWithSameName = SecurityScannerStatuses.SingleOrDefault(x => x.Name == checkerResponse.ScannerName);

            if (securityScannerWithSameName == null)
            {
                securityScannerWithSameName = new ScannerStatus
                {
                    Name = checkerResponse.ScannerName
                };
                SecurityScannerStatuses.Add(securityScannerWithSameName);
            }

            securityScannerWithSameName.IsOk = !checkerResponse.IntruderFound;
        }

        private void MonitorOnEventOnCheckDoneGetCurrentTime(CheckerResponse checkerResponse)
        {
            CurrentTime = checkerResponse.CheckTime.ToString("c");
        }
        
    }

    public class ScannerStatus
    {
        public string Name { get; set; }
        public bool IsOk { get; set; }
    }
}