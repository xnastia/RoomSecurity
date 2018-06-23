﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Security.Entities
{
    public struct CheckerResponse {
        public bool IsIntruder;
        public BadgeType Badge;
    }
    public class RoomSecurityChecker
    {
        public List<Camera> Cameras { get; set; }
        public Dictionary<BadgeType, List<AllowedTime>> PresenseRules { get; set; }
        private BadgeType IntruderBadge;

        public bool IsBadgeAllowed(BadgeType badge, TimeSpan currentTime)
        {
            /*if (currentTime > new TimeSpan(24, 0, 0))
                throw new ArgumentException($"The {nameof(currentTime)} should be in range 0 to 24 hours");*/

            if (!PresenseRules.ContainsKey(badge))
                return false;

            if (PresenseRules[badge].Any(x => x.IsTimeAllowed(currentTime)))
                return true;

            IntruderBadge = badge;
            return false;
        }

        public bool IsAreaSafety(TimeSpan currentTime, Camera camera)
        {
            if (camera.DetectedBages.Count == 0)
                return true;
            if (camera.DetectedBages.Any(badge => !IsBadgeAllowed(badge, currentTime)))
                return false;
            return true;
        }

        public CheckerResponse IsIntruderInRoom(TimeSpan currentTime)
        {
            CheckerResponse checkerResponse;
            checkerResponse.IsIntruder = Cameras.Any(camera => !IsAreaSafety(currentTime, camera));
            checkerResponse.Badge = IntruderBadge;
            return checkerResponse;
        }
    }
}