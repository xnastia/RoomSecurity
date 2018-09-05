using System;
using System.Collections.Generic;
using System.Linq;
using Security.Entities;
using Security.Entities.DB;

namespace Security.DataLayer.EF
{
    public class RoomRepository : IRoomRepository
    {
        public int? GetRoomIdByUiId(Guid roomId)
        {
            int id;
            using (var securityDbContext = new SecurityDbContext())
            {
                Room roomByUiId;
                try
                {
                    roomByUiId = securityDbContext.Rooms.First(room => room.UiId == roomId);
                }

                catch (Exception exception)
                {
                    throw new ArgumentNullException(exception.Message);
                }

                id = roomByUiId.Id;
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