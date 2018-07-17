using System;
using System.Collections.Generic;

namespace Security.BusinessLogic
{
    public class PresenceRulesProvider
    {
        public Dictionary<BadgeType, List<AllowedTime>> CreatePresenceRules(int roomId)
        {
            var presenseRules = new Dictionary<BadgeType, List<AllowedTime>>();
            var visitorAllowedTimes =
                new List<AllowedTime> { new AllowedTime(new TimeSpan(10, 00, 00), new TimeSpan(15, 00, 00)) };
            var supportAllowedTimes =
                new List<AllowedTime> { new AllowedTime(new TimeSpan(8, 00, 00), new TimeSpan(20, 00, 00)) };
            var securityOfficerAllowedTimes =
                new List<AllowedTime> { new AllowedTime(new TimeSpan(00, 00, 00), new TimeSpan(24, 00, 00)) };
            var noBadgeAllowedTimes =
                new List<AllowedTime> { new AllowedTime(new TimeSpan(0, 00, 00), new TimeSpan(0, 00, 01)) };
            presenseRules.Add(BadgeType.Visitor, visitorAllowedTimes);
            presenseRules.Add(BadgeType.Support, supportAllowedTimes);
            presenseRules.Add(BadgeType.SecurityOfficer, securityOfficerAllowedTimes);
            presenseRules.Add(BadgeType.NoBadge, noBadgeAllowedTimes);
            return presenseRules;
        }
    }
}
