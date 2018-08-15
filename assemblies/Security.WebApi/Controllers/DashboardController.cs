using System;
using System.Collections.Generic;
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
            return new List<MonitorTab>
            {
                new MonitorTab {Id = 1, Name = "First Floor"},
                new MonitorTab {Id = 2, Name = "Second Floor"},
                new MonitorTab {Id = 3, Name = "Third Floor"},
            };
            //return new List<MonitorTab>
            //{
            //    new MonitorTab {Id = Guid.NewGuid(), Name = "First Floor"},
            //    new MonitorTab {Id = Guid.NewGuid(), Name = "Second Floor"},
            //    new MonitorTab {Id = Guid.NewGuid(), Name = "Third Floor"},
            //};
        }
    }

    public class MonitorTab
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
