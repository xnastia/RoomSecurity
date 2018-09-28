using Security.Entities;
using System.Collections.Generic;

namespace Security.BusinessLogic
{
    public interface IMonitorSnapshot
    {
        List<ScannerStatus> SecurityScannerStatuses { get; set; }
        IRoomProvider RoomProvider { get; set; }
        string CurrentTime { get; set; }
    }
}