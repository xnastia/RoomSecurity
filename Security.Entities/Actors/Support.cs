﻿using System;

namespace Security.Entities.Actors
{
    class Support : Person
    {
        static Support()
        {
            WorkDayBegins = new TimeSpan(8, 0, 0);
            WorkDayEnds = new TimeSpan(20, 0, 0);
        }
    }
}