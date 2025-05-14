using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VVGames.Web.Filters
{
    public class AdminsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var role = HttpContext.Current.Session["Role"]?.ToString();

            if (string.IsNullOrEmpty(role) || (role != "Admin" && role != "SuperAdmin"))
            {
                filterContext.Result = new RedirectResult("~/Auth/AccessDenied");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}