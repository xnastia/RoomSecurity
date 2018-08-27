using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Security.Entities;
using Security.Entities.DB;

namespace Security.DataLayer
{
    public class PresenceRulesRepository : IPresenceRulesRepository
    {
        private readonly string _connectionString 
            = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        public List<PresenceRule> GetPresenceRulesByRoomId(int roomId)
        {
            var getPresenceRules = "SELECT BadgeId, StartTime, EndTime from PresenceRules WHERE RoomId=@roomId";

            SqlDataReader reader = null;
            List<PresenceRule> presenceRules = new List<PresenceRule>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(getPresenceRules, connection);
                var roomIdParameter = new SqlParameter("@roomId", roomId);
                command.Parameters.Add(roomIdParameter);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int badgeId = reader.GetInt32(0);
                    TimeSpan startTime = reader.GetTimeSpan(1);
                    TimeSpan endTime = reader.GetTimeSpan(2);
                    var presenceRule = new PresenceRule(badgeId, startTime, endTime);
                    
                    presenceRules.Add(presenceRule);
                }
            }
            reader.Close();
            return presenceRules;
        }

    }
}
