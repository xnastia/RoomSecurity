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
            CheckTime = checkTime;
        }
    }
}