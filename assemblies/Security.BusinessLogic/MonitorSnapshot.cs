using System.Collections.Generic;
using System.Linq;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class MonitorSnapshot
    {
        public List<ScannerStatus> SecurityScannerStatuses { get; set; }

        public string CurrentTime { get; set; }

        public void UpdateStatus(CheckerResponse checkerResponse)
        {
            CurrentTime = checkerResponse.CheckTime.ToString("f");
            RoomProvider roomProvider = new RoomProvider();
            RoomShortInfo roomInfo = roomProvider.GetRoomInfoById(checkerResponse.ScannerId);
            var securityScannerWithSameUiId = SecurityScannerStatuses
                .SingleOrDefault(scannerStatus => scannerStatus.RoomInfo.UiId == roomInfo.UiId);

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