using System.Collections.Generic;
using Security.DataLayer;
using Security.Entities.DB;

namespace Security.BusinessLogic
{
    public class CameraProvider
    {
        private readonly ICameraRepository _cameraRepository;

        public CameraProvider(ICameraRepository cameraRepository)
        {
            _cameraRepository = cameraRepository;
        }

        public CameraProvider()
        {
            _cameraRepository = new CameraRepository();
        }

        public List<Camera> GetRoomCameras(int roomId)
        {
            var camerasEntities = _cameraRepository.GetCamerasbyRoomId(roomId);
            var cameras = new List<Camera>();
            foreach (var cameraEntity in camerasEntities)
            {
                var camera = new Camera(cameraEntity.Id);
                cameras.Add(camera);
            }

            return cameras;
        }
    }
}