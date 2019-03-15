using System.Web.Mvc;

namespace BancoDeSangre.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Shows the Index page
        /// </summary>
        /// <returns>Home Page</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}