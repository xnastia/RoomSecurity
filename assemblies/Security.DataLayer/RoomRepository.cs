using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Security.Entities;
using Security.Entities.DB;

namespace Security.DataLayer
{
    public class RoomRepository : IRoomRepository
    {
        private readonly string _connectionString = ConfigurationManager
            .ConnectionStrings["DBConnection"].ConnectionString;

        public int? GetRoomIdByUiId(Guid uiId)
        {
            var getRoomIdByUiIdExpression = "sp_GetRoomIdByUiId";
            using (var connection = new SqlConnection(_connectionString))
            {
                var command =
                    new SqlCommand(getRoomIdByUiIdExpression, connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                var uiIdParameter = new SqlParameter("@uiId", uiId);
                command.Parameters.Add(uiIdParameter);
                connection.Open();
                return (int?) command.ExecuteScalar();
            }
        }

        public RoomShortInfo GetRoomInfoById(int roomId)
        {
            var roomShortInfo = new RoomShortInfo();
            var getRoomInfoById = "sp_GetRoomInfoById";
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader = null;
                var command = new SqlCommand(getRoomInfoById, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var roomIdParameter = new SqlParameter("@roomId", roomId);
                command.Parameters.Add(roomIdParameter);
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    roomShortInfo.Name = reader.GetString(0);
                    roomShortInfo.UiId = reader.GetGuid(1);
                }
                reader.Close();
            }
            return roomShortInfo;
        }

        public List<int> GetRoomsIdsbyMonitorId(int monitorId)
        {

            var ids = new List<int>();
            var getRoomsIdsByMonitorId = "sp_GetRoomsIdsbyMonitorId";
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(getRoomsIdsByMonitorId, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var uiIdParameter = new SqlParameter("@monitorId", monitorId);
                command.Parameters.Add(uiIdParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var roomId = reader.GetInt32(0);
                    ids.Add(roomId);
                }
                reader.Close();
            }
            return ids;
        }
    }
}