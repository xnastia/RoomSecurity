using System;
using System.Collections.Generic;
using System.Linq;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class SnapshotApi
    {
        private MonitorProvider _monitorProvider = new MonitorProvider();
        private SnapshotProvider _snapshotProvider = new SnapshotProvider();

        public List<ScannerStatus> SecurityScannerStatuses { get; set; }

        public string CurrentTime { get; set; }


        public MonitorSnapshot GetMonitorSnapshot(Guid monitorId)
        {
            Monitor monitor = _monitorProvider.GetMonitor(monitorId);
            return _snapshotProvider.GetMonitorSnapshot(monitor);
        }
    }
}