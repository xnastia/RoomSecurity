using System.Collections.Generic;
using Security.Entities.DB;

namespace Security.BusinessLogic
{
   public class SecurityScannerProvider
   {
       private readonly CameraProvider _cameraProvider;
       private readonly PresenceRulesProvider _rulesProvider;

       public SecurityScannerProvider(ICameraRepository cameraRepository, 
           IPresenceRulesRepository presenceRulesRepository)
       {
           _cameraProvider = new CameraProvider(cameraRepository);
           _rulesProvider = new PresenceRulesProvider(presenceRulesRepository);
       }

       public SecurityScannerProvider()
       {
           _cameraProvider = new CameraProvider();
           _rulesProvider = new PresenceRulesProvider();
       }

        public SecurityScanner GetRoomScanner(int roomId, IRecognizer recognizer)
        {
            List<Camera> cameras = _cameraProvider.GetRoomCameras(roomId);
            var presenceRules = _rulesProvider.GetPresenceRules(roomId);
            return new SecurityScanner(roomId, presenceRules, recognizer, cameras);
        }
    }
}
