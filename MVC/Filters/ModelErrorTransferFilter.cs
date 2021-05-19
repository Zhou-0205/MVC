using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Filters
{
    public class ModelErrorTransferFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ModelStateDictionary modelstate = ((Controller)filterContext.Controller).ModelState;

            if (filterContext.IsChildAction)
            {

            }
            if (filterContext.HttpContext.Request.HttpMethod == Keys.Post)
            {
                if (!modelstate.IsValid)
                {
                    filterContext.Controller.TempData[Keys.ErrorInModel] = modelstate;
                    filterContext.Result =
                        new RedirectResult(filterContext.HttpContext.Request.Url.PathAndQuery);
                }//else nothing
            }
            else if (filterContext.HttpContext.Request.HttpMethod == Keys.Get)
            {
                ModelStateDictionary errors =
                    filterContext.Controller.TempData[Keys.ErrorInModel] as ModelStateDictionary;
                if (errors != null)
                {
                    modelstate.Merge(errors);
                }//else nothing
            }
            else
            {
                throw new NotImplementedException("");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}