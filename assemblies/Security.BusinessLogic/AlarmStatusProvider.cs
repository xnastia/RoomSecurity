using System;
using System.Collections.Generic;
using System.Linq;
using Security.Entities.DB;

namespace Security.BusinessLogic
{
    public class AlarmStatusProvider : IAlarmStatusProvider
    {
        private readonly IAlarmStatusRepository _alarmStatusRepository;

        public AlarmStatusProvider(IAlarmStatusRepository alarmStatusRepository)
        {
            _alarmStatusRepository = alarmStatusRepository;
        }

        public void InsertCheckerResponseIntoAlarmStatus(CheckerResponse checkerResponse)
        {
            if (checkerResponse.IntruderFound)
            {
                var roomId = checkerResponse.ScannerId;
                var statusTime = checkerResponse.CheckTime;
                var intruderBadges = checkerResponse.Intruders;
                foreach (var inruderBadge in intruderBadges)
                    _alarmStatusRepository.InsertAlarmStatus(roomId, statusTime, inruderBadge.GetHashCode());
            }
        }

        public List<Entities.AlarmStatus> GetAlarmStatusByRoomUiId(Guid roomId, int page = 1, int pageSize = 4)
        {
            var alarmStatuses = _alarmStatusRepository.AlarmStatusByRoomUiId(roomId);
            var alarmStatusesPaged = alarmStatuses.OrderByDescending(alarmStatus => alarmStatus.Time)
                .Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return alarmStatusesPaged;
        }

        public int CountAlarmStatuses(Guid roomId)
        {
            var alarmStatuses = _alarmStatusRepository.AlarmStatusByRoomUiId(roomId);
            return alarmStatuses.Count();
        }
    }
}