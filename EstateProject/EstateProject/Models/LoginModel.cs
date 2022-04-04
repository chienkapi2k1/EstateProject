using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstateProject.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Mời nhập user name")]
        public String UserName { get; set; }

        [Required(ErrorMessage = "Mời nhập password")]
        public String PassWord { get; set; }

        public bool RememberMe { get; set; }

    }
}