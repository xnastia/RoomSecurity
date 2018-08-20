using System;
using System.Collections.Generic;
using System.Linq;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class CheckerResponse
    {
        public bool IntruderFound => Intruders != null && Intruders.Any();

        public int ScannerId { get; }

        public List<BadgeType> Intruders { get; }

        public DateTime CheckTime { get; }

        public CheckerResponse(int scannerId, List<BadgeType> intruders, DateTime checkTime)
        {
            ScannerId = scannerId;
            Intruders = intruders;
            /*if (checkTime > new TimeSpan(24, 0, 0))
                throw new ArgumentException($"The {nameof(checkTime)} should be in range 0 to 24 hours");*/
            CheckTime = checkTime;
        }

    }
}