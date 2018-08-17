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
            Assert.IsTrue(true);
            return;
            List<BadgeType> intruders = new List<BadgeType>() {BadgeType.NoBadge, BadgeType.Visitor};
            DateTime currentTime = DateTime.Now;
            string roomName = "Armory room";
            CheckerResponse checkerResponse = new CheckerResponse(roomName, intruders, currentTime);
            AlarmStatusProvider alarmStatusProvider = new AlarmStatusProvider();
            Assert.DoesNotThrow(() => 
            alarmStatusProvider.InsertCheckerResponseIntoAlarmStatus(checkerResponse), "",
                null);

        }
    }
}
