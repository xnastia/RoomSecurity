using System;
using System.Collections.Generic;
using Security.DataLayer;

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
            var presenceRules = _rulesProvider.CreatePresenceRules(roomId);
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

    public class RoomProvider
    {
        RoomRepository _roomRepository = new RoomRepository();

        public string GetRoomName(int roomId)
        {
            return _roomRepository.GetRoomName(roomId);
        }
    }

    public class CameraProvider
    {
        CameraRepository _cameraRepository = new CameraRepository();

        public List<Camera> GetRoomCameras(int roomId)
        {
            return _cameraRepository.GetRoomCameras(roomId);
        }
    }

    public class CameraRepository
    {
        public List<Camera> GetRoomCameras(int roomId)
        {
            switch (roomId)
            {
                case 1:
                    return new List<Camera>()
                    {
                        new Camera(5),
                        new Camera(6),
                        new Camera(7),
                        new Camera(8)
                    };
                case 3:
                    return new List<Camera>()
                    {
                        new Camera(1),
                        new Camera(2),
                        new Camera(3),
                        new Camera(4)
                    };
                case 4:
                    return new List<Camera>()
                    {
                        new Camera(9),
                        new Camera(10),
                        new Camera(11),
                        new Camera(12)
                    };
                default:
                    throw new NotImplementedException("1 to 4 Ids are valid for now before DataLayer and DB has been implemented");
            }
        }
    }
}
