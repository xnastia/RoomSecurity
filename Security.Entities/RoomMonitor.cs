using System.Collections.Generic;

namespace Security.Entities
{
    public class RoomMonitor
    {
        public List<Camera> Cameras;
        public bool IsIntruderInRoom(List<Camera> LocalCameras)
        {

            foreach (Camera c in LocalCameras)
            {
                if (!c.IsSafety())
                {
                    return true;
                }
            }
            return false;
        }
    }
}