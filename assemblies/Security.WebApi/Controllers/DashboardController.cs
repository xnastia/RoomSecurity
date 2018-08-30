using System;
using System.Collections.Generic;
using System.Web.Http;
using Security.BusinessLogic;
using Security.Entities;
using Security.Entities.DB;

namespace Security.WebApi.Controllers
{
    public class DashboardController : ApiController
    {
        private readonly ISnapshotApi _snapshotApi;
        private IAlarmStatusProvider _alarmStatusProvider;
        private IMonitorProvider _monitorProvider;

        public DashboardController(ISnapshotApi snapshotApi, IAlarmStatusProvider alarmStatusProvider,
            IMonitorProvider monitorProvider)
        {
            _snapshotApi = snapshotApi;
            _alarmStatusProvider = alarmStatusProvider;
            _monitorProvider = monitorProvider;
        }
        
        public DashboardStatus GetMonitorStatus(Guid monitorId)
        {
            var monitorSnapshot = _snapshotApi.GetMonitorSnapshot(monitorId);
            var floorScannerStatuses = monitorSnapshot.SecurityScannerStatuses;
            var checkTime = monitorSnapshot.CurrentTime;
            DashboardStatus floorDashboardStatus = new DashboardStatus(checkTime, floorScannerStatuses);
            
            return floorDashboardStatus;
        }

        public List<AlarmStatus> GetAlarmStatusHistory(Guid roomId, int page)
        {
            return _alarmStatusProvider.GetAlarmStatusByRoomUiId(roomId,page);
        }

        public int GetAlarmStatusesNumber(Guid roomId)
        {
            return _alarmStatusProvider.CountAlarmStatuses(roomId);
        }

        public List<MonitorTab> GetMonitors()
        {
            return _monitorProvider.GetMonitorsTabList();
        }
    }
}
