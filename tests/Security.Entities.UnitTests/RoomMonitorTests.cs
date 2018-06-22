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
            public static RoomChecker CreateRoomMonitorWithSupportBadgeAndAllowedTimeFrom10To15()
            {
                var allowedTimesFrom10To15 = new List<AllowedTime>
                {
                    new AllowedTime(new TimeSpan(10, 00, 00), new TimeSpan(15, 00, 00))
                };
                var presenseRules = new Dictionary<BadgeType, List<AllowedTime>>
                {
                    {
                        BadgeType.Support,
                        allowedTimesFrom10To15
                    }
                };

                var detectedSupportBage = new List<BadgeType>
                {
                    BadgeType.Support
                };

                var cameraWithOnlyOneSupport = new Camera(detectedSupportBage);

                var roomMonitor = new RoomChecker
                {
                    PresenseRules = presenseRules,
                    Cameras = new List<Camera>
                    {
                        cameraWithOnlyOneSupport
                    }
                };

                return roomMonitor;
            }

            public static RoomChecker CreateRoomMonitorWithNoBadge()
            {
                var presentRules = new Dictionary<BadgeType, List<AllowedTime>>();
                
                presentRules.Add(BadgeType.NoBadge, new List<AllowedTime>());

                var camera = new Camera(new List<BadgeType>
                {
                    BadgeType.NoBadge,
                });

                var roomMonitor = new RoomChecker
                {
                    PresenseRules = presentRules,
                    Cameras = new List<Camera>
                    {
                        camera
                    }
                };
                return roomMonitor;
            }
        }
       
        [Test]
        public void IsBadgeAllowedRoomMonitorWithSupportBadgeAndAllowedTimeFrom10To15On13ReturnsTrue()
        {
            var roomMonitor = RoomCreator.CreateRoomMonitorWithSupportBadgeAndAllowedTimeFrom10To15();
            var isBadgeAllowed = roomMonitor.IsBadgeAllowed(BadgeType.Support, new TimeSpan(13, 00, 00));
            Assert.IsTrue(isBadgeAllowed);
        }
        [Test]
        public void IsBadgeAllowedRoomMonitorWithSupportBadgeAndAllowedTimeFrom10To15On17ReturnsFalse()
        {
            var roomMonitor = RoomCreator.CreateRoomMonitorWithSupportBadgeAndAllowedTimeFrom10To15();
            var isBadgeAllowed = roomMonitor.IsBadgeAllowed(BadgeType.Support, new TimeSpan(17, 00, 00));
            Assert.IsFalse(isBadgeAllowed);
        }

        [Test]
        public void IsBadgeAllowedRoomMonitorWithNoBadgeReturnsFalse()
        {
            var roomMonitor = RoomCreator.CreateRoomMonitorWithNoBadge();
            var isBadgeAllowed = roomMonitor.IsBadgeAllowed(BadgeType.NoBadge, new TimeSpan(11, 00, 00));
            Assert.IsFalse(isBadgeAllowed);
        }
        [Test]
        public void IsBadgeAllowed_withInappropriateTime_ThrowsArgumentException()
        {
            //Arrange
            var roomMonitor = RoomCreator.CreateRoomMonitorWithSupportBadgeAndAllowedTimeFrom10To15();
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
            var currentTime = new TimeSpan(11, 00, 00);
            var detectedBages = new List<BadgeType>
            {
                BadgeType.Visitor,
                BadgeType.NoBadge
            };
            var camera = new Camera(detectedBages);
            var roomMonitor = new RoomChecker();
            var roomMonitorPresenseRules = new Dictionary<BadgeType, List<AllowedTime>>
            {
                {
                    BadgeType.Visitor,
                    new List<AllowedTime>
                    {
                        new AllowedTime(new TimeSpan(09, 00, 00), new TimeSpan(11, 00, 00))
                    }
                }
            };
            roomMonitor.PresenseRules = roomMonitorPresenseRules;

            //Act
            var isAreaSafety = roomMonitor.IsAreaSafety(currentTime, camera);

            //Assert
            Assert.IsFalse(isAreaSafety);
        }
        [Test]
        public void IsAreaSafetyWithAllowedBadgeInAppropriateTimeReturnsTrue()
        {
            //Arrange
            var currentTime = new TimeSpan(11, 00, 00);
            var detectedBages = new List<BadgeType>
            {
                BadgeType.Visitor
            };
            var camera = new Camera(detectedBages);
            var roomMonitor = new RoomChecker();
            var roomMonitorPresenseRules = new Dictionary<BadgeType, List<AllowedTime>>
            {
                {
                    BadgeType.Visitor,
                    new List<AllowedTime>
                    {
                        new AllowedTime(new TimeSpan(09, 00, 00), new TimeSpan(11, 00, 00))
                    }
                }
            };
            roomMonitor.PresenseRules = roomMonitorPresenseRules;
            //Act
            var isAreaSafety = roomMonitor.IsAreaSafety(currentTime, camera);

            //Assert
            Assert.IsTrue(isAreaSafety);
        }
        [Test]
        public void IsAreaSafetyWithAllowedBadgeInInappropriateTimeReturnsFalse()
        {
            //Arrange
            var currentTime = new TimeSpan(13, 00, 00);
            var detectedBages = new List<BadgeType>
            {
                BadgeType.Visitor
            };
            var camera = new Camera(detectedBages);
            var roomMonitor = new RoomChecker();
            var roomMonitorPresenseRules = new Dictionary<BadgeType, List<AllowedTime>>
            {
                {
                    BadgeType.Visitor,
                    new List<AllowedTime>
                    {
                        new AllowedTime(new TimeSpan(09, 00, 00), new TimeSpan(11, 00, 00))
                    }
                }
            };
            roomMonitor.PresenseRules = roomMonitorPresenseRules;
           //Act
            var  isAreaSafety = roomMonitor.IsAreaSafety(currentTime, camera);

            //Assert
            Assert.IsFalse(isAreaSafety);
        }

        [Test]
        public void IsAreaSafetyWithHasNotDetectedBagesReturnsTrue()
        {
            //Arrange
            var currentTime = new TimeSpan(13, 00, 00);
            var detectedBages = new List<BadgeType>{};
            var camera = new Camera(detectedBages);
            var roomMonitor = new RoomChecker();
            var roomMonitorPresenseRules = new Dictionary<BadgeType, List<AllowedTime>>{};
            roomMonitor.PresenseRules = roomMonitorPresenseRules;
            roomMonitor.Cameras = new List<Camera>() { camera };
            //Act
            var isAreaSafety = roomMonitor.IsAreaSafety(currentTime, camera);

            //Assert
            Assert.IsTrue(isAreaSafety);

        }

        [Test]
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

        [Test]
        public void IsIntruderInRoomWhenCameraHasBadgeInNotAllowedTimeReturnsTrue()
        {
            //Arrange
            var roomMonitor = RoomCreator.CreateRoomMonitorWithSupportBadgeAndAllowedTimeFrom10To15();
            var notAllowedTime = new TimeSpan(9, 00, 00);

            //Act
            var isIntruderInRoom = roomMonitor.IsIntruderInRoom(notAllowedTime);

            //Assert
            Assert.IsTrue(isIntruderInRoom);
        }
        
    }
}
