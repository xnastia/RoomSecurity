using System;
using System.Collections.Generic;

namespace Security.Entities.DB
{
    public interface IAlarmStatusRepository
    {
        void InsertAlarmStatus(int roomId, DateTime statusTime, int intruderId);
        List<AlarmStatus> AlarmStatusByRoomUiId(Guid roomId, int page = 1, int pageSize = 4);
    }
}
