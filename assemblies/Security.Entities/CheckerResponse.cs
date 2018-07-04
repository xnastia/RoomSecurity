using System;
using System.Collections.Generic;
using System.Linq;

namespace Security.Entities
{
    public class CheckerResponse
    {
        public CheckerResponse(string scannerName, List<BadgeType> intruders, TimeSpan checkTime)
        {
            ScannerName = scannerName;
            Intruders = intruders;
            if (checkTime > new TimeSpan(24, 0, 0))
                throw new ArgumentException($"The {nameof(checkTime)} should be in range 0 to 24 hours");
            CheckTime = checkTime;
        }

        public bool IntruderFound => Intruders != null && Intruders.Any();

        public string ScannerName { get; }

        public List<BadgeType> Intruders { get; }

        public TimeSpan CheckTime { get; }
    }
}