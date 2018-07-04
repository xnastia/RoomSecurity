using Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Security.Models;

namespace Security.Controllers
{
    public class SecurityDashboardController : Controller
    {
        // GET: SecurityDashboard
        public ActionResult Index()
        {
            //ViewBag.rooms = MonitorSnapshot.GetMonitorSnapshot().SecurityScannerStatuses.Keys;
            //ViewBag.roomsSafeness = MonitorSnapshot.GetMonitorSnapshot().SecurityScannerStatuses.Values;
            ViewBag.securityScannerStatuses = MonitorSnapshot.GetMonitorSnapshot().SecurityScannerStatuses;
            return View("SecurityDashboard");
            //return View(MonitorSnapshot.GetMonitorSnapshot().SecurityScannerStatuses);
        }
    }
}