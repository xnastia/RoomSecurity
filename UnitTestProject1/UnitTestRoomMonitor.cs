using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Security.Entities;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestRoomMonitor
    {
        RoomMonitor _roomMonitor = TestDataCreator();
        public static RoomMonitor TestDataCreator()
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
           return roomMonitor;
        }
      
        [TestMethod]
        public void TestIsBadgeAllowed()
        {
            _roomMonitor.IsBadgeAllowed(BadgeType.Visitor, new TimeSpan(11, 00, 00));
            IsTrue(_roomMonitor.IsBadgeAllowed(BadgeType.Visitor, new TimeSpan(12, 00, 00)));
        }
        [TestMethod]
        public void TestIsAreaSafety()
        {
            IsTrue(_roomMonitor.IsAreaSafety(new TimeSpan(11, 00, 00), new Camera(new List<BadgeType> { BadgeType.Visitor, BadgeType.Support, BadgeType.Visitor })));
            
        }
        [TestMethod]
        public void TestIsIntruderInRoom()
        {
            IsTrue(_roomMonitor.IsIntruderInRoom(new TimeSpan(11, 00, 00)));
        }


    }
}
