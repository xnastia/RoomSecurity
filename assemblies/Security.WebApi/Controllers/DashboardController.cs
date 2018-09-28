using System;
using System.Collections.Generic;
using System.Web.Http;
using Security.BusinessLogic;
using Security.Entities;

namespace Security.WebApi.Controllers
{
    [MyAuthentication]
    public class DashboardController : ApiController
    {
        private readonly ISnapshotApi _snapshotApi;
        private IAlarmStatusProvider _alarmStatusProvider;
        private IMonitorProvider _monitorProvider;
        private readonly IAuthenticationProvider _authenticationProvider;
        
        public DashboardController(ISnapshotApi snapshotApi, IAlarmStatusProvider alarmStatusProvider,
            IMonitorProvider monitorProvider, IAuthenticationProvider authenticationProvider)
        {
            _snapshotApi = snapshotApi;
            _alarmStatusProvider = alarmStatusProvider;
            _monitorProvider = monitorProvider;
            _authenticationProvider = authenticationProvider;
        }
        
        public IHttpActionResult GetMonitorStatus(Guid monitorId)
        {
            var monitorSnapshot = _snapshotApi.GetMonitorSnapshot(monitorId);

            if (monitorSnapshot == null)
            {
                return NotFound();
            }

            var floorScannerStatuses = monitorSnapshot.SecurityScannerStatuses;
            var checkTime = monitorSnapshot.CurrentTime;
            DashboardStatus floorDashboardStatus = new DashboardStatus(checkTime, floorScannerStatuses);
            
            return Ok(floorDashboardStatus);
        }

        public List<AlarmStatus> GetAlarmStatusHistory(Guid roomId, int page)
        {
            return _alarmStatusProvider.GetAlarmStatusByRoomUiId(roomId, page);
        }

        public int GetAlarmStatusesNumber(Guid roomId)
        {
            return _alarmStatusProvider.CountAlarmStatuses(roomId);
        }

        public List<MonitorTab> GetMonitors()
        {
            var token = RequestContext.Principal.Identity.Name;
            string email = _authenticationProvider.GetUserByToken(token);
            var monitorTabs = _monitorProvider.GetMonitorsTabList(email);
            //_monitorProvider.SetUserTokenSession(token);
            return monitorTabs;
        }
    }
}
