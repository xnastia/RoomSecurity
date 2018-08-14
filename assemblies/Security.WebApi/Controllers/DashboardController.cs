using System;
using System.Web.Http;
using Security.BusinessLogic;
using Security.Entities;

namespace Security.WebApi.Controllers
{
    public class DashboardController : ApiController
    {
        public DashboardStatus GetMonitorStatus(int monitorId)
        {
            var monitorSnapshot = new SnapshotApi().GetMonitorSnapshot(monitorId);
            var floorScannerStatuses = monitorSnapshot.SecurityScannerStatuses;
            var checkTime = monitorSnapshot.CurrentTime;
            return monitorSnapshot;
        }

        public DashboardStatus GetAlarmHistory(int monitorId, string roomName)
        {
            var monitorSnapshot = new SnapshotApi().GetMonitorSnapshot(monitorId);
            var floorScannerStatuses = monitorSnapshot.SecurityScannerStatuses;
            var checkTime = monitorSnapshot.CurrentTime;
            AlarmStatusProvider alarmStatusProvider = new AlarmStatusProvider();
            var alarmStatuses = alarmStatusProvider.GetAlarmStatusByRoomName(roomName);
            DashboardStatus floorDashboardStatus = new DashboardStatus(checkTime, floorScannerStatuses, alarmStatuses);
            return floorDashboardStatus;
        }
    }
}
