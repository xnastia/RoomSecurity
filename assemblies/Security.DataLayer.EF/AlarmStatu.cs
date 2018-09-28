namespace Security.DataLayer.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AlarmStatu
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public DateTime Time { get; set; }

        public int BadgeId { get; set; }

        public virtual Badge Badge { get; set; }

        public virtual Room Room { get; set; }
    }
}
