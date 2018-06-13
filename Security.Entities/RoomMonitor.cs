using System.Collections.Generic;

namespace Security.Entities
{
    public class RoomMonitor
    {
        public List<Camera> Cameras { get; set; }
        public bool IsIntruderInRoom(List<Camera> localCameras)
        {

            foreach (Camera c in localCameras)
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