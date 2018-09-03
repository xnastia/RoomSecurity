using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Security.Entities.DB;

namespace Security.DataLayer
{
    public class CameraRepository : ICameraRepository
    {
        private readonly string _connectionString = 
            ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public List<int> GetCamerasbyRoomId(int roomId)
        {
            var getCameraEntitiesExpression = "sp_GetCamerasByRoomId";

            SqlDataReader reader = null;
            var camerasIds = new List<int>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(getCameraEntitiesExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var roomIdParameter = new SqlParameter("@roomId", roomId);
                command.Parameters.Add(roomIdParameter);
                reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                     int id = reader.GetInt32(0);
                     camerasIds.Add(id);
                }
            }
            reader.Close();
            return camerasIds;
        }
    }
}