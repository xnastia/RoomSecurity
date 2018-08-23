using System.Collections.Generic;

namespace Security.Entities.DB
{
    public interface ICameraRepository
    {
        List<CameraEntity> GetCamerasbyRoomId(int roomId);
    }
}
