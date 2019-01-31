using System.Web.Mvc;

namespace BancoDeSangre.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}