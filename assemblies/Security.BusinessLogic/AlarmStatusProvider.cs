using Security.DataLayer;

namespace Security.BusinessLogic
{
    public class AlarmStatusProvider
    {
        private readonly AlarmStatusRepository alarmStatusRepository = new AlarmStatusRepository();

        public void InsertCheckerResponseIntoAlarmStatus(CheckerResponse checkerResponse)
        {
            if (checkerResponse.IntruderFound)
            {
                string roomName = checkerResponse.ScannerName;
                string statusTime = checkerResponse.CheckTime.ToString();
                string intruderBadges = checkerResponse.Intruders.ToString();

                alarmStatusRepository.InsertAlarmStatus(roomName, statusTime, intruderBadges);

            }
        }
    }
}
