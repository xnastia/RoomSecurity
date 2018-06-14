using System;
using System.Collections.Generic;

namespace Security.Entities
{
    public class RoomMonitor
    {
        public List<Camera> Cameras { get; set; }

        public bool IsBadgeTypeInPresentRules(Dictionary<BadgeType, List<AllowedTime>> presentRules,
            BadgeType badgeType, TimeSpan currentTime)
        {
            var allowedTimeBadgeType = presentRules[badgeType];
            var isTimeAllowed = false;

            foreach (var allowedTime in allowedTimeBadgeType)
                isTimeAllowed = isTimeAllowed || allowedTime.IsTimeAllowed(currentTime);

            return isTimeAllowed;
        }

        public bool IsAreaSafety(Camera camera, Dictionary<BadgeType, List<AllowedTime>> presentRules,
            TimeSpan currentTime)
        {
            var isAreaSafety = false;
            foreach (var badge in camera.DetectedBadges)
                isAreaSafety = isAreaSafety || IsBadgeTypeInPresentRules(presentRules, badge, currentTime);

            return isAreaSafety;
        }


        /* public bool IsSafety()
        {
            var result = true;
            foreach (var detectedBadge in Camera.DetectedBadges)
            {
                var person = Person.GetPersonByBadge(detectedBadge);
                result = result && person.IsPresentLegal(DateTime.Now.TimeOfDay);
            }

            return result;

        }*/

        public bool IsIntruderInRoom(List<Camera> localCameras, Dictionary<BadgeType, List<AllowedTime>> presentRules,
            TimeSpan currentTime)
        {
            foreach (var camera in localCameras)
                if (!IsAreaSafety(camera, presentRules, currentTime))
                    return true;
            return false;
        }
    }
}