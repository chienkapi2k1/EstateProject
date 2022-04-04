using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstateProject.Models
{
    public class ListContact
    {
        public ListContact(int id, string user_name, string email, string fullname, string phone, string title, string status, string messages)
        {
            this.id = id;
            this.user_name = user_name;
            this.email = email;
            this.fullname = fullname;
            this.phone = phone;
            this.title = title;
            this.status = status;
            this.messages = messages;
        }


        public int id { get; set; }

        public string user_name { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string fullname { get; set; }

        [Required]
        [StringLength(255)]
        public string phone { get; set; }

        [Required]
        [StringLength(255)]
        public string title { get; set; }

        [Required]
        [StringLength(255)]
        public string status { get; set; }

        [Required]
        public string messages { get; set; }
    }
}