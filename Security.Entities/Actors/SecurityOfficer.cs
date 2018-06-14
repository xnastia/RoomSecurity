using System;
using Security.Entities.Actors;

namespace Security.Entities
{
    class SecurityOfficer : Person
    {
        public SecurityOfficer() { WorkDayBegins = new TimeSpan(0, 0, 0); WorkDayEnds = new TimeSpan(24, 0, 0); }

    }
}