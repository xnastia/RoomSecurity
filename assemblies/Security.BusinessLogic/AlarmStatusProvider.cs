using System;
using System.Collections.Generic;
using System.Linq;
using Security.DataLayer;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class AlarmStatusProvider
    {
        private readonly AlarmStatusRepository _alarmStatusRepository = new AlarmStatusRepository();

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

        public List<AlarmStatus> GetAlarmStatusByRoomUiId(Guid roomId)
        {
            List<AlarmStatus> alarmStatuses = _alarmStatusRepository.AlarmStatusByRoomUiId(roomId);
            var alarmStatusesWithBadgesInString = new List<AlarmStatus>();
            List<string> timeList = alarmStatuses.Select(alarmStatus => alarmStatus.Time).Distinct().ToList();
            foreach (var time in timeList)
            {
                string intruders="";
                foreach (var alarmStatus in alarmStatuses)
                {
                    if (time.Equals(alarmStatus.Time))
                    {
                        intruders += alarmStatus.IntruderBadge + " ";
                    }
                }
                var status = new AlarmStatus() {IntruderBadge = intruders, Time = time};
                alarmStatusesWithBadgesInString.Add(status);
            }
            return alarmStatusesWithBadgesInString;
        }
    }
}