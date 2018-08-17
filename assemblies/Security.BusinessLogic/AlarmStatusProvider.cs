using System.Collections.Generic;
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
                var intruders = "";
                foreach (var inruderBadge in intruderBadges)
                    intruders = inruderBadge + " ";

                _alarmStatusRepository.InsertAlarmStatus(roomName, statusTime, intruders);
            }
        }

        public List<AlarmStatus> GetAlarmStatusByRoomName(string roomName)
        {
            return _alarmStatusRepository.AlarmStatusByRoomName(roomName);
        }
    }
}