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
            ViewBag.currentTime = MonitorSnapshot.CurrentTime;
            ViewBag.securityScannerStatuses = MonitorSnapshot.GetMonitorSnapshot().SecurityScannerStatuses;
            return View("SecurityDashboard");
        }
    }
}