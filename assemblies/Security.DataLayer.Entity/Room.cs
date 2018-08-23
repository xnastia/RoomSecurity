using System;

namespace Security.DataLayer.Entity
{
    public class Room
    {
        public Guid UiId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MonitorId { get; set; }
        public Monitor Monitor { get; set; }
    }
}