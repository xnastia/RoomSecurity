using System.Collections.Generic;
using Security.Entities;

namespace Security.BusinessLogic
{
    public interface IPresenceRulesProvider
    {
        Dictionary<BadgeType, List<AllowedTime>> GetPresenceRules(int roomId);
    }
}
