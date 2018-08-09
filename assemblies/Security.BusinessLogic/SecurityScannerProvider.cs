namespace Security.BusinessLogic
{
   public class SecurityScannerProvider
    {
        RoomProvider _roomProvider = new RoomProvider();
        CameraProvider _cameraProvider = new CameraProvider();
        PresenceRulesProvider _rulesProvider = new PresenceRulesProvider();

        public SecurityScanner GetRoom(int roomId, IRecognizer recognizer)
        {
            string roomName = _roomProvider.GetRoomName(roomId);
            var cameras = _cameraProvider.GetRoomCameras(roomId);
            var presenceRules = _rulesProvider.GetPresenceRules(roomId);
            return new SecurityScanner(roomName, presenceRules, recognizer, cameras);
        }

        public SecurityScanner CreateConferenceRoom(IRecognizer recognizer)
        {
            return GetRoom(1, recognizer);
        }

        public SecurityScanner CreateHall(IRecognizer recognizer)
        {
            return GetRoom(2, recognizer);
        }

        public SecurityScanner CreateDinnerRoom(IRecognizer recognizer)
        {
            return GetRoom(3, recognizer);
        }

        public SecurityScanner CreateArmoryRoom(IRecognizer recognizer)
        {
            return GetRoom(4, recognizer);
        }

    }
}
