namespace EstateProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("building")]
    public partial class building
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public building()
        {
            rentarea = new HashSet<rentarea>();
            building_images = new HashSet<building_images>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string street { get; set; }

        [StringLength(255)]
        public string ward { get; set; }

        [StringLength(255)]
        public string district { get; set; }

        [StringLength(255)]
        public string structure { get; set; }

        public int? numberofbasement { get; set; }

        public int? floorarea { get; set; }

        [StringLength(255)]
        public string direction { get; set; }

        [StringLength(255)]
        public string levels { get; set; }

        public int? rentprice { get; set; }

        [Column(TypeName = "text")]
        public string rentpricedescription { get; set; }

        [StringLength(255)]
        public string servicefee { get; set; }

        [StringLength(255)]
        public string carfee { get; set; }

        [StringLength(255)]
        public string motofee { get; set; }

        [StringLength(255)]
        public string overtimefee { get; set; }

        [StringLength(255)]
        public string waterfee { get; set; }

        [StringLength(255)]
        public string electricityfee { get; set; }

        [StringLength(255)]
        public string deposit { get; set; }

        [StringLength(255)]
        public string payment { get; set; }

        [StringLength(255)]
        public string renttime { get; set; }

        [StringLength(255)]
        public string decorationtime { get; set; }

        public decimal? brokeragetee { get; set; }

        [StringLength(255)]
        public string typess { get; set; }

        [StringLength(255)]
        public string note { get; set; }

        [StringLength(255)]
        public string linkofbuilding { get; set; }

        [StringLength(255)]
        public string map { get; set; }

        [StringLength(255)]
        public string avatar { get; set; }

        public DateTime? createddate { get; set; }

        public DateTime? modifieddate { get; set; }

        [StringLength(255)]
        public string createdby { get; set; }

        [StringLength(255)]
        public string modifiedby { get; set; }

        public int? user_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rentarea> rentarea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<building_images> building_images { get; set; }

        public virtual user users { get; set; }
    }
}
