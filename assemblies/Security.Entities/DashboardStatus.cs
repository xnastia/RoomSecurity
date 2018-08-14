using System;
using System.Collections.Generic;

namespace Security.Entities
{
    public class DashboardStatus
    {
        public string CheckTime { get; set; }

        public List<ScannerStatus> SecurityScannerStatuses { get; set; }

        public List< AlarmStatus> AlarmStatuses { get; set; }

        public DashboardStatus(DateTime checkTime, List<ScannerStatus> securityScannerStatuses, 
            List<AlarmStatus> alarmStatuses)
        {
            CheckTime = checkTime.ToString("yyyy-MM-dd HH:mm:ss");
            SecurityScannerStatuses = securityScannerStatuses;
            AlarmStatuses = alarmStatuses;
        }
    }
}