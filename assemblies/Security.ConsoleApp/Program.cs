using System;
using System.Collections.Generic;
using Security.Entities;

namespace Security.Example
{
    internal class Program
    {
        public static RoomSecurityChecker CreateRoomSecurityChecker()
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

            var roomSecurityChecker = new RoomSecurityChecker();
            roomSecurityChecker.PresenseRules = presentRules;
            roomSecurityChecker.Cameras = new List<Camera>
            {new Camera(),new Camera(),new Camera(),new Camera()};
            return roomSecurityChecker;
        }

        private static void Main()
        {
            var roomSecurityChecker = CreateRoomSecurityChecker();
            RoomMonitor roomMonitor = new RoomMonitor(DateTime.Now.TimeOfDay, roomSecurityChecker);
            roomMonitor.Start();
            Console.WriteLine("Press Enter to stop and exit");
            Console.ReadLine();
            roomMonitor.End();
        }
    }
}