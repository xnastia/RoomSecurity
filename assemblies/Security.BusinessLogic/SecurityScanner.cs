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

        public string ScannerName { get; }

        public SecurityScanner(string scannerName, Dictionary<BadgeType, List<AllowedTime>> presenseRules, IRecognizer recognizer, List<Camera>  cameras)
        {
            if (string.IsNullOrEmpty(scannerName))
                throw new ArgumentNullException(nameof(scannerName));

            _recognizer = recognizer;
            _cameras = cameras;
            _presenseRules = presenseRules;
            ScannerName = scannerName;
        }
        
        public bool IsBadgeAllowed(BadgeType badge, TimeSpan currentTime)
        {
            if (currentTime > new TimeSpan(24, 0, 0))
                throw new ArgumentException($"The {nameof(currentTime)} should be in range 0 to 24 hours");

            if (!_presenseRules.ContainsKey(badge))
                return false;

            if (_presenseRules[badge].Any(x => x.IsTimeAllowed(currentTime)))
                return true;

            return false;
        }

        public CheckerResponse CheckRoom(TimeSpan currentTime)
        {
            var intrudersBadges = new List<BadgeType>();
            foreach (var camera in _cameras)
                intrudersBadges.AddRange(_recognizer.IdentifyBadges(camera.GetImage()).Where(badge => !IsBadgeAllowed(badge, currentTime)));
            var checkerResponse = new CheckerResponse(ScannerName, intrudersBadges, currentTime);
            return checkerResponse;
        }
    }
}