using System;

namespace Security.DataLayer.EF
{
    public class Monitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid UiId { get; set; }
    }
}