using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Filters
{
    public class NeedLogOnAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string cookieId = filterContext.HttpContext.Request.Cookies[Keys.User]?.Value;
            if (string.IsNullOrEmpty(cookieId))
            {
                string url = filterContext.HttpContext.Request.Path;
                filterContext.Result = new RedirectResult("/Log/On?prepage=" + url);
            }
        }
    }
}