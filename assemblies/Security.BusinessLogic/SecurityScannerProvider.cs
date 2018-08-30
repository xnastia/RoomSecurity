using System.Collections.Generic;

namespace Security.BusinessLogic
{
   public class SecurityScannerProvider : ISecurityScannerProvider
   {
       private readonly ICameraProvider _cameraProvider;
       private readonly IPresenceRulesProvider _rulesProvider;

       public SecurityScannerProvider(ICameraProvider cameraProvider, 
           IPresenceRulesProvider presenceRulesProvider)
       {
           _cameraProvider = cameraProvider;
           _rulesProvider = presenceRulesProvider;
       }

        public SecurityScanner GetRoomScanner(int roomId, IRecognizer recognizer)
        {
            List<Camera> cameras = _cameraProvider.GetRoomCameras(roomId);
            var presenceRules = _rulesProvider.GetPresenceRules(roomId);
            return new SecurityScanner(roomId, presenceRules, recognizer, cameras);
        }
    }
}
