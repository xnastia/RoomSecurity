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

            public bool IsAreaSafety(TimeSpan currentTime, Camera camera)
            {
                if (camera.DetectedBadges.Count == 0)
                    return true;
                if (camera.DetectedBadges.Any(badge => !IsBadgeAllowed(badge, currentTime)))
                    return false;
                return true;
            }

            public CheckerResponse IsIntruderInRoom(TimeSpan currentTime)
            {
                var intrudersBadges = new List<BadgeType>();
                var checkerResponse = new CheckerResponse(intrudersBadges, currentTime);
                var camerasWithSuspiciousBadges =
                    Cameras.Where(camera => !IsAreaSafety(checkerResponse.CheckTime, camera));
                var suspiciousBadges =
                    camerasWithSuspiciousBadges.SelectMany(camera => camera.DetectedBadges);
                checkerResponse.Intruders = suspiciousBadges
                    .Where(badge => !IsBadgeAllowed(badge, checkerResponse.CheckTime)).ToList();
                return checkerResponse;
            }
        }
    }
