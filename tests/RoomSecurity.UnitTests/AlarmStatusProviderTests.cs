using System;
using System.Collections.Generic;
using NUnit.Framework;
using Security.BusinessLogic;
using Security.Entities;

namespace RoomSecurity.UnitTests
{
    [TestFixture]
    public class AlarmStatusProviderTests
    {
        [Test]
        public void InsertAlarmStatusTest()
        {
            List<BadgeType> intruders = new List<BadgeType>() {BadgeType.NoBadge, BadgeType.Visitor};
            TimeSpan currentTime = new TimeSpan(21,00,00);
            string roomName = "Armory room";
            CheckerResponse checkerResponse = new CheckerResponse(roomName, intruders, currentTime);
            AlarmStatusProvider alarmStatusProvider = new AlarmStatusProvider();
            Assert.DoesNotThrow(() => 
            alarmStatusProvider.InsertCheckerResponseIntoAlarmStatus(checkerResponse), "",
                null);

        }

    }
}
