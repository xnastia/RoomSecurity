using System;
using NUnit.Framework;

namespace Security.Entities.UnitTests

{
    [TestFixture]
    public class AllowedTimeTests
    {
        private readonly AllowedTime _allowedTimeFrom10To15 =
            new AllowedTime(new TimeSpan(10, 0, 0), new TimeSpan(15, 0, 0));

        private readonly AllowedTime _allowedTimeFrom20To6 =
            new AllowedTime(new TimeSpan(20, 0, 0), new TimeSpan(6, 0, 0));

        [Test]
        public void AllowedTime_WithEndTimeOver24Hours_ThrowsArgumetException()
        {
            //Arrange
            var anyStartTime = new TimeSpan(6, 0, 0);
            var endTimeOver24Hours = new TimeSpan(25, 0, 0);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new AllowedTime(anyStartTime, endTimeOver24Hours));
        }


        [Test]
        public void AllowedTime_WithStartTimeOver24Hours_ThrowsArgumetException()
        {
            //Arrange
            var startTimeOver24Hours = new TimeSpan(25, 0, 0);
            var anyEndTime = new TimeSpan(6, 0, 0);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new AllowedTime(startTimeOver24Hours, anyEndTime));
        }

        [Test]
        public void IsTimeAllowed_At10AllowedTimeIsFrom20To6_ReturnsFalse()
        {
            //Arrange
            var currentTime = new TimeSpan(10, 0, 0);

            //Act
            var isTimeAllowed = _allowedTimeFrom20To6.IsTimeAllowed(currentTime);

            //Assert
            Assert.IsFalse(isTimeAllowed);
        }

        [Test]
        public void IsTimeAllowed_At11AllowedTimeIsFrom10To15_ReturnsTrue()
        {
            //Arrange
            var currentTime = new TimeSpan(11, 0, 0);

            //Act
            var isTimeAllowed = _allowedTimeFrom10To15.IsTimeAllowed(currentTime);

            //Assert
            Assert.IsTrue(isTimeAllowed);
        }

        [Test]
        public void IsTimeAllowed_At18AllowedTimeIsFrom10To15_ReturnsFalse()
        {
            //Arrange
            var currentTime = new TimeSpan(18, 0, 0);

            //Act
            var isTimeAllowed = _allowedTimeFrom10To15.IsTimeAllowed(currentTime);

            //Assert
            Assert.IsFalse(isTimeAllowed);
        }

        [Test]
        public void IsTimeAllowed_At18AllowedTimeIsFrom20To6_ReturnsFalse()
        {
            //Arrange
            var currentTime = new TimeSpan(18, 0, 0);

            //Act
            var isTimeAllowed = _allowedTimeFrom20To6.IsTimeAllowed(currentTime);

            //Assert
            Assert.IsFalse(isTimeAllowed);
        }

        [Test]
        public void IsTimeAllowed_At23AllowedTimeIsFrom20To6_ReturnsTrue()
        {
            //Arrange
            var currentTime = new TimeSpan(23, 0, 0);

            //Act
            var isTimeAllowed = _allowedTimeFrom20To6.IsTimeAllowed(currentTime);

            //Assert
            Assert.IsTrue(isTimeAllowed);
        }

        [Test]
        public void IsTimeAllowed_At2AllowedTimeIsFrom20To6_ReturnsTrue()
        {
            //Arrange
            var currentTime = new TimeSpan(2, 0, 0);

            //Act
            var isTimeAllowed = _allowedTimeFrom20To6.IsTimeAllowed(currentTime);

            //Assert
            Assert.IsTrue(isTimeAllowed);
        }

        [Test]
        public void IsTimeAllowed_WithCurrentTimeOver24_ThrowsArgumentNullException()
        {
            //Arrange
            var currentTime = new TimeSpan(25, 0, 0);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => _allowedTimeFrom10To15.IsTimeAllowed(currentTime));
        }
    }
}