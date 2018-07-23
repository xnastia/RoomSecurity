using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;

namespace Security.Entities.UnitTests
{
    [TestFixture]
    public class RoomSecurityCheckerTests
    {
        private class RoomCreator
        {
            public static SecurityScanner CreateRoomSecurityCheckerWithSupportBadgeAndAllowedTimeFrom10To15()
            {
                var recognizer = MockRepository.GenerateStub<IRecognizer>();
                recognizer.Stub(x => x.IdentifyBadges(Arg<byte[]>.Is.Anything)).Return(new List<BadgeType>
                {
                    BadgeType.Support
                });

                var cameras = new List<Camera>
                {
                    new Camera() 
                };

                var presenseRules = new Dictionary<BadgeType, List<AllowedTime>>
                {
                    {
                        BadgeType.Support, new List<AllowedTime>
                        {
                            new AllowedTime(new TimeSpan(10, 0, 0), new TimeSpan(15, 0, 0))
                        }
                    }
                };

                var securityChecker = new SecurityScanner(presenseRules, recognizer, cameras);
                return securityChecker;
            }

            public static SecurityScanner CreateRoomSecurityCheckerWithNoBadge()
            {
                var recognizer = MockRepository.GenerateStub<IRecognizer>();
                recognizer.Stub(x => x.IdentifyBadges(Arg<byte[]>.Is.Anything)).Return(new List<BadgeType>
                {
                    BadgeType.NoBadge
                });

                var cameras = new List<Camera>
                {
                    new Camera()
                };

                var presenseRules = new Dictionary<BadgeType, List<AllowedTime>>
                {
                    {
                        BadgeType.Support, new List<AllowedTime>
                        {
                            new AllowedTime(new TimeSpan(10, 0, 0), new TimeSpan(15, 0, 0))
                        }
                    }
                };

                var securityChecker = new SecurityScanner(presenseRules, recognizer, cameras);
                return securityChecker;
            }

            public static SecurityScanner CreateRoomSecurityCheckerWithNoBadges()
            {
                var recognizer = MockRepository.GenerateStub<IRecognizer>();
                recognizer.Stub(x => x.IdentifyBadges(Arg<byte[]>.Is.Anything)).Return(new List<BadgeType>());

                var cameras = new List<Camera>
                {
                    new Camera()
                };

                var presenseRules = new Dictionary<BadgeType, List<AllowedTime>>
                {
                    {
                        BadgeType.Support, new List<AllowedTime>
                        {
                            new AllowedTime(new TimeSpan(10, 0, 0), new TimeSpan(15, 0, 0))
                        }
                    }
                };

                var securityChecker = new SecurityScanner(presenseRules, recognizer, cameras);
                return securityChecker;
            }
        }

        [Test]
        public void IsBadgeAllowed_RoomMonitorWithNoBadge_ReturnsFalse()
        {
            //Arrange
            var roomCreator = RoomCreator.CreateRoomSecurityCheckerWithNoBadge();

            //Act
            var isBadgeAllowed = roomCreator.IsBadgeAllowed(BadgeType.NoBadge, new TimeSpan(11, 00, 00));

            //Assert
            Assert.IsFalse(isBadgeAllowed);
        }

        [Test]
        public void IsBadgeAllowed_RoomMonitorWithSupportBadgeAndAllowedTimeFrom10To15AT13_ReturnsTrue()
        {
            //Arrange
            var roomCreator = RoomCreator.CreateRoomSecurityCheckerWithSupportBadgeAndAllowedTimeFrom10To15();

            //Act
            var isBadgeAllowed = roomCreator.IsBadgeAllowed(BadgeType.Support, new TimeSpan(13, 00, 00));

            //Assert
            Assert.IsTrue(isBadgeAllowed);
        }

        [Test]
        public void IsBadgeAllowed_RoomMonitorWithSupportBadgeAndAllowedTimeFrom10To15At17_ReturnsFalse()
        {
            //Arrange
            var roomMonitor = RoomCreator.CreateRoomSecurityCheckerWithSupportBadgeAndAllowedTimeFrom10To15();

            //Act
            var isBadgeAllowed = roomMonitor.IsBadgeAllowed(BadgeType.Support, new TimeSpan(17, 00, 00));

            //Assert
            Assert.IsFalse(isBadgeAllowed);
        }

        [Test]
        public void IsBadgeAllowed_withInappropriateTime_ThrowsArgumentException()
        {
            //Arrange
            var roomMonitor = RoomCreator.CreateRoomSecurityCheckerWithSupportBadgeAndAllowedTimeFrom10To15();
            var inappropriateTime = new TimeSpan(99, 00, 00);
            var expectedMessagePart = "0 to 24";

            //Act & Assert
            var message = Assert
                .Throws<ArgumentException>(() => roomMonitor.IsBadgeAllowed(BadgeType.Support, inappropriateTime))
                .Message;
            Assert.IsTrue(message.Contains(expectedMessagePart));
        }

        [Test]
        public void IsIntruderInRoom_WhenCameraHasBadgeInAllowedTime_ReturnsFalse()
        {
            //Arrange
            var roomSecurityChecker = RoomCreator.CreateRoomSecurityCheckerWithSupportBadgeAndAllowedTimeFrom10To15();
            var allowedTime = new TimeSpan(11, 00, 00);

            //Act
            var checkerResponse = roomSecurityChecker.CheckRoom(allowedTime);

            //Assert
            Assert.IsFalse(checkerResponse.IntruderFound);
        }

        [Test]
        public void IsIntruderInRoom_WhenCameraHasBadgeInNotAllowedTime_ReturnsTrue()
        {
            //Arrange
            var roomSecurityChecker = RoomCreator.CreateRoomSecurityCheckerWithSupportBadgeAndAllowedTimeFrom10To15();
            var notAllowedTime = new TimeSpan(9, 00, 00);

            //Act
            var checkerResponse = roomSecurityChecker.CheckRoom(notAllowedTime);

            //Assert
            Assert.IsTrue(checkerResponse.IntruderFound);
        }

        //What method _ on which condition _ does something

        [Test]
        public void IsIntruderInRoom_WhenCameraHasNoBadge_ReturnsTrue()
        {
            //Arrange
            var recognizer = MockRepository.GenerateStub<IRecognizer>();
            recognizer.Stub(x => x.IdentifyBadges(Arg<byte[]>.Is.Anything)).Return(new List<BadgeType> {BadgeType.NoBadge});

            var cameras = new List<Camera>
            {
                new Camera()
            };

            var presenseRules = new Dictionary<BadgeType, List<AllowedTime>>();

            var securityChecker = new SecurityScanner(presenseRules, recognizer, cameras);


            var anyCurrentTime = DateTime.Now.TimeOfDay;

            //Act
            var roomCheck = securityChecker.CheckRoom(anyCurrentTime);

            //Assert
            Assert.IsTrue(roomCheck.IntruderFound);
        }

        [Test]
        public void IsIntruderInRoom_WhenCameraHasNotDetectedBages_ReturnsFalse()
        {
            //Arrange
            var roomSecurityCheckerHasNotDetectedBadges = RoomCreator.CreateRoomSecurityCheckerWithNoBadges();
            var anyCurrentTime = DateTime.Now.TimeOfDay;

            //Act
            var checkerResponse = roomSecurityCheckerHasNotDetectedBadges.CheckRoom(anyCurrentTime);

            //Assert
            Assert.IsFalse(checkerResponse.IntruderFound);
        }
    }
}