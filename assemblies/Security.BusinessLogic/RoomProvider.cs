using System;
using Security.DataLayer;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class RoomProvider
    {
        RoomRepository _roomRepository = new RoomRepository();

        public int GetRoomIdByUiId(Guid uiId)
        {
            return _roomRepository.GetIdByUiId(uiId);
        }

        public int[] GetRoomsIdsByMonitorId(int monitorId)
        {
            return _roomRepository.GetRoomsIdsbyMonitorId(monitorId);
        }

        public int GetRoomIdbyRoomName(string roomName)
        {
            return _roomRepository.GetRoomIdByRoomName(roomName);
        }

        public RoomShortInfo GetRoomInfoById(int roomId)
        {
            return _roomRepository.GetRoomInfoById(roomId);
        }
    }
}