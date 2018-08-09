using System;
using System.Collections.Generic;

namespace Security.BusinessLogic
{
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
                case 2:
                    return new List<Camera>()
                    {
                        new Camera(13),
                        new Camera(14),
                        new Camera(15),
                        new Camera(16)
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