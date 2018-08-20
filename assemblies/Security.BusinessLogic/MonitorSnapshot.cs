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
            string roomName = roomProvider.GetRoomName(checkerResponse.ScannerId);
            var securityScannerWithSameName = SecurityScannerStatuses.SingleOrDefault(x => x.RoomName == roomName);

            if (securityScannerWithSameName == null)
            {
                securityScannerWithSameName = new ScannerStatus
                {
                    RoomName = roomName,
                };
                SecurityScannerStatuses.Add(securityScannerWithSameName);
            }

            securityScannerWithSameName.IsOk = !checkerResponse.IntruderFound;
        }
    }
}