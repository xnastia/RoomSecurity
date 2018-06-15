using System;
using System.Collections.Generic;
using Security.Entities;

namespace Security.Example
{
    internal class Program
    {
        private static void Main()
        {
            var presentRules = new Dictionary<BadgeType, List<AllowedTime>>();
            var visitorAllowedTimes =
                new List<AllowedTime> {new AllowedTime(new TimeSpan(10, 00, 00), new TimeSpan(15, 00, 00))};
            var supportAllowedTimes =
                new List<AllowedTime> {new AllowedTime(new TimeSpan(8, 00, 00), new TimeSpan(20, 00, 00))};
            var securityOfficerAllowedTimes =
                new List<AllowedTime> {new AllowedTime(new TimeSpan(0, 00, 00), new TimeSpan(0, 00, 00))};

            presentRules.Add(BadgeType.Visitor, visitorAllowedTimes);
            presentRules.Add(BadgeType.Support, visitorAllowedTimes);
            presentRules.Add(BadgeType.SecurityOfficer, visitorAllowedTimes);
            presentRules.Add(BadgeType.NoBadge, visitorAllowedTimes);

            var roomMonitor = new RoomMonitor();
            roomMonitor.PresentRules = presentRules;
            roomMonitor.Cameras = new List<Camera>
            {
                new Camera(new List<BadgeType> {BadgeType.Visitor, BadgeType.Support, BadgeType.Visitor}),
                new Camera(new List<BadgeType>
                {
                    BadgeType.Visitor,
                    BadgeType.Support,
                    BadgeType.Visitor,
                    BadgeType.SecurityOfficer
                }),
                new Camera(new List<BadgeType>
                {
                    BadgeType.Visitor,
                    BadgeType.Support,
                    BadgeType.NoBadge,
                    BadgeType.SecurityOfficer
                }),
                new Camera(new List<BadgeType>
                {
                    BadgeType.SecurityOfficer,
                    BadgeType.Support,
                    BadgeType.Visitor,
                    BadgeType.SecurityOfficer
                })
            };
            Console.WriteLine(roomMonitor.IsIntruderInRoom(new TimeSpan(11, 00, 00)));
            Console.ReadLine();
        }
    }
}