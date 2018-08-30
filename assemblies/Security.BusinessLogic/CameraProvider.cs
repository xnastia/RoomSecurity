using System.Collections.Generic;
using Security.Entities.DB;

namespace Security.BusinessLogic
{
    public class CameraProvider : ICameraProvider
    {
        private readonly ICameraRepository _cameraRepository;

        public CameraProvider(ICameraRepository cameraRepository)
        {
            _cameraRepository = cameraRepository;
        }

        public List<Camera> GetRoomCameras(int roomId)
        {
            var camerasIds = _cameraRepository.GetCamerasbyRoomId(roomId);
            var cameras = new List<Camera>();
            foreach (var cameraId in camerasIds)
            {
                var camera = new Camera(cameraId);
                cameras.Add(camera);
            }

            return cameras;
        }
    }
}