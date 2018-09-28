using System.Collections.Generic;
using System.Linq;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class MonitorSnapshot : IMonitorSnapshot
    {
        public List<ScannerStatus> SecurityScannerStatuses { get; set; }
        public IRoomProvider RoomProvider { get; set; }
        public string CurrentTime { get; set; }

        public MonitorSnapshot(IRoomProvider roomProvider)
        {
            RoomProvider = roomProvider;
        }
    }
}