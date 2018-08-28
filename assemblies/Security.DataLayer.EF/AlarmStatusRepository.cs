using System;
using System.Collections.Generic;
using System.Linq;
using Security.Entities;
using Security.Entities.DB;

namespace Security.DataLayer.EF
{
    public class AlarmStatusRepository : IAlarmStatusRepository
    {
        private readonly IRoomRepository _roomRepository;

        public AlarmStatusRepository(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public AlarmStatusRepository()
        {
            _roomRepository = new RoomRepository();
        }

        public void InsertAlarmStatus(int roomId, DateTime statusTime, int intruderId)
        {
            var alarmStatus = new AlarmStatus {RoomId = roomId, Time = statusTime, BadgeId = intruderId};
            using (var securityDbContext = new SecurityDbContext())
            {
                securityDbContext.AlarmStatuses.Add(alarmStatus);
            }
        }

        public List<Entities.AlarmStatus> AlarmStatusByRoomUiId(Guid roomUiId)
        {
            var alarmStatusesEntities = new List<Entities.AlarmStatus>();
            using (var securityDbContext = new SecurityDbContext())
            {
                var roomId = _roomRepository.GetRoomIdByUiId(roomUiId);
                var alarmStatuses = securityDbContext.AlarmStatuses
                    .Where(alarmStatus => alarmStatus.RoomId == roomId)
                    .Select(alarmStatus => new {alarmStatus.Time, alarmStatus.BadgeId});
                    /*.OrderByDescending(alarmStatus => alarmStatus.Time)
                    .Skip((page - 1) * pageSize).Take(pageSize).ToList();*/
                foreach (var alarmStatus in alarmStatuses)
                {
                    var alarmStatusEntities = new Entities.AlarmStatus()
                    {
                        IntruderBadge = ((BadgeType)alarmStatus.BadgeId).ToString(),
                        Time = alarmStatus.Time.ToString("g")
                    };
                    alarmStatusesEntities.Add(alarmStatusEntities);
                }
            }
            return alarmStatusesEntities;
        }
    }
}