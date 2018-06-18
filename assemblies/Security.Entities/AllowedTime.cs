using System;

namespace Security.Entities
{
    public class AllowedTime
    {
        public AllowedTime(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public bool IsTimeAllowed(TimeSpan currentTime)
        {
            return StartTime <= currentTime && currentTime <= EndTime;
        }
    }
}