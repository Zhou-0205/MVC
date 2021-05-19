using ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Filters
{
    public class ContextPerRequest : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                BaseService.Commit();
            }
            else
            {
                BaseService.RollBack();
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }
    }
}