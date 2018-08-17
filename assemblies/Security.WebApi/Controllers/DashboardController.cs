using System;
using System.Collections.Generic;
using System.Web.Http;
using Security.BusinessLogic;
using Security.Entities;

namespace Security.WebApi.Controllers
{
    public class DashboardController : ApiController
    {
        public DashboardStatus GetMonitorStatus(Guid monitorId)
        {
            var monitorSnapshot = new SnapshotApi().GetMonitorSnapshot(monitorId);
            var floorScannerStatuses = monitorSnapshot.SecurityScannerStatuses;
            var checkTime = monitorSnapshot.CurrentTime;
            DashboardStatus floorDashboardStatus = new DashboardStatus(checkTime, floorScannerStatuses);
            return floorDashboardStatus;
        }

        public List<AlarmStatus> GetAlarmStatusHistory(string roomName)
        {
            AlarmStatusProvider alarmStatusProvider = new AlarmStatusProvider();
            return alarmStatusProvider.GetAlarmStatusByRoomName(roomName);
        }

        public List<MonitorTab> GetMonitors()
        {
            MonitorProvider monitorProvider = new MonitorProvider();
            return monitorProvider.GetMonitorsTabList();
        }
    }

 
}
