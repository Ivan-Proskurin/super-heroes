using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Superheroes.Web.ViewModels;
using Superheroes.Web.Filters;

namespace Superheroes.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new AppInfoViewModel());
        }

        public ActionResult About()
        {
            return View(new AboutViewModel());
        }

        public ActionResult Contact()
        {
            return View(new ContactViewModel());
        }
    }
}