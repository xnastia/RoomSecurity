using System;
using System.Collections.Generic;
using System.Linq;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class SecurityScanner : ISecurityScanner
    {
        private readonly List<Camera> _cameras;
        private readonly IRecognizer _recognizer;
        private readonly Dictionary<BadgeType, List<AllowedTime>> _presenseRules;

        public int ScannerId { get; }

        public SecurityScanner(int scannerId, Dictionary<BadgeType, List<AllowedTime>> presenseRules, IRecognizer recognizer, List<Camera>  cameras)
        {
            if (scannerId == 0)
                throw new ArgumentNullException(nameof(scannerId));

            _recognizer = recognizer;
            _cameras = cameras;
            _presenseRules = presenseRules;
            ScannerId = scannerId;
        }
        
        public bool IsBadgeAllowed(BadgeType badge, DateTime currentTime)
        {
            if (currentTime.TimeOfDay > new TimeSpan(24, 0, 0))
                throw new ArgumentException($"The {nameof(currentTime)} should be in range 0 to 24 hours");

            if (!_presenseRules.ContainsKey(badge))
                return false;

            if (_presenseRules[badge].Any(x => x.IsTimeAllowed(currentTime.TimeOfDay)))
                return true;

            return false;
        }

        public CheckerResponse CheckRoom(DateTime currentTime)
        {
            var intrudersBadges = new List<BadgeType>();
            foreach (var camera in _cameras)
                intrudersBadges.AddRange(_recognizer.IdentifyBadges(camera.GetImage()).Where(badge => !IsBadgeAllowed(badge, currentTime)));
            var checkerResponse = new CheckerResponse(ScannerId, intrudersBadges, currentTime);
            return checkerResponse;
        }
    }
}