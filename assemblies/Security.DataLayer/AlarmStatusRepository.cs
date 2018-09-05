using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Security.Entities.DB;

namespace Security.DataLayer
{
    public class AlarmStatusRepository : IAlarmStatusRepository
    {
        private readonly IRoomRepository _roomRepository;
        // ToDo: fix indexation
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

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
            var addAlarmStatusSqlExpression =
                "sp_InsertAlarmStatus";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(addAlarmStatusSqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var roomNameParameter = new SqlParameter("@roomId", roomId);
                var statusTimeParameter = new SqlParameter("@statusTime", statusTime);
                var intruderBadgeParameter = new SqlParameter("@intruderId", intruderId);
                command.Parameters.Add(roomNameParameter);
                command.Parameters.Add(statusTimeParameter);
                command.Parameters.Add(intruderBadgeParameter);
                command.ExecuteNonQuery();
            }
        }

        public List<Entities.AlarmStatus> AlarmStatusByRoomUiId(Guid roomId)
        {
            var AlarmStatusByRoomSqlExpression = "sp_AlarmStatusByRoomUiId";
            var statuses = new List<Entities.AlarmStatus>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(AlarmStatusByRoomSqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var roomNameParameter = new SqlParameter("@id", roomId);
                command.Parameters.Add(roomNameParameter);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var status = new Entities.AlarmStatus
                        {
                            Time = (reader.GetDateTime(0)).ToString("g"),
                            IntruderBadge = reader.GetString(1)
                        };
                        statuses.Add(status);
                    }
                }
            }

            return statuses;
        }
    }
}