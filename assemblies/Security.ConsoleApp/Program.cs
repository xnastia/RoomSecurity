using System;
using System.Collections.Generic;
using Security.Entities;

namespace Security.Example
{
    internal class Program
    {
        public static RoomMonitor DataCreator()
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

            var roomMonitor = new RoomMonitor();
            roomMonitor.PresenseRules = presentRules;
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
            return roomMonitor;
        }
        private static void Main()
        {
            var roomMonitor=new RoomMonitor();
            roomMonitor = DataCreator();
            AllowedTime allowedTime=new AllowedTime(new TimeSpan(10,00,00), new TimeSpan(15,00,00) );

           Console.WriteLine(roomMonitor.IsIntruderInRoom(new TimeSpan(11, 00, 00)));
           Console.ReadLine();
        }
    }
}