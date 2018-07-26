using System.Web.Http;
using Security.BusinessLogic;
using Security.Entities;

namespace Security.WebApi.Controllers
{
    public class DashboardController : ApiController
    {
        [Authorize]
        public DashboardStatus GetMonitorStatus(int monitorId)
        {
            var monitorSnapshot = new SnapshotApi().GetMonitorSnapshot(monitorId);
            var firstFloorScannerStatuses = monitorSnapshot.SecurityScannerStatuses;
            var checkTime = monitorSnapshot.CurrentTime;
            DashboardStatus floorDashboardStatus = new DashboardStatus(checkTime, firstFloorScannerStatuses);
            return floorDashboardStatus;
        }
    }
}
