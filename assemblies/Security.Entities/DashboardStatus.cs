using System.Collections.Generic;

namespace Security.Entities
{
    public class DashboardStatus
    {
        public string CheckTime { get; set; }

        public List<ScannerStatus> SecurityScannerStatuses { get; set; }

        public List< AlarmStatus> AlarmStatuses { get; set; }

        public DashboardStatus(string checkTime, List<ScannerStatus> securityScannerStatuses, 
            List<AlarmStatus> alarmStatuses)
        {
            CheckTime = checkTime;
            SecurityScannerStatuses = securityScannerStatuses;
            AlarmStatuses = alarmStatuses;
        }
    }
}