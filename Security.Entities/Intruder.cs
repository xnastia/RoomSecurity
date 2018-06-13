using System;

namespace Security.Entities
{
    class Intruder : Person
    {
        static Intruder()
        {
            WorkDayBegins = new TimeSpan(0, 0, 0);
            WorkDayEnds = new TimeSpan(0, 0, 0);
        }

    }
}