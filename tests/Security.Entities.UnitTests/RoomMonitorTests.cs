using System;
using NUnit.Framework;

namespace Security.Entities.UnitTests
{
    [TestFixture]
    public class RoomMonitorTests
    {
        //TODO: add unit tests when Room monitor is refactored
        //[Test]
        //public void End_TimerEnabled_ReturnsFalse()
        //{
        //    //Arrange
        //    var roomSecurityChecker = new SecurityScanner();
        //    var anyCurrentTime = new TimeSpan(12, 0, 0);

        //    //Act
        //    var roomMonitor = new Monitor(anyCurrentTime, roomSecurityChecker);
        //    roomMonitor.End();

        //    //Assert
        //    Assert.IsFalse(roomMonitor.TimerEnabled);
        //}

        //[Test]
        //public void RoomMonitor_WithCurrentTimeOver24Hours_ThrowsArgumentException()
        //{
        //    //Arrange
        //    var roomSecurityChecker = new SecurityScanner();
        //    var currentTime = new TimeSpan(25, 0, 0);

        //    //Assert & Act
        //    Assert.Throws<ArgumentException>(() => new Monitor(currentTime, roomSecurityChecker));
        //}

        //[Test]
        //public void RoomMonitor_WithNullRoomChecker_ThrowsNullArgumentException()
        //{
        //    //Arrange
        //    SecurityScanner securityScanner = null;
        //    var anyCurrentTime = new TimeSpan(2, 0, 0);

        //    //Assert & Act
        //    Assert.Throws<ArgumentNullException>(() => new Monitor(anyCurrentTime, securityScanner));
        //}

        //[Test]
        //public void Start_TimerEnabled_ReturnsTrue()
        //{
        //    //Arrange
        //    var roomSecurityChecker = new SecurityScanner();
        //    var anyCurrentTime = new TimeSpan(12, 0, 0);

        //    //Act
        //    var roomMonitor = new Monitor(anyCurrentTime, roomSecurityChecker);
        //    roomMonitor.Start();

        //    //Assert
        //    Assert.IsTrue(roomMonitor.TimerEnabled);
        //}
    }
}