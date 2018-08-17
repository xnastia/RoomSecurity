using System;

namespace Security.Entities
{
    public class AllowedTime
    {
        private readonly TimeSpan midnight = new TimeSpan(24, 0, 0);

        public AllowedTime(TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime > midnight)
                throw new ArgumentException(nameof(startTime));
            StartTime = startTime;
            if (endTime > midnight)
                throw new ArgumentException(nameof(endTime));
            EndTime = endTime;
        }

        private TimeSpan StartTime { get; }

        private TimeSpan EndTime { get; }

        public bool IsTimeAllowed(TimeSpan currentTime)
        {
            if (currentTime > midnight)
                throw new ArgumentException(nameof(currentTime));
            if (StartTime < EndTime)
                return StartTime <= currentTime && currentTime <= EndTime;
            if (StartTime <= currentTime && currentTime <= midnight)
                return true;
            if (StartTime >= currentTime && currentTime <= EndTime)
                return true;
            return false;
        }
    }
}