using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Security.BusinessLogic;
using Rhino.Mocks;
using Security.DataLayer;

namespace RoomSecurity.UnitTests
{
    [TestFixture]
    class RoomRepoitoryTests
    {
        RoomRepository roomRepository = new RoomRepository();
        [Test]
        public void GetRoomIdByUiId_UnknownUiId_ReturnsNull()
        {
            //Arrange
            Guid uiId = default(Guid);

            //Act
            var roomId = roomRepository.GetRoomIdByUiId(uiId);

            //Assert
            Assert.Null(roomId);
        }
    }
}
