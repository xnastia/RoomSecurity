using System.Web.Mvc;
using Security.WebSite.Models;

namespace Security.WebSite.Controllers
{
    [Authorize]
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

        public ActionResult GetCurrentDashboardStatus()
        {
            return Json(MonitorSnapshot.GetMonitorSnapshot().SecurityScannerStatuses, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCheckTime()
        {
           return Json(MonitorSnapshot.GetMonitorSnapshot().CurrentTime, JsonRequestBehavior.AllowGet);
        }
    }
}