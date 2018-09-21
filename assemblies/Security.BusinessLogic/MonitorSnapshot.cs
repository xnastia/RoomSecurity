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

        public void UpdateStatus(CheckerResponse checkerResponse)
        {
            CurrentTime = checkerResponse.CheckTime.ToString("f");
            RoomShortInfo roomInfo = RoomProvider.GetRoomInfoById(checkerResponse.ScannerId);
            var securityScannerWithSameUiId = SecurityScannerStatuses
                .FirstOrDefault(scannerStatus => scannerStatus.RoomInfo.UiId == roomInfo.UiId);

            if (securityScannerWithSameUiId == null)
            {
                securityScannerWithSameUiId = new ScannerStatus
                {
                    RoomInfo = new RoomShortInfo() { Name = roomInfo.Name, UiId = roomInfo.UiId}
                };
                SecurityScannerStatuses.Add(securityScannerWithSameUiId);
            }

            securityScannerWithSameUiId.IsOk = !checkerResponse.IntruderFound;
        }
    }
}