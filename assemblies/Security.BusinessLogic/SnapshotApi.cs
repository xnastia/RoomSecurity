using System;
using System.Collections.Generic;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class SnapshotApi : ISnapshotApi
    {
        private IMonitorProvider _monitorProvider;
        private ISnapshotProvider _snapshotProvider;
        public List<ScannerStatus> SecurityScannerStatuses { get; set; }
        public string CurrentTime { get; set; }

        public SnapshotApi(IMonitorProvider monitorProvider, ISnapshotProvider snapshotProvider)
        {
            _monitorProvider = monitorProvider;
            _snapshotProvider = snapshotProvider;
        }

        public MonitorSnapshot GetMonitorSnapshot(Guid monitorId)
        {
            Monitor monitor = _monitorProvider.GetMonitor(monitorId);
            if (monitor == null)
                return null;

            return _snapshotProvider.GetMonitorSnapshot(monitor);
        }
    }
}