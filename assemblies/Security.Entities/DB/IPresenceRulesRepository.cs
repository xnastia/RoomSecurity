﻿using System.Collections.Generic;

namespace Security.Entities.DB
{
    public interface IPresenceRulesRepository
    {
        List<PresenceRule> GetPresenceRulesByRoomId(int roomId);
    }
}