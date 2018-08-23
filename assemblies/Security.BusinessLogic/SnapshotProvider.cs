using System.Collections.Generic;
using Security.Entities;
using Security.Entities.DB;

namespace Security.BusinessLogic
{
    internal class SnapshotProvider
    {
        private static readonly Dictionary<Monitor, MonitorSnapshot> MonitorSnapshot =
            new Dictionary<Monitor, MonitorSnapshot>();

        public MonitorSnapshot GetMonitorSnapshot(Monitor monitor)
        {
            if (!MonitorSnapshot.ContainsKey(monitor))
                MonitorSnapshot.Add(monitor, CreateMonitorSnapshot(monitor));

            return MonitorSnapshot[monitor];
        }

        private static MonitorSnapshot CreateMonitorSnapshot(Monitor monitor)
        {
            var monitorSnapshot = new MonitorSnapshot
            {
                SecurityScannerStatuses = new List<ScannerStatus>()
            };
            monitor.EventOnCheckDone += monitorSnapshot.UpdateStatus;

            var alarmStatusProvider = new AlarmStatusProvider();
            monitor.EventOnIntruderDetected += alarmStatusProvider.InsertCheckerResponseIntoAlarmStatus;
            return monitorSnapshot;
        }
    }
}