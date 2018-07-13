using System.Collections.Generic;
using System.Web.Mvc;
using Security.WebSite.Models;

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

        public ActionResult GetFirstFloorDashboardStatus()
        {
            return Json(FirstFloorMonitorSnapshot.GetMonitorSnapshot().SecurityScannerStatuses, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSecondFloorDashboardStatus()
        {
            return Json(SecondFloorMonitorSnapshot.GetMonitorSnapshot().SecurityScannerStatuses, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCheckTime()
        {
           return Json(FirstFloorMonitorSnapshot.GetMonitorSnapshot().CurrentTime, JsonRequestBehavior.AllowGet);
        }
    }
}