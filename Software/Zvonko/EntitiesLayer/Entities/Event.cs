namespace DatabaseLayer {
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

        [StringLength(50)]
        public string day_of_the_week { get; set; }

        public int? accountId { get; set; }

        public int? recordingId { get; set; }

        public int? typeOfEventId { get; set; }

        public virtual Account Account { get; set; }

        public virtual Recording Recording { get; set; }

        public virtual TypeOfEvent TypeOfEvent { get; set; }
    }
}
