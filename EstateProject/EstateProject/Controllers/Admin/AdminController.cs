using EstateProject.Controllers.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstateProject.Controllers
{
    [HandleError]
    public class AdminController : BaseController
    {
        [Route("admin")]
        public ActionResult Index()
        {
            return View();
        }

       
    }
}