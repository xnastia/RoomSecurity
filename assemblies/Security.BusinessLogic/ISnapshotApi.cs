using System;
using System.Collections.Generic;
using Security.Entities;

namespace Security.BusinessLogic
{
    public interface ISnapshotApi
    {
        List<ScannerStatus> SecurityScannerStatuses { get; set; }
        string CurrentTime { get; set; }
        MonitorSnapshot GetMonitorSnapshot(Guid monitorId);
    }
}
