using System.Collections.Generic;
using System.Linq;
using Security.Entities;
using Security.Entities.DB;

namespace Security.DataLayer.EF
{
    public class CameraRepository : ICameraRepository
    {
        public List<int> GetCamerasbyRoomId(int roomId)
        {
            List<int> camerasIds = new List<int>();
            using (var securityDbContext = new SecurityDbContext())
            {
                camerasIds = securityDbContext.Cameras
                    .Where(camera => camera.RoomId == roomId)
                    .Select(camera => camera.Id)
                    .ToList();
            }
            return camerasIds;

        }
    }
}