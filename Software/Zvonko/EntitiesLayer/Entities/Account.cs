namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Events = new HashSet<Event>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(200)]
        public string password { get; set; }

        [StringLength(200)]
        public string schoolName { get; set; }

        [StringLength(50)]
        public string macAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Recording> Recordings { get; set; }
    }
}
