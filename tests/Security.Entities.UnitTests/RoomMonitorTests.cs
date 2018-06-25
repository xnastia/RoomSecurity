using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Security.Entities;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject1
{
    [TestFixture]
    public class RoomMonitorTests
    {
        class RoomCreator
        {
            public static Dictionary<BadgeType, List<AllowedTime>> PresenceRulesCreat()
            {
                var presenseRules = new Dictionary<BadgeType, List<AllowedTime>>();
                var visitorAllowedTimes =
                    new List<AllowedTime> { new AllowedTime(new TimeSpan(08, 00, 00), new TimeSpan(20, 00, 01)) };
                var supportAllowedTimes =
                    new List<AllowedTime> { new AllowedTime(new TimeSpan(10, 00, 00), new TimeSpan(15, 00, 00)) };
                var securityOfficerAllowedTimes =
                    new List<AllowedTime> { new AllowedTime(new TimeSpan(00, 00, 00), new TimeSpan(24, 00, 00)) };
                var noBadgeAllowedTimes =
                    new List<AllowedTime> { new AllowedTime(new TimeSpan(0, 00, 00), new TimeSpan(0, 00, 01)) };

                presenseRules.Add(BadgeType.Visitor, visitorAllowedTimes);
                presenseRules.Add(BadgeType.Support, supportAllowedTimes);
                presenseRules.Add(BadgeType.SecurityOfficer, securityOfficerAllowedTimes);
                presenseRules.Add(BadgeType.NoBadge, noBadgeAllowedTimes);
                return presenseRules;

            }
            public static RoomSecurityChecker CreateRoomSecurityCheckerWithSupportBadgeAndAllowedTimeFrom10To15()
            {
                int chanceRange = 1;
                Dictionary<BadgeType, int> badgesWithOccurancePossibility = new Dictionary<BadgeType, int>()
                {
                    { BadgeType.Visitor, 0},
                    {BadgeType.Support, 1},
                    {BadgeType.SecurityOfficer, 0},
                    {BadgeType.NoBadge, 0}
                };

                Recognizer recognizer=new Recognizer(chanceRange, badgesWithOccurancePossibility);

                Camera camera=new Camera(recognizer);

                var presenseRules = PresenceRulesCreat();

                    var withSupportBadgeAndAllowedTimeFrom10To15 = new RoomSecurityChecker();
                    withSupportBadgeAndAllowedTimeFrom10To15.PresenseRules = presenseRules;
                    withSupportBadgeAndAllowedTimeFrom10To15.Cameras = new List<Camera>
                        {camera};
                    return withSupportBadgeAndAllowedTimeFrom10To15;


            }

            public static RoomSecurityChecker CreateRoomSecurityCheckerWithNoBadge()
            {
                int chanceRange = 1;
                Dictionary<BadgeType, int> badgesWithOccurancePossibility = new Dictionary<BadgeType, int>()
                {
                    { BadgeType.Visitor, 0},
                    {BadgeType.Support, 0},
                    {BadgeType.SecurityOfficer, 0},
                    {BadgeType.NoBadge, 1}
                };

                Recognizer recognizer = new Recognizer(chanceRange, badgesWithOccurancePossibility);

                Camera camera = new Camera(recognizer);
                
                  var roomSecurityCheckerWithNoBadge = new RoomSecurityChecker();
                var presenseRules = PresenceRulesCreat();
                roomSecurityCheckerWithNoBadge.PresenseRules = presenseRules;
                roomSecurityCheckerWithNoBadge.Cameras = new List<Camera>
                        {camera};
                return roomSecurityCheckerWithNoBadge;
            }
        }
       
        [Test]
        public void IsBadgeAllowedRoomMonitorWithSupportBadgeAndAllowedTimeFrom10To15On13ReturnsTrue()
        {
            var roomMonitor = RoomCreator.CreateRoomSecurityCheckerWithSupportBadgeAndAllowedTimeFrom10To15();
            var isBadgeAllowed = roomMonitor.IsBadgeAllowed(BadgeType.Support, new TimeSpan(13, 00, 00));
            Assert.IsTrue(isBadgeAllowed);
        }
        [Test]
        public void IsBadgeAllowedRoomMonitorWithSupportBadgeAndAllowedTimeFrom10To15On17ReturnsFalse()
        {
            var roomMonitor = RoomCreator.CreateRoomSecurityCheckerWithSupportBadgeAndAllowedTimeFrom10To15();
            var isBadgeAllowed = roomMonitor.IsBadgeAllowed(BadgeType.Support, new TimeSpan(17, 00, 00));
            Assert.IsFalse(isBadgeAllowed);
        }

        [Test]
        public void IsBadgeAllowedRoomMonitorWithNoBadgeReturnsFalse()
        {
            var roomMonitor = RoomCreator.CreateRoomSecurityCheckerWithNoBadge();
            var isBadgeAllowed = roomMonitor.IsBadgeAllowed(BadgeType.NoBadge, new TimeSpan(11, 00, 00));
            Assert.IsFalse(isBadgeAllowed);
        }
        [Test]
        public void IsBadgeAllowed_withInappropriateTime_ThrowsArgumentException()
        {
            //Arrange
            var roomMonitor = RoomCreator.CreateRoomSecurityCheckerWithSupportBadgeAndAllowedTimeFrom10To15();
            var inappropriateTime = new TimeSpan(99, 00, 00);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => roomMonitor.IsBadgeAllowed(BadgeType.Support, inappropriateTime))
                .Message.Contains("0 to 24");
        }

        //What method _ on which condition _ does something
        [Test]
        public void IsAreaSafetyWithNoBadgeReturnsFalse()
        {
            //Arrange
            RoomSecurityChecker roomSecurityCheckerWithNoBadge = RoomCreator.CreateRoomSecurityCheckerWithNoBadge();


            //Act
            var isAreaSafety = roomSecurityCheckerWithNoBadge.IsAreaSafety(DateTime.Now.TimeOfDay,roomSecurityCheckerWithNoBadge.Cameras.FirstOrDefault());

            //Assert
            Assert.IsFalse(isAreaSafety);
        }
       [Test]
        public void IsAreaSafetyWithAllowedBadgeInAppropriateTimeReturnsTrue()
        {
            //Arrange
            var currentTime = new TimeSpan(11, 00, 00);
            RoomSecurityChecker roomSecurityCheckerWithAllowedBadgeInAppropriateTime = RoomCreator.CreateRoomSecurityCheckerWithSupportBadgeAndAllowedTimeFrom10To15();

            //Act
            var isAreaSafety = roomSecurityCheckerWithAllowedBadgeInAppropriateTime.IsAreaSafety(currentTime,
                roomSecurityCheckerWithAllowedBadgeInAppropriateTime.Cameras.First());

            //Assert
            Assert.IsTrue(isAreaSafety);
        }
        [Test]
        public void IsAreaSafetyWithAllowedBadgeInInappropriateTimeReturnsFalse()
        {
            //Arrange
            var currentTime = new TimeSpan(11, 00, 00);
            RoomSecurityChecker roomSecurityCheckerWithAllowedBadgeInAppropriateTime = RoomCreator.CreateRoomSecurityCheckerWithSupportBadgeAndAllowedTimeFrom10To15();

            //Act
            var isAreaSafety = roomSecurityCheckerWithAllowedBadgeInAppropriateTime.IsAreaSafety(currentTime,
                roomSecurityCheckerWithAllowedBadgeInAppropriateTime.Cameras.First());

            //Assert
            Assert.IsTrue(isAreaSafety);
           
        }

        [Test]
        public void IsAreaSafetyWithHasNotDetectedBagesReturnsTrue()
        {
            //Arrange
            var currentTime = new TimeSpan(13, 00, 00);

            int chanceRange = 1;
            Dictionary<BadgeType, int> badgesWithOccurancePossibility = new Dictionary<BadgeType, int>()
            {
                { BadgeType.Visitor, 0},
                {BadgeType.Support, 0},
                {BadgeType.SecurityOfficer, 0},
                {BadgeType.NoBadge, 0}
            };

            Recognizer recognizer = new Recognizer(chanceRange, badgesWithOccurancePossibility);

            Camera camera = new Camera(recognizer);
            var roomSecurityChecker = new RoomSecurityChecker();
            var roomSecurityCheckerPresenseRules = new Dictionary<BadgeType, List<AllowedTime>>{};
            roomSecurityChecker.PresenseRules = roomSecurityCheckerPresenseRules;
            roomSecurityChecker.Cameras = new List<Camera>() { camera };
            //Act
            var isAreaSafety = roomSecurityChecker.IsAreaSafety(currentTime, camera);

            //Assert
            Assert.IsTrue(isAreaSafety);

        }

        /*[Test]
        public void IsIntruderInRoomWhenCameraHasNoBadgeReturnsTrue()
        {
            //Arrange
            var anyCurrentTime = new TimeSpan(11, 00, 00);
            var detectedBages = new List<BadgeType> {BadgeType.NoBadge};
            var camera = new Camera(detectedBages);
            var roomMonitor = new RoomChecker();
            var roomMonitorPresenseRules = new Dictionary<BadgeType, List<AllowedTime>> { };
            roomMonitor.PresenseRules = roomMonitorPresenseRules;
            roomMonitor.Cameras=new List<Camera>() {camera};

            //Act
            var isIntruderInRoom = roomMonitor.IsIntruderInRoom(anyCurrentTime);

            //Assert
            Assert.IsTrue(isIntruderInRoom);
        }
        [Test]
        public void IsIntruderInRoomWhenCameraHasNotDetectedBagesReturnsFalse()
        {
            //Arrange
            var anyCurrentTime = new TimeSpan(11, 00, 00);
            var detectedBages = new List<BadgeType> {};
            var camera = new Camera(detectedBages);
            var roomMonitor = new RoomChecker();
            var roomMonitorPresenseRules = new Dictionary<BadgeType, List<AllowedTime>> { };
            roomMonitor.PresenseRules = roomMonitorPresenseRules;
            roomMonitor.Cameras = new List<Camera>() { camera };

            //Act
            var isIntruderInRoom = roomMonitor.IsIntruderInRoom(anyCurrentTime);

            //Assert
            Assert.IsFalse(isIntruderInRoom);
        }
        [Test]
        public void IsIntruderInRoomWhenCameraHasBadgeInAllowedTimeReturnsFalse()
        {
            //Arrange
            var roomMonitor = RoomCreator.CreateRoomMonitorWithSupportBadgeAndAllowedTimeFrom10To15();
            var allowedTime = new TimeSpan(11, 00, 00);

            //Act
            var isIntruderInRoom = roomMonitor.IsIntruderInRoom(allowedTime);

            //Assert
            Assert.IsFalse(isIntruderInRoom);
        }
        */
        [Test]
        public void IsIntruderInRoomWhenCameraHasBadgeInNotAllowedTimeReturnsTrue()
        {
            //Arrange
            var roomSecurityChecker = RoomCreator.CreateRoomSecurityCheckerWithSupportBadgeAndAllowedTimeFrom10To15();
            var notAllowedTime = new TimeSpan(9, 00, 00);

            //Act
            CheckerResponse isIntruderInRoom = roomSecurityChecker.IsIntruderInRoom(notAllowedTime);
            CheckerResponse checkerResponse=new CheckerResponse(new List<BadgeType>() {BadgeType.NoBadge},notAllowedTime);

            //Assert
            Assert.AreEqual(checkerResponse,isIntruderInRoom);
        }
        
    }
}
