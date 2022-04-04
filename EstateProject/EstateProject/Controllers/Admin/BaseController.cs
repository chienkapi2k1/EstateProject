using EstateProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web.Mvc;

namespace EstateProject.Controllers.Admin
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new {controller ="Login",action="Index"/*,Area ="Admin"*/ }));
            }

            base.OnActionExecuted(filterContext);

          
        }
    }
}