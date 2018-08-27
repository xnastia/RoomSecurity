using System;
using System.Collections.Generic;
using System.Linq;
using Security.DataLayer.EF;
using Security.Entities;
using Security.Entities.DB;

namespace Security.BusinessLogic
{
    public class AlarmStatusProvider
    {
        private readonly IAlarmStatusRepository _alarmStatusRepository;

        public AlarmStatusProvider(IAlarmStatusRepository alarmStatusRepository)
        {
            _alarmStatusRepository = alarmStatusRepository;
        }

        public AlarmStatusProvider()
        {
            _alarmStatusRepository = new AlarmStatusRepository();
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

        public List<Entities.AlarmStatus> GetAlarmStatusByRoomUiId(Guid roomId)
        {
            var alarmStatuses = _alarmStatusRepository.AlarmStatusByRoomUiId(roomId);
            var alarmStatusesWithBadgesInString = new List<Entities.AlarmStatus>();
            var timeList = alarmStatuses.Select(alarmStatus => alarmStatus.Time).Distinct().ToList();
            foreach (var time in timeList)
            {
                var intruders = "";
                foreach (var alarmStatus in alarmStatuses)
                    if (time.Equals(alarmStatus.Time))
                        intruders += alarmStatus.IntruderBadge + " ";
                var status = new Entities.AlarmStatus {IntruderBadge = intruders, Time = time};
                alarmStatusesWithBadgesInString.Add(status);
            }
            return alarmStatusesWithBadgesInString;
        }
    }
}