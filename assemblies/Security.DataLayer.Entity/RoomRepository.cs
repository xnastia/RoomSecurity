using System;
using System.Collections.Generic;
using System.Linq;
using Security.Entities;
using Security.Entities.DB;

namespace Security.DataLayer.Entity
{
    public class RoomRepository : IRoomRepository
    {
        private readonly SecurityDbContext _securityDbContext = new SecurityDbContext();

        public int GetRoomIdByUiId(Guid roomId)
        {
            return _securityDbContext.Rooms.Single(room => room.UiId == roomId).Id;
        }

        public RoomShortInfo GetRoomInfoById(int roomId)
        {
            var room = _securityDbContext.Rooms.Single(x => x.Id == roomId);
            var roomShortInfo = new RoomShortInfo {Name = room.Name, UiId = room.UiId};
            return roomShortInfo;
        }

        public int GetRoomIdByRoomName(string roomName)
        {
            return _securityDbContext.Rooms.Single(room => room.Name == roomName).Id;
        }

        public List<int> GetRoomsIdsbyMonitorId(int monitorId)
        {
            return _securityDbContext.Rooms.Where(room => room.MonitorId == monitorId)
                .Select(room => room.Id)
                .ToList();
        }
    }
}