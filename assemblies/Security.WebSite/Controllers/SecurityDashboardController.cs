using System.Web.Mvc;
using Security.BusinessLogic;
using Security.Entities;

namespace Security.WebSite.Controllers
{
    [AllowAnonymous]
    public class SecurityDashboardController : Controller
    {
        // GET: SecurityDashboard
        public ActionResult Index()
        {
            return View("SecurityDashboard");
        }

        public ActionResult GetSecurityDashboardStatus()
        {
            return PartialView("SecurityDashboardStatus");
        }

        public ActionResult GetMonitorStatus(int monitorId)
        {
            var monitorSnapshot = new SnapshotApi().GetMonitorSnapshot(monitorId);
            var firstFloorScannerStatuses = monitorSnapshot.SecurityScannerStatuses;
            var checkTime = monitorSnapshot.CurrentTime;
            DashboardStatus firstFloorDashboardStatus = new DashboardStatus(checkTime, firstFloorScannerStatuses);
            return Json(firstFloorDashboardStatus, JsonRequestBehavior.AllowGet);
        }
    }
}