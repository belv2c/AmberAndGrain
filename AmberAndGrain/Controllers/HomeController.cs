using System.Web.Mvc;

namespace AmberAndGrain.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // transfers data from the controller to the view
            // ViewBag.Title = "Home Page";

            return View();
        }
    }
}
