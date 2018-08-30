using System.Collections.Generic;

namespace Security.BusinessLogic
{
    public interface ICameraProvider
    {
        List<Camera> GetRoomCameras(int roomId);
    }
}
