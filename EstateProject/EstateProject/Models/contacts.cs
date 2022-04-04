namespace EstateProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class contacts
    {
        public int id { get; set; }

        public int? user_id { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string fullname { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        public string messages { get; set; }

        public DateTime? createddate { get; set; }

        public DateTime? modifieddate { get; set; }

        public virtual user users { get; set; }
    }
}
