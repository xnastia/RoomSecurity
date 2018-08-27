using System.Collections.Generic;

namespace Security.Entities.DB
{
    public interface ICameraRepository
    {
        List<int> GetCamerasbyRoomId(int roomId);
    }
}
