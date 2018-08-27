using System;

namespace Security.DataLayer.EF
{
    public class PresenceRules
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int BadgeId { get; set; }
        public Badge Badge { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}