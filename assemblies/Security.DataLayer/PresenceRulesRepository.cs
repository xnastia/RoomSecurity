using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Security.Entities;

namespace Security.DataLayer
{
    public class PresenceRulesRepository
    {
        private readonly string _connectionString 
            = ConfigurationManager.ConnectionStrings[1].ConnectionString;

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
                    var presenceRule = new PresenceRule()
                    {
                        BadgeType = (BadgeType)reader.GetInt32(0),
                        AllowedTime = new AllowedTime(reader.GetTimeSpan(1),
                            reader.GetTimeSpan(2))
                    };
                    presenceRules.Add(presenceRule);
                }
            }
            reader.Close();
            return presenceRules;
        }

    }
}
