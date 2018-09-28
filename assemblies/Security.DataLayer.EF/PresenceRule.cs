namespace Security.DataLayer.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PresenceRule
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public int BadgeId { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public virtual Badge Badge { get; set; }

        public virtual Room Room { get; set; }
    }
}
