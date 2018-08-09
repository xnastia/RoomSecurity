using System.Configuration;
using System.Data.SqlClient;

namespace Security.DataLayer
{
    public class AlarmStatusRepository
    {
        // ToDo: fix indexation
        private string _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

        public void InsertAlarmStatus(string roomName, string statusTime, string intruderBadges)
        {
            string addAlarmStatusSqlExpression = 
                "INSERT INTO AlarmStatuses (RoomName, CurrentTime, IntruderBadges) " +
                "VALUES (@roomName, @statusTime, @intruderBadges)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(addAlarmStatusSqlExpression, connection);
                SqlParameter roomNameParameter = new SqlParameter("@roomName", roomName);
                SqlParameter statusTimeParameter = new SqlParameter("@statusTime", statusTime);
                SqlParameter intruderBadgesParameter = new SqlParameter("@intruderBadges", intruderBadges);
                command.Parameters.Add(roomNameParameter);
                command.Parameters.Add(statusTimeParameter);
                command.Parameters.Add(intruderBadgesParameter);
                command.ExecuteNonQuery();
            }
        }
    }
}
