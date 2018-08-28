using System;
using System.Collections.Generic;
using System.Web.Http;
using Security.BusinessLogic;
using Security.Entities;

public static class Test
{
    public static readonly SnapshotApi _snapshotApi = new SnapshotApi();
}

namespace Security.WebApi.Controllers
{
    public class DashboardController : ApiController
    {
        private readonly SnapshotApi _snapshotApi = new SnapshotApi();
        public DashboardStatus GetMonitorStatus(Guid monitorId)
        {
            var monitorSnapshot = Test._snapshotApi.GetMonitorSnapshot(monitorId);
            var floorScannerStatuses = monitorSnapshot.SecurityScannerStatuses;
            var checkTime = monitorSnapshot.CurrentTime;
            DashboardStatus floorDashboardStatus = new DashboardStatus(checkTime, floorScannerStatuses);
            
            return floorDashboardStatus;
        }

        public List<AlarmStatus> GetAlarmStatusHistory(Guid roomId, int page)
        {
            AlarmStatusProvider alarmStatusProvider = new AlarmStatusProvider();
            return alarmStatusProvider.GetAlarmStatusByRoomUiId(roomId,page);
        }

        public List<MonitorTab> GetMonitors()
        {
            MonitorProvider monitorProvider = new MonitorProvider();
            return monitorProvider.GetMonitorsTabList();
        }
    }
}
