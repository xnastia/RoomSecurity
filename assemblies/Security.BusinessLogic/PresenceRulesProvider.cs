using System;
using System.Collections.Generic;
using System.Linq;
using Security.DataLayer;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class PresenceRulesProvider
    {
       public Dictionary<BadgeType, List<AllowedTime>> GetPresenceRules(int roomId)
        {
           PresenceRulesRepository presenceRulesRepository = new PresenceRulesRepository();
           List<PresenceRule> presenceRulesList = presenceRulesRepository.GetPresenceRulesByRoomId(roomId);
           var presenceRulesDictionary = new Dictionary<BadgeType, List<AllowedTime>>();
            foreach (BadgeType badgeType in Enum.GetValues(typeof(BadgeType)))
            {
                List<AllowedTime> allowedTimes =
                    presenceRulesList.Where(presenceRule => presenceRule.BadgeType == badgeType)
                    .Select(presenceRule => presenceRule.AllowedTime)
                        .ToList();
                presenceRulesDictionary.Add(badgeType,allowedTimes);
            }

            return presenceRulesDictionary;
        }
    }
}
