using System;
using System.Collections.Generic;
using NUnit.Framework;
using Security.BusinessLogic;
using Security.Entities;

namespace RoomSecurity.UnitTests
{
    [TestFixture]
    class CheckerResponseTests
    {
        readonly int scannerId = 1;
        readonly DateTime checkTime = DateTime.Now;

        [Test]
        public void IntruderFound_IntrudersEmpty_ReturnsFalse()
        {
            //Arrange
            List<BadgeType> intruders = new List<BadgeType>();
            CheckerResponse checkerResponse = new CheckerResponse(scannerId, intruders, checkTime);

            //Act
            bool response = checkerResponse.IntruderFound;

            //Assert
            Assert.IsFalse(response);
        }

        [Test]
        public void IntruderFound_IntrudersNotEmpty_ReturnsFalse()
        {
            //Arrange
            List<BadgeType> intruders = new List<BadgeType>() {BadgeType.NoBadge};
            CheckerResponse checkerResponse = new CheckerResponse(scannerId, intruders, checkTime);

            //Act
            bool response = checkerResponse.IntruderFound;

            //Assert
            Assert.IsTrue(response);
        }
    }
}
