using System;
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

        public void InsertAlarmStatus(string roomName, string statusTime, string intruderBadges)
        {
            var addAlarmStatusSqlExpression =
                "INSERT INTO AlarmStatus (RoomName, CurrentTime, IntruderBadges) " +
                "VALUES (@roomName, @statusTime, @intruderBadges)";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(addAlarmStatusSqlExpression, connection);
                var roomNameParameter = new SqlParameter("@roomName", roomName);
                var statusTimeParameter = new SqlParameter("@statusTime", statusTime);
                var intruderBadgesParameter = new SqlParameter("@intruderBadges", intruderBadges);
                command.Parameters.Add(roomNameParameter);
                command.Parameters.Add(statusTimeParameter);
                command.Parameters.Add(intruderBadgesParameter);
                command.ExecuteNonQuery();
            }
        }

       /* public int GetRowsNumber()
        {
            int rowsNumber=0;
            var currentRowsNumder = "Select MAX(Id) from AlarmStatus";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(currentRowsNumder, connection);

                try
                {
                    rowsNumber = (int) command.ExecuteScalar();
                }
                catch
                {
                }
            }
            return rowsNumber;
        }

        public void ResetId()
        {
            var resetId = "DBCC CHECKIDENT (AlarmStatus, RESEED, 0)";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(resetId, connection);
                command.ExecuteNonQuery();
            }
        }

        public void CutAlarmStatuses(int maxRowsNumber)
        {
            int rowsNumber = GetRowsNumber();
            string deleteExtraAlarmStatusData="";
            if (maxRowsNumber >= rowsNumber)
            {
                deleteExtraAlarmStatusData = "Delete from AlarmStatus where Id<@maxRowsNumber";
                ResetId();
            }
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(deleteExtraAlarmStatusData, connection);
                command.ExecuteNonQuery();
            }
        }*/

        public List<AlarmStatus> AlarmStatusByRoomName(string roomName)
        {
            var AlarmStatusByRoomSqlExpression =
                "SELECT CurrentTime, IntruderBadges FROM AlarmStatus WHERE RoomName=@roomName";

            SqlDataReader reader = null;
            var statuses = new List<AlarmStatus>();
            var status = new AlarmStatus();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(AlarmStatusByRoomSqlExpression, connection);
                var roomNameParameter = new SqlParameter("@roomName", roomName);
                command.Parameters.Add(roomNameParameter);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    status.Time = reader.GetString(0);
                    status.IntruderBadge = reader.GetString(1);
                    statuses.Add(status);
                }
            }
            reader.Close();
            return statuses;
        }
    }
}