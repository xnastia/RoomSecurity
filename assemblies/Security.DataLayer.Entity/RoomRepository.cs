using System;
using System.Linq;
using Security.DataLayer.Entity;
using Security.Entities;

namespace Security.DataLayer
{
    public class RoomRepository
    {
        private SecurityDbContext _securityDbContext = new SecurityDbContext();

        public int GetIdByUiId(Guid roomId)
        {
            return _securityDbContext.Rooms.Single(room => room.UiId == roomId).Id;
        }

       public RoomShortInfo GetRoomInfoById(int roomId)
        {
            var room = _securityDbContext.Rooms.Single(x => x.Id == roomId);
            RoomShortInfo roomShortInfo = new RoomShortInfo() {Name = room.Name, UiId = room.UiId};
            return roomShortInfo;
        }

        public int GetRoomIdByRoomName(string roomName)
        {
            return _securityDbContext.Rooms.Single(room => room.Name == roomName).Id;
        }

        public int[] GetRoomsIdsbyMonitorId(int monitorId)
        {
            return _securityDbContext.Rooms.Where(room => room.MonitorId == monitorId)
                .Select(room => room.Id).ToArray();
        }
    }
}