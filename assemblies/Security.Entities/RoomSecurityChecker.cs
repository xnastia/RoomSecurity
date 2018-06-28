using System;
using System.Collections.Generic;
using System.Linq;

namespace Security.Entities
{
    public class RoomSecurityChecker
    {
        public List<Camera> Cameras { get; set; }
        public Dictionary<BadgeType, List<AllowedTime>> PresenseRules { get; set; }

        public bool IsBadgeAllowed(BadgeType badge, TimeSpan currentTime)
        {
            if (currentTime > new TimeSpan(24, 0, 0))
                throw new ArgumentException($"The {nameof(currentTime)} should be in range 0 to 24 hours");

            if (!PresenseRules.ContainsKey(badge))
                return false;

            if (PresenseRules[badge].Any(x => x.IsTimeAllowed(currentTime)))
                return true;

            return false;
        }

        public CheckerResponse CheckRoom(TimeSpan currentTime)
        {
            var intrudersBadges = new List<BadgeType>();
            foreach (var camera in Cameras)
                intrudersBadges.AddRange(camera.DetectedBadges.Where(badge => !IsBadgeAllowed(badge, currentTime)));
            var checkerResponse = new CheckerResponse(intrudersBadges, currentTime);
            return checkerResponse;
        }
    }
}