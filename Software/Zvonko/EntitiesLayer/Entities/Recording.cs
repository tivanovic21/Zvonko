namespace DatabaseLayer
{
    using EntitiesLayer;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Recording
    {
        public int id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        public TimeSpan? duration { get; set; }

        public string description { get; set; }

        public byte[] storedFile { get; set; }

        public int? accountId { get; set; }

        [StringLength(50)]
        public string timeCreated { get; set; }

        public virtual Account Account { get; set; }
    }
}
