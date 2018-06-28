using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Security.Entities.UnitTests
{
    [TestFixture]
    public class CheckerResponseTests
    {
        [Test]
        public void CheckerResponse_WithCheckTimeOver24Hours_ThrowsArgumentException()
        {
            // Arrange
            var intruders = new List<BadgeType> {BadgeType.NoBadge};
            var checkTime = new TimeSpan(25, 0, 0);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new CheckerResponse(intruders, checkTime));
        }

        [Test]
        public void IntruderFound_EptyIntrudersList_ReturnsFalse()
        {
            // Arrange
            var intruders = new List<BadgeType>();
            var checkTime = new TimeSpan(20, 0, 0);
            var checkerResponse = new CheckerResponse(intruders, checkTime);

            // Act & Assert
            Assert.IsFalse(checkerResponse.IntruderFound);
        }

        [Test]
        public void IntruderFound_IntrudersListIsNull_ReturnsFalse()
        {
            // Arrange
            List<BadgeType> intruders = null;
            var checkTime = new TimeSpan(20, 0, 0);
            var checkerResponse = new CheckerResponse(intruders, checkTime);

            // Act & Assert
            Assert.IsFalse(checkerResponse.IntruderFound);
        }

        [Test]
        public void IntruderFound_NotEptyListIntruders_ReturnsTrue()
        {
            // Arrange
            var intruders = new List<BadgeType> {BadgeType.Visitor, BadgeType.NoBadge};
            var checkTime = new TimeSpan(20, 0, 0);
            var checkerResponse = new CheckerResponse(intruders, checkTime);

            // Act & Assert
            Assert.IsTrue(checkerResponse.IntruderFound);
        }
    }
}