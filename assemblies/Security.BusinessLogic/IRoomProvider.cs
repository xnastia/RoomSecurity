using System;
using System.Collections.Generic;
using Security.Entities;

namespace Security.BusinessLogic
{
    public interface IRoomProvider
    {
        int? GetRoomIdByUiId(Guid uiId);
        List<int> GetRoomsIdsByMonitorId(int monitorId);
        RoomShortInfo GetRoomInfoById(int roomId);
    }
}