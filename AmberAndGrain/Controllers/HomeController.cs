using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmberAndGrain.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // transfers data from the controller to the view
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
