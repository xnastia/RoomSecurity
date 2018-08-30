using System;
using System.Collections.Generic;
using System.Linq;
using Security.Entities;
using Security.Entities.DB;

namespace Security.BusinessLogic
{
    public class PresenceRulesProvider : IPresenceRulesProvider
    {
        private readonly IPresenceRulesRepository _presenceRulesRepository;

        public PresenceRulesProvider(IPresenceRulesRepository presenceRulesRepository)
        {
            _presenceRulesRepository = presenceRulesRepository;
        }
        
        public Dictionary<BadgeType, List<AllowedTime>> GetPresenceRules(int roomId)
        {
            var presenceRulesList = _presenceRulesRepository.GetPresenceRulesByRoomId(roomId);
            var presenceRulesDictionary = new Dictionary<BadgeType, List<AllowedTime>>();
            foreach (BadgeType badgeType in Enum.GetValues(typeof(BadgeType)))
            {
                var allowedTimes =
                    presenceRulesList.Where(presenceRule => presenceRule.BadgeType == badgeType)
                        .Select(presenceRule => presenceRule.AllowedTime)
                        .ToList();
                presenceRulesDictionary.Add(badgeType, allowedTimes);
            }

            return presenceRulesDictionary;
        }
    }
}