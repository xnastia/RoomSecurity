using System;

namespace Security.DataLayer
{
    public class Room
    {
        public Guid UiId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MonitorId { get; set; }
    }
}