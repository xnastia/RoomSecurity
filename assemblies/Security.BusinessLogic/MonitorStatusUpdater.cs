using Security.Entities;
using System.Linq;

namespace Security.BusinessLogic
{
    class MonitorStatusUpdater
    {
        private IMonitorSnapshot _monitorSnapshot;

        public MonitorStatusUpdater(IMonitorSnapshot monitorSnapshot)
        {
            _monitorSnapshot = monitorSnapshot;
        }

        public void UpdateStatus(CheckerResponse checkerResponse)
        {
            _monitorSnapshot.CurrentTime = checkerResponse.CheckTime.ToString("f");
            RoomShortInfo roomInfo = _monitorSnapshot.RoomProvider.GetRoomInfoById(checkerResponse.ScannerId);
            var securityScannerWithSameUiId = _monitorSnapshot.SecurityScannerStatuses
                .FirstOrDefault(scannerStatus => scannerStatus.RoomInfo.UiId == roomInfo.UiId);

            if (securityScannerWithSameUiId == null)
            {
                securityScannerWithSameUiId = new ScannerStatus
                {
                    RoomInfo = new RoomShortInfo() { Name = roomInfo.Name, UiId = roomInfo.UiId }
                };
                _monitorSnapshot.SecurityScannerStatuses.Add(securityScannerWithSameUiId);
            }

            securityScannerWithSameUiId.IsOk = !checkerResponse.IntruderFound;
        }
    }
}
