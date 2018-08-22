using System;
using System.Collections.Generic;
using Security.DataLayer;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class RoomProvider
    {
        RoomRepository _roomRepository = new RoomRepository();

        public int GetRoomIdByUiId(Guid uiId)
        {
            return _roomRepository.GetRoomIdByUiId(uiId);
        }

        public List<int> GetRoomsIdsByMonitorId(int monitorId)
        {
            return _roomRepository.GetRoomsIdsbyMonitorId(monitorId);
        }
        
        public RoomShortInfo GetRoomInfoById(int roomId)
        {
            return _roomRepository.GetRoomInfoById(roomId);
        }
    }
}