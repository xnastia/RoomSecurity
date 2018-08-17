using System;
using System.Collections.Generic;

namespace Security.Entities
{
    public class PresenceRule
    {
        public BadgeType BadgeType { get; set; }
        public AllowedTime AllowedTime { get; set; }
    }
}
