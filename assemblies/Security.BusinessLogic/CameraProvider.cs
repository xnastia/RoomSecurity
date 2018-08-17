using System.Collections.Generic;
using Security.DataLayer;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class CameraProvider
    {
        readonly CameraRepository _cameraRepository = new CameraRepository();

        public List<Camera> GetRoomCameras(int roomId)
        {
            List<CameraEntity> camerasEntities = _cameraRepository.GetCamerasbyRoomId(roomId);
            List<Camera> cameras = new List<Camera>();
            foreach (var cameraEntity in camerasEntities)
            {
                Camera camera = new Camera(cameraEntity.Id);
                cameras.Add(camera);
            }

            return cameras;
        }
    }
}