using System;
using System.Collections.Generic;

namespace Security.Entities.DB
{
    public interface IRoomRepository
    {
        int GetRoomIdByUiId(Guid uiId);
        RoomShortInfo GetRoomInfoById(int roomId);
        List<int> GetRoomsIdsbyMonitorId(int monitorId);
    }
}
