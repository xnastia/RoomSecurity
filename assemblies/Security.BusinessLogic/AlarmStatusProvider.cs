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
                var roomName = checkerResponse.ScannerName;
                var statusTime = checkerResponse.CheckTime.ToString();
                var intruderBadges = checkerResponse.Intruders;
                foreach (var inruderBadge in intruderBadges)
                    _alarmStatusRepository.InsertAlarmStatus(roomName, statusTime, inruderBadge.ToString());
            }
        }

        public List<AlarmStatus> GetAlarmStatusByRoomName(string roomName)
        {
            List<AlarmStatus> alarmStatuses = _alarmStatusRepository.AlarmStatusByRoomName(roomName);
            var alarmStatusesWithBadgesInString = new List<AlarmStatus>();
            List<string> timeList = alarmStatuses.Select(alarmStatus => alarmStatus.Time).Distinct().ToList();
            foreach (var time in timeList)
            {
                string intruders="";
                foreach (var alarmStatus in alarmStatuses)
                {
                    if (time.Equals(alarmStatus.Time))
                    {
                        intruders += alarmStatus.IntruderBadge + ", ";
                    }
                }
                var status = new AlarmStatus() {IntruderBadge = intruders, Time = time};
                alarmStatusesWithBadgesInString.Add(status);
            }
            return alarmStatusesWithBadgesInString;
        }
    }
}