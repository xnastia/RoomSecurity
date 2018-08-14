using System;
using System.Collections.Generic;

namespace Security.Entities
{
    public class DashboardStatus
    {
        public string CheckTime { get; set; }

        public List<ScannerStatus> SecurityScannerStatuses { get; set; }
        
        public DashboardStatus(string checkTime, List<ScannerStatus> securityScannerStatuses)
        {
            CheckTime = checkTime;
            SecurityScannerStatuses = securityScannerStatuses;
        }
    }
}