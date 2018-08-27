using System;
using System.Collections.Generic;
using System.Linq;
using Security.Entities;
using Security.Entities.DB;

namespace Security.DataLayer.EF
{
    public class RoomRepository : IRoomRepository
    {
        public int GetRoomIdByUiId(Guid roomId)
        {
            int id;
            using (var securityDbContext = new SecurityDbContext())
            {
                id = securityDbContext.Rooms.Single(room => room.UiId == roomId).Id;
            }
            return id;
        }

        public RoomShortInfo GetRoomInfoById(int roomId)
        {
            RoomShortInfo roomShortInfo = new RoomShortInfo();
            using (var securityDbContext = new SecurityDbContext())
            {
                var room = securityDbContext.Rooms.Single(x => x.Id == roomId);
                roomShortInfo = new RoomShortInfo {Name = room.Name, UiId = room.UiId};
            }
            return roomShortInfo;
        }

        public int GetRoomIdByRoomName(string roomName)
        {
            int id;
            using (var securityDbContext = new SecurityDbContext())
            {
                id = securityDbContext.Rooms.Single(room => room.Name == roomName).Id;
            }
            return id;
        }

        public List<int> GetRoomsIdsbyMonitorId(int monitorId)
        {
            List<int> ids = new List<int>();
            using (var securityDbContext = new SecurityDbContext())
            {
                ids = securityDbContext.Rooms.Where(room => room.MonitorId == monitorId)
                    .Select(room => room.Id).ToList();
            }
            return ids;
        }
    }
}