using System;

namespace Security.Entities.Actors
{
    public abstract class Person
    {
        public static TimeSpan WorkDayBegins { get; set; }

        public static TimeSpan WorkDayEnds { get; set; }

        public bool IsPresentLegal(TimeSpan currenttime)
        {
            return currenttime >= WorkDayBegins && currenttime <= WorkDayEnds;
        }

        public static Person GetPersonByBadge(BadgeType badgeType)
        {
            switch (badgeType)
            {
                case BadgeType.Visitor:
                    return new Visitor();
                case BadgeType.Support:
                    return new Support();
                case BadgeType.SecurityOfficer:
                    return new SecurityOfficer();
                case BadgeType.NoBadge:
                    return new Intruder();
                default:
                    throw new NotImplementedException($"This value of {nameof(badgeType)} is not supported");
            }
        }
    }
}