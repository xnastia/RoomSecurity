using System;
using System.Collections.Generic;

namespace Security.Entities
{
    public class RoomMonitor
    {
        public List<Camera> Cameras { get; set; }
        public Dictionary<BadgeType, List<AllowedTime>> PresentRules { get; set; }

        public bool IsBadgeAllowed(BadgeType badge, TimeSpan currentTime)
        {
            var isBadgeAllowed = false;
            foreach (var allowedTime in PresentRules[badge])
                isBadgeAllowed = allowedTime.IsTimeAllowed(currentTime) || isBadgeAllowed;

            return isBadgeAllowed;
        }

        public bool IsAreaSafety(TimeSpan currentTime, Camera camera)
        {
            var isAreaSafety = false;
            foreach (var badge in camera.DetectedBages)
                isAreaSafety = IsBadgeAllowed(badge, currentTime) || isAreaSafety;

            return isAreaSafety;
        }

        public bool IsIntruderInRoom(TimeSpan currentTime)
        {
            foreach (var camera in Cameras)
                if (!IsAreaSafety(currentTime, camera))
                    return true;
            return false;
        }
    }
}