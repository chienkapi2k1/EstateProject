using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstateProject.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserId { get; set; }
        public String UserName { get; set; }
        public String role{get; set;}
    }
}