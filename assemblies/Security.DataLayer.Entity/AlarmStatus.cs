using System;

namespace Security.DataLayer.Entity
{
    public class AlarmStatus
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime Time { get; set; }
        public int BadgeId { get; set; }
        public Badge Badge { get; set; }
    }
}