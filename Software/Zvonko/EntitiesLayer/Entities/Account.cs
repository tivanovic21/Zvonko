namespace EntitiesLayer
{
    using DatabaseLayer;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Account
    {
        public int id { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [StringLength(200)]
        public string schoolName { get; set; }

        [StringLength(50)]
        public string macAddress { get; set; }

        public virtual Recording Recording { get; set; }
    }
}
