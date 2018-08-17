using System.Collections.Generic;
using Security.Entities;

namespace Security.BusinessLogic
{
   public class SecurityScannerProvider
    {
        RoomProvider _roomProvider = new RoomProvider();
        CameraProvider _cameraProvider = new CameraProvider();
        PresenceRulesProvider _rulesProvider = new PresenceRulesProvider();

        public SecurityScanner GetRoomScanner(int roomId, IRecognizer recognizer)
        {
            string roomName = _roomProvider.GetRoomName(roomId);
            List<Camera> cameras = _cameraProvider.GetRoomCameras(roomId);
            var presenceRules = _rulesProvider.GetPresenceRules(roomId);
            return new SecurityScanner(roomName, presenceRules, recognizer, cameras);
        }
    }
}
