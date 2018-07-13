using System.Collections.Generic;
using System.Linq;
using Security.Entities;

namespace Security.WebSite.Models
{
    public class MonitorSnapshot
    {
        public List<ScannerStatus> SecurityScannerStatuses { get; set; }

        public string CurrentTime { get; set; }

        private static readonly Dictionary<Monitor, MonitorSnapshot> _monitorSnapshot = new Dictionary<Monitor, MonitorSnapshot>();
        
        public static MonitorSnapshot GetMonitorSnapshot(Monitor monitor)
        {
            if (!_monitorSnapshot.ContainsKey(monitor))
            {
                _monitorSnapshot.Add(monitor, new MonitorSnapshot(monitor));
            }

            return _monitorSnapshot[monitor];
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
}