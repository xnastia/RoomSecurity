using System;
using System.Collections.Generic;

namespace Security.Entities
{
    public class SecurityDashboard
    {
        private readonly ITimerScanInvoker _timerScanInvoker;

        public Monitor Monitor { get; set; }

        public SecurityDashboard(ITimerScanInvoker timerScanInvoker)
        {
            _timerScanInvoker = timerScanInvoker;
            Monitor = InitMonitor();
        }

        private Monitor InitMonitor()
        {
            IRecognizer recognizer = new RandomRecognizer(12121213);
            List<Camera> cameras = new List<Camera>()
            {
                new Camera()
            };
           
            var presentRules = new Dictionary<BadgeType, List<AllowedTime>>();
            var visitorAllowedTimes =
                new List<AllowedTime> { new AllowedTime(new TimeSpan(10, 00, 00), new TimeSpan(15, 00, 00)) };
            var supportAllowedTimes =
                new List<AllowedTime> { new AllowedTime(new TimeSpan(8, 00, 00), new TimeSpan(20, 00, 00)) };
            var securityOfficerAllowedTimes =
                new List<AllowedTime> { new AllowedTime(new TimeSpan(00, 00, 00), new TimeSpan(24, 00, 00)) };
            var noBadgeAllowedTimes =
                new List<AllowedTime> { new AllowedTime(new TimeSpan(0, 00, 00), new TimeSpan(0, 00, 01)) };
            presentRules.Add(BadgeType.Visitor, visitorAllowedTimes);
            presentRules.Add(BadgeType.Support, supportAllowedTimes);
            presentRules.Add(BadgeType.SecurityOfficer, securityOfficerAllowedTimes);
            presentRules.Add(BadgeType.NoBadge, noBadgeAllowedTimes);

            SecurityScanner dinnerRoom =
                new SecurityScanner(presentRules, recognizer, cameras);
            SecurityScanner conferenceRoom =
                new SecurityScanner(presentRules, recognizer, cameras);
            SecurityScanner armoryRoom =
                new SecurityScanner(presentRules, recognizer, cameras);
            var securitryScanners = new List<SecurityScanner>
            {
                dinnerRoom,
                conferenceRoom,
                armoryRoom
            };

            return new Monitor(securitryScanners);
        }

        public void StartScanning()
        {
            _timerScanInvoker.OnScanInvoke += Monitor.Scan;
            _timerScanInvoker.Start();
        }

        public void StopScanning()
        {
            _timerScanInvoker.OnScanInvoke -= Monitor.Scan;
            _timerScanInvoker.End();
        }
    }
}