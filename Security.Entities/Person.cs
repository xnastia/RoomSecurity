using System;

namespace Security.Entities
{
    public abstract class Person
    {
        public static TimeSpan WorkDayBegins { get; set; }

        public static TimeSpan WorkDayEnds { get; set; }

        public bool IsPresentLegal(TimeSpan currenttime)
        {
            return currenttime >= WorkDayBegins && currenttime <= WorkDayEnds;
        }

        public static Person GetPersonByBadge(BageType bageType)
        {
            switch (bageType)
            {
                case BageType.Visitor:
                    return new Visitor();
                case BageType.Support:
                    return new Support();
                case BageType.SecurityOfficer:
                    return new SecurityOfficer();
                case BageType.NoBadge:
                    return new Intruder();
                default:
                    throw new NotImplementedException($"This value of {nameof(bageType)} is not supported");
            }
        }
    }
}