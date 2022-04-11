using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstateProject.Models
{
    public class District
    {
        public District(string district)
        {
            this.district = district;
        }
        public string district { get; set; }
    }
}