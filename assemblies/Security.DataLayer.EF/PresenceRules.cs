using System;

namespace Security.DataLayer.EF
{
    public class PresenceRules
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int BadgeId { get; set; }
        public Badge Badge { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}