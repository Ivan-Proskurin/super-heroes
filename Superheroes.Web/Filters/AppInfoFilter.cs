using Superheroes.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superheroes.Web.Filters
{
    public class AppInfoFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.Appinfo = new AppInfoViewModel();
            base.OnActionExecuted(filterContext);
        }
    }
}