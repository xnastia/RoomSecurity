using System.Collections.Generic;
using System.Linq;
using Security.Entities;

namespace Security.WebSite.Models
{
    public class FirstFloorMonitorSnapshot
    {
        public List<ScannerStatus> SecurityScannerStatuses { get; set; }

        private static FirstFloorMonitorSnapshot _monitorSnapshot;

        public string CurrentTime { get; set; }

        private FirstFloorMonitorSnapshot()
        {
        }

        public static FirstFloorMonitorSnapshot GetMonitorSnapshot()
        {
            if (_monitorSnapshot == null)
            {
                Monitor monitor = FirstFloorSecurityDashboardBuilder.CreateMonitor();
                var dashboard = FirstFloorSecurityDashboardBuilder.CreateDashboard(monitor);
                dashboard.StartScanning();
                _monitorSnapshot = new FirstFloorMonitorSnapshot(monitor);
            }

            return _monitorSnapshot;
        }

        private FirstFloorMonitorSnapshot(Monitor monitor)
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
}