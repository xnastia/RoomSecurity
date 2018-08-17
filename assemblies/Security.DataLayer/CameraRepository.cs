using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Security.Entities;

namespace Security.DataLayer
{
    public class CameraRepository
    {
        private readonly string _connectionString = 
            ConfigurationManager.ConnectionStrings[1].ConnectionString;
        public List<CameraEntity> GetCamerasbyRoomId(int roomId)
        {
            var getCameraEntities = "SELECT Id FROM Cameras WHERE RoomId = @roomId";

            SqlDataReader reader = null;
            var cameraEntities = new List<CameraEntity>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(getCameraEntities, connection);
                var roomIdParameter = new SqlParameter("@roomId", roomId);
                reader = command.ExecuteReader();
                command.Parameters.Add(roomIdParameter);

                while (reader.Read())
                {
                    var cameraEntity = new CameraEntity()
                    {
                        Id = reader.GetInt32(0)
                    };
                    cameraEntities.Add(cameraEntity);
                }
            }
            reader.Close();
            return cameraEntities;
        }
    }
}