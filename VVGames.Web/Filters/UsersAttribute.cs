using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VVGames.Web.Filters
{
    public class UsersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userId = HttpContext.Current.Session["UserId"];

            if (userId == null)
            {
                HttpContext.Current.Session["AuthMessage"] = "Для доступа к этой странице необходимо войти в аккаунт.";

                filterContext.Result = new RedirectResult("~/Auth/Sing");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}