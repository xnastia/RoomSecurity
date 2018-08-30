using System;
using System.Collections.Generic;
using Security.Entities;

namespace Security.BusinessLogic
{
    public interface IAlarmStatusProvider
    {
        void InsertCheckerResponseIntoAlarmStatus(CheckerResponse checkerResponse);
        List<AlarmStatus> GetAlarmStatusByRoomUiId(Guid roomId, int page = 1, int pageSize = 4);
        int CountAlarmStatuses(Guid roomId);
    }
}