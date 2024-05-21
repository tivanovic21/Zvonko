namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Event
    {
        public int id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        public string description { get; set; }

        public TimeSpan? starting_time { get; set; }

        public int? accountId { get; set; }

        public int? recordingId { get; set; }

        public int? typeOfEventId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public bool? monday { get; set; }

        public bool? tuesday { get; set; }

        public bool? wednesday { get; set; }

        public bool? thursday { get; set; }

        public bool? friday { get; set; }

        public bool? saturday { get; set; }

        public bool? sunday { get; set; }

        public virtual Account Account { get; set; }

        public virtual Recording Recording { get; set; }

        public virtual TypeOfEvent TypeOfEvent { get; set; }
    }
}
