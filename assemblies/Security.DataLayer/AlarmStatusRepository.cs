using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Security.Entities;

namespace Security.DataLayer
{
    public class AlarmStatusRepository
    {
        // ToDo: fix indexation
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

        public void InsertAlarmStatus(int roomId, string statusTime, string intruderBadges)
        {
            var addAlarmStatusSqlExpression =
                "INSERT INTO AlarmStatus (RoomId, CurrentTime, IntruderBadges) " +
                "VALUES (@roomId, @statusTime, @intruderBadges)";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(addAlarmStatusSqlExpression, connection);
                var roomNameParameter = new SqlParameter("@roomId", roomId);
                var statusTimeParameter = new SqlParameter("@statusTime", statusTime);
                var intruderBadgesParameter = new SqlParameter("@intruderBadges", intruderBadges);
                command.Parameters.Add(roomNameParameter);
                command.Parameters.Add(statusTimeParameter);
                command.Parameters.Add(intruderBadgesParameter);
                command.ExecuteNonQuery();
            }
        }

        public List<AlarmStatus> AlarmStatusByRoomId(int roomId)
        {
            var AlarmStatusByRoomSqlExpression =
                "SELECT CurrentTime, IntruderBadges FROM AlarmStatus WHERE RoomId=@roomId";

            SqlDataReader reader = null;
            var statuses = new List<AlarmStatus>();
            
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(AlarmStatusByRoomSqlExpression, connection);
                var roomNameParameter = new SqlParameter("@roomId", roomId);
                command.Parameters.Add(roomNameParameter);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var status = new AlarmStatus
                    {
                        Time = reader.GetString(0),
                        IntruderBadge = reader.GetString(1)
                    };
                    statuses.Add(status);
                }
            }
            reader.Close();
            return statuses;
        }
    }
}