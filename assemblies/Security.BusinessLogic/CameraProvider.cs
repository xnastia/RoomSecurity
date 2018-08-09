using System.Collections.Generic;

namespace Security.BusinessLogic
{
    public class CameraProvider
    {
        CameraRepository _cameraRepository = new CameraRepository();

        public List<Camera> GetRoomCameras(int roomId)
        {
            return _cameraRepository.GetRoomCameras(roomId);
        }
    }
}