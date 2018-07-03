using Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Security.Controllers
{
    public class SecurityDashboardController : Controller
    {
        // GET: SecurityDashboard
        public ActionResult Index()
        {
            TimerScanInvoker timerScanInvoker = new TimerScanInvoker();
            SecurityDashboard securityDashboard = new SecurityDashboard(timerScanInvoker);
            securityDashboard.StartScanning();
            IAlarmMessageHandler alarmMessageHandler = new AlarmMessageHandler();
            Alarmer alarmer = new Alarmer(alarmMessageHandler);
            securityDashboard.Monitor.EventOnIntruderDetected += alarmer.OnIntruderDetected;
            return View();
        }
    }
}