using System;
using System.Collections.Generic;
using Security.Entities;
using Security.Entities.DB;

namespace Security.BusinessLogic
{
    public class RoomProvider : IRoomProvider
    {
        private readonly IRoomRepository _roomRepository;

        public RoomProvider(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public int? GetRoomIdByUiId(Guid uiId)
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