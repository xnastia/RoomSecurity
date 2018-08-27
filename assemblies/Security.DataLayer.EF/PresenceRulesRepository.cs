using System;
using System.Collections.Generic;
using System.Linq;
using Security.Entities;
using Security.Entities.DB;

namespace Security.DataLayer.EF
{
    public class PresenceRulesRepository : IPresenceRulesRepository
    {
        public List<PresenceRule> GetPresenceRulesByRoomId(int roomId)
        {
            List<PresenceRule> presenceRulesList = new List<PresenceRule>();
            using (var securityDbContext = new SecurityDbContext())
            {
                var presenceRules = securityDbContext.PresenceRuleses
                    .Where(presenceRule => presenceRule.RoomId == roomId)
                    .Select(presenceRule => new {presenceRule.BadgeId, presenceRule.StartTime, presenceRule.EndTime});
                foreach (var presenceRule in presenceRules)
                {
                    var presenceRuleEntityType = new PresenceRule(presenceRule.BadgeId,
                        presenceRule.StartTime.TimeOfDay, presenceRule.EndTime.TimeOfDay);
                    presenceRulesList.Add(presenceRuleEntityType);
                }

            }
            return presenceRulesList;
        }
    }
}