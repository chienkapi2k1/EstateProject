using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstateProject.Models
{
    [MetadataTypeAttribute(typeof(contactsMetadata))]
    public partial class contacts
    {
        internal sealed class contactsMetadata
        {
            public int id { get; set; }
            public int? user_id { get; set; }

            [StringLength(255)]
            [Required(ErrorMessage = "Please enter data for this field")]
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string email { get; set; }

            [StringLength(255)]
            [Required(ErrorMessage = "Please enter data for this field")]
            public string fullname { get; set; }

            [StringLength(255)]
            [Required(ErrorMessage = "Please enter data for this field")]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
            public string phone { get; set; }

            public string title { get; set; }

            [StringLength(255)]
            public string status { get; set; }

            [Required(ErrorMessage = "Please enter data for this field")]
            public string messages { get; set; }

            public DateTime? createddate { get; set; }

            public DateTime? modifieddate { get; set; }

        }
    }
}