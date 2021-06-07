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

        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (!filterContext.IsChildAction)
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


            base.OnResultExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }
    }
}