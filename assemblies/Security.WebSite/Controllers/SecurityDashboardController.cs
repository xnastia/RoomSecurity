using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Security.Entities;
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

        public ActionResult GetMonitorStatus(int monitorId)
        {
            var monitorSnapshot = MonitorSnapshot.GetMonitorSnapshot(GetMonitor(monitorId));
            var firstFloorScannerStatuses = monitorSnapshot.SecurityScannerStatuses;
            var checkTime = monitorSnapshot.CurrentTime;
            DashboardStatus firstFloorDashboardStatus = new DashboardStatus(checkTime, firstFloorScannerStatuses);
            return Json(firstFloorDashboardStatus, JsonRequestBehavior.AllowGet);
        }

        #region Logic to move outside of controller

        private static Dictionary<int, Monitor> _monitors = new Dictionary<int, Monitor>();

        private Monitor GetMonitor(int monitorId)
        {
            if (!_monitors.ContainsKey(monitorId))
            {
                switch (monitorId)
                {
                    case 1:
                        var monitor = FirstFloorSecurityDashboardBuilder.CreateMonitor();
                        new SecurityDashboard(new TimerScanInvoker(), monitor).StartScanning();
                        _monitors.Add(monitorId, monitor);
                        break;
                    case 2:
                        var monitor2 = SecondFloorSecurityDashboardBuilder.CreateMonitor();
                        new SecurityDashboard(new TimerScanInvoker(), monitor2).StartScanning();
                        _monitors.Add(monitorId, monitor2);
                        break;
                    default:
                        throw new ArgumentException("The only \"1\" or \"2\" are valid Ids for now", nameof(monitorId));
                }
            }
            return _monitors[monitorId];
        }

        #endregion
    }

    public class DashboardStatus
    {
        public string CheckTime { get; set; }

        public List<ScannerStatus> SecurityScannerStatuses { get; set; }

        public DashboardStatus(string checkTime, List<ScannerStatus> securityScannerStatuses)
        {
            CheckTime = checkTime;
            SecurityScannerStatuses = securityScannerStatuses;
        }
    }
}