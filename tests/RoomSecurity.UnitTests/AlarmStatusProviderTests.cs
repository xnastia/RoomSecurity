using System;
using System.Collections.Generic;
using NUnit.Framework;
using Security.BusinessLogic;

namespace RoomSecurity.UnitTests
{
    [TestFixture]
    public class AlarmStatusProviderTests
    {
        [Test]
        public void InsertAlarmStatusTest()
        {
            List<BadgeType> intruders = new List<BadgeType>() {BadgeType.NoBadge};
            TimeSpan currentTime = new TimeSpan(10,00,00);
            string roomName = "armory";
            CheckerResponse checkerResponse = new CheckerResponse(roomName, intruders, currentTime);
            AlarmStatusProvider alarmStatusProvider = new AlarmStatusProvider();
            alarmStatusProvider.InsertCheckerResponseIntoAlarmStatus(checkerResponse);
            Assert.DoesNotThrow(() => 
            alarmStatusProvider.InsertCheckerResponseIntoAlarmStatus(checkerResponse), "fuck all bad",
                null);

        }

    }
}
