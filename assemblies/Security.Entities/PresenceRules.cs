using System;

namespace Security.Entities
{
    public class PresenceRule
    {
        public BadgeType BadgeType { get; set; }
        public AllowedTime AllowedTime { get; set; }

        public PresenceRule(int badgeId, TimeSpan startTime, TimeSpan endTime)
        {
            BadgeType = (BadgeType) badgeId;
            AllowedTime = new AllowedTime(startTime,endTime);
          
        }
    }
}
