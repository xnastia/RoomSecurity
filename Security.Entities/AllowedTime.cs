using System;
namespace Security.Entities
{
    public class AllowedTime
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public AllowedTime(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public bool IsTimeAllowed(TimeSpan currentTime)
        {
            return StartTime <= currentTime && currentTime >= EndTime;
        }

    }
}
