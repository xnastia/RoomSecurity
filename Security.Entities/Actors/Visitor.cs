using System;

namespace Security.Entities.Actors
{
    class Visitor : Person
    {
        static Visitor()
        {
            WorkDayBegins = new TimeSpan(10, 0, 0);
            WorkDayEnds = new TimeSpan(15, 0, 0);
        }
    }
}