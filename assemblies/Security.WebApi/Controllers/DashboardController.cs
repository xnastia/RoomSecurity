using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Security.BusinessLogic;
using Security.Entities;

namespace Security.WebApi.Controllers
{
    //[MyAuthentication]
    public class DashboardController : ApiController
    {
        private readonly ISnapshotApi _snapshotApi;
        private readonly IAlarmStatusProvider _alarmStatusProvider;
        private readonly IMonitorProvider _monitorProvider;
        private readonly IAuthenticationProvider _authenticationProvider;
        private static TimerScanInvoker _timerScanInvoker;
        private static List<SecurityDashboard> _enabledMonitorsDashboards;

        public DashboardController(ISnapshotApi snapshotApi, IAlarmStatusProvider alarmStatusProvider,
            IMonitorProvider monitorProvider, IAuthenticationProvider authenticationProvider)
        {
            _snapshotApi = snapshotApi;
            _alarmStatusProvider = alarmStatusProvider;
            _monitorProvider = monitorProvider;
            _authenticationProvider = authenticationProvider;
            _timerScanInvoker = new TimerScanInvoker();
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

        [HttpPost]
        [Route("Dashboard/StartMonitor")]
        public IHttpActionResult StartMonitor(Guid id)
        {
            if (_enabledMonitorsDashboards == null)
                _enabledMonitorsDashboards = new List<SecurityDashboard>();
            
            Monitor monitor = _monitorProvider.GetMonitor(id);
            SecurityDashboard securityDashboard = new SecurityDashboard(_timerScanInvoker, monitor);

            foreach (var monitorDashboard in _enabledMonitorsDashboards)
            {
                if (securityDashboard.IsSameMonitor(monitorDashboard))
                    return Ok();
            }
            securityDashboard.StartScanning();
            _enabledMonitorsDashboards.Add(securityDashboard);
            return Ok();
        }

        [HttpPost]
        [Route("Dashboard/StopMonitor")]
        public IHttpActionResult StopMonitor(Guid id)
        {
            Monitor monitor = _monitorProvider.GetMonitor(id);
            SecurityDashboard securityDashboard = new SecurityDashboard(_timerScanInvoker, monitor);

            foreach (var dashboard in _enabledMonitorsDashboards)
            {
                if (dashboard.IsSameMonitor(securityDashboard))
                {
                    dashboard.StopScanning();
                    _enabledMonitorsDashboards.Remove(dashboard);
                    return Ok();
                }
            }
            
            return Ok();
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
