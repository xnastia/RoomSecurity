using System;
using NUnit.Framework;
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
