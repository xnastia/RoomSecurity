using System;
using System.Collections.Generic;

namespace Security.BusinessLogic
{
    public static class FirstFloorSecurityDashboardBuilder
    {
        public static SecurityDashboard CreateDashboard(Monitor monitor)
        {
            
            TimerScanInvoker timerScanInvoker = new TimerScanInvoker();
            SecurityDashboard securityDashboard = new SecurityDashboard(timerScanInvoker, monitor);
            
           return securityDashboard;
        }

        public static Monitor CreateMonitor()
        {
            IRecognizer recognizer = new RandomRecognizer(12121213);
            var dinnerRoom = CreateHall(recognizer);
            var conferenceRoom = CreateConferenceRoom(recognizer);
            var securitryScanners = new List<SecurityScanner>
            {
                dinnerRoom,
                conferenceRoom,
            };
            return new Monitor(securitryScanners);
        }

        private static SecurityScanner CreateConferenceRoom(IRecognizer recognizer)
        {
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

            List<Camera> conferenceRoomCameras = new List<Camera>()
            {
                new Camera(5),
                new Camera(6),
                new Camera(7),
                new Camera(8)
            };
            return new SecurityScanner("Conference room", presentRules, recognizer, conferenceRoomCameras);
        }

        private static SecurityScanner CreateHall(IRecognizer recognizer)
        {
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

            List<Camera> HallCameras = new List<Camera>()
            {
                new Camera(1),
                new Camera(2),
                new Camera(3),
                new Camera(4)
            };
            return new SecurityScanner("Hall", presentRules, recognizer, HallCameras);
        }

        
    }
}
