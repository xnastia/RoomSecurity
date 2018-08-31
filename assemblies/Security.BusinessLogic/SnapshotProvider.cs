using System.Collections.Generic;
using Security.DataLayer.EF;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class SnapshotProvider : ISnapshotProvider
    {
        private readonly Dictionary<Monitor, MonitorSnapshot> _monitorSnapshot =
            new Dictionary<Monitor, MonitorSnapshot>();

        private readonly IAlarmStatusProvider _alarmStatusProvider;
        
        public SnapshotProvider(IAlarmStatusProvider alarmStatusProvider)
        {
            _alarmStatusProvider = alarmStatusProvider;
        }

        public MonitorSnapshot GetMonitorSnapshot(Monitor monitor)
        {
            if (!_monitorSnapshot.ContainsKey(monitor))
                _monitorSnapshot.Add(monitor, CreateMonitorSnapshot(monitor));

            return _monitorSnapshot[monitor];
        }

        private MonitorSnapshot CreateMonitorSnapshot(IMonitor monitor)
        {
            var monitorSnapshot = new MonitorSnapshot(new RoomProvider(new RoomRepository()))
            {
                SecurityScannerStatuses = new List<ScannerStatus>()
            };
            monitor.EventOnCheckDone += monitorSnapshot.UpdateStatus;
            monitor.EventOnIntruderDetected += _alarmStatusProvider.InsertCheckerResponseIntoAlarmStatus;
            
            return monitorSnapshot;
        }
    }
}