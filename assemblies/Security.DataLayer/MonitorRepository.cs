using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Security.Entities;
using Security.Entities.DB;

namespace Security.DataLayer
{
    public class MonitorRepository : IMonitorRepository
    {
        private readonly string _connectionString = ConfigurationManager
            .ConnectionStrings["DBConnection"].ConnectionString;
        public int? GetMonitorIdByUiId(Guid uiId)
        {
            int? id;
            var getMonitorIdByUiId = "sp_GetMonitorIdByUiId";
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(getMonitorIdByUiId, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var uiIdParameter = new SqlParameter("@uiId", uiId);
                command.Parameters.Add(uiIdParameter);
                try
                {
                    connection.Open();
                    id = (int)command.ExecuteScalar();
                }

                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }

            return id;
        }

        public List<MonitorTab> GeMonitorTabs()
        {
            var getMonitorTabs = "sp_GeMonitorTabs";

            SqlDataReader reader = null;
            var monitorTabs = new List<MonitorTab>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(getMonitorTabs, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var monitorTab = new MonitorTab
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1)
                    };
                    monitorTabs.Add(monitorTab);
                }
            }
            reader.Close();
            return monitorTabs;
        }
    }
}